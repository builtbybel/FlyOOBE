using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using WUApiLib;

namespace Flyoobe
{
    public partial class UpdatesControlView : UserControl, IView
    {
        // Keep updates by stable UpdateID (titles are not unique)
        private readonly Dictionary<string, IUpdate> _byId = new Dictionary<string, IUpdate>();

        public UpdatesControlView()
        {
            InitializeComponent();
            assetViewInfo.Text = "\uE895";
            btnInstallUpdates.Visible = false;   // hidden until something is found
            btnInstallUpdates.Enabled = false;
        }

        private async void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            // UI state while searching
            btnCheckUpdates.Enabled = false;
            btnInstallUpdates.Visible = false;   // hide during search
            btnInstallUpdates.Enabled = false;
            updatesListBox.Items.Clear();
            lblStatus.Text = "Checking for updates...";

            try
            {
                var items = await Task.Run(() => SearchUpdates());
                updatesListBox.Items.Clear();

                if (items.Count == 0)
                {
                    updatesListBox.Items.Add("No updates available.");
                    lblStatus.Text = "No updates found.";
                    btnCheckUpdates.Enabled = true;
                    return;
                }

                // Show updates (Title + [UpdateID] so we can map back later)
                foreach (var it in items)
                    updatesListBox.Items.Add($"{it.Title} {(it.KB != null ? "(KB" + it.KB + ") " : "")}[{it.Id}]");

                lblStatus.Text = $"{items.Count} update(s) available.";
                btnInstallUpdates.Visible = true;  // show after search
                btnInstallUpdates.Enabled = true;
            }
            catch (COMException ex)
            {
                updatesListBox.Items.Add($"Search failed. HRESULT=0x{ex.HResult:X8}");
                lblStatus.Text = "Search error.";
            }
            catch (Exception ex)
            {
                updatesListBox.Items.Add("Unexpected error: " + ex.Message);
                lblStatus.Text = "Search error.";
            }
            finally
            {
                btnCheckUpdates.Enabled = true;
            }
        }

        private async void btnInstallUpdates_Click(object sender, EventArgs e)
        {
            // Some quick admin check
            if (!Utils.IsRunningAsAdmin())
            {
                updatesListBox.Items.Add("Please restart the app as Administrator.");
                lblStatus.Text = "Admin rights required.";
                return;
            }

            // Parse selected UpdateIDs from ListBox text
            var ids = updatesListBox.SelectedItems.Cast<object>()
                         .Select(o => ExtractId(o.ToString()))
                         .Where(id => id != null)
                         .Distinct()
                         .ToList();

            if (ids.Count == 0)
            {
                updatesListBox.Items.Add("No updates selected.");
                return;
            }

            // UI state while installing
            btnInstallUpdates.Enabled = false;
            btnCheckUpdates.Enabled = false;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            lblStatus.Text = "Installing updates...";

            try
            {
                var (ok, reboot) = await Task.Run(() => Install(ids));
                updatesListBox.Items.Add(ok ? "Updates installed successfully." : "Update installation failed.");
                lblStatus.Text = reboot ? "Installation complete. Restart required." : "Installation complete.";
            }
            catch (COMException ex)
            {
                updatesListBox.Items.Add($"Install failed. HRESULT=0x{ex.HResult:X8}");
                lblStatus.Text = "Install error.";
            }
            catch (Exception ex)
            {
                updatesListBox.Items.Add("Unexpected error: " + ex.Message);
                lblStatus.Text = "Install error.";
            }
            finally
            {
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Visible = false;
                btnCheckUpdates.Enabled = true;
                btnInstallUpdates.Enabled = true;
                btnInstallUpdates.Visible = true; // show again after install
            }
        }

        // --- Core: search available updates ---
        private List<(string Id, string Title, string KB)> SearchUpdates()
        {
            var resultList = new List<(string, string, string)>();
            _byId.Clear();

            UpdateSession s = null; IUpdateSearcher srch = null; ISearchResult res = null;
            try
            {
                s = new UpdateSession();
                srch = s.CreateUpdateSearcher();
                srch.Online = true; // query Microsoft directly; we can here set false if we rely on WSUS
                res = srch.Search("IsInstalled=0 and IsHidden=0");

                foreach (IUpdate u in res.Updates)
                {
                    var id = u?.Identity?.UpdateID;
                    if (string.IsNullOrEmpty(id)) continue;

                    _byId[id] = u;
                    var kb = (u?.KBArticleIDs != null && u.KBArticleIDs.Count > 0) ? u.KBArticleIDs[0] : null;
                    resultList.Add((id, u?.Title ?? "(no title)", kb));
                }
                return resultList;
            }
            finally
            {
                // minimal COM cleanup (kept short)
                if (res != null) Marshal.FinalReleaseComObject(res);
                if (srch != null) Marshal.FinalReleaseComObject(srch);
                if (s != null) Marshal.FinalReleaseComObject(s);
            }
        }

        // --- Core: download + install selected updates by UpdateID ---
        private (bool Success, bool Reboot) Install(List<string> ids)
        {
            // collect selected updates (skip already installed)
            var toDownload = new UpdateCollection();
            foreach (var id in ids)
                if (_byId.TryGetValue(id, out var u) && !u.IsInstalled) toDownload.Add(u);

            if (toDownload.Count == 0) return (false, false);

            UpdateSession s = null; IUpdateDownloader dl = null; IDownloadResult dlRes = null;
            IUpdateInstaller inst = null; IInstallationResult instRes = null;
            try
            {
                s = new UpdateSession();
                dl = s.CreateUpdateDownloader();
                dl.Updates = toDownload;
                dlRes = dl.Download();
                if (dlRes.ResultCode != OperationResultCode.orcSucceeded) return (false, false);

                var toInstall = new UpdateCollection();
                foreach (IUpdate u in toDownload) if (u.IsDownloaded) toInstall.Add(u);
                if (toInstall.Count == 0) return (false, false);

                inst = s.CreateUpdateInstaller();
                inst.Updates = toInstall;
                instRes = inst.Install();

                var ok = instRes.ResultCode == OperationResultCode.orcSucceeded;
                return (ok, instRes.RebootRequired);
            }
            finally
            {
                if (instRes != null) Marshal.FinalReleaseComObject(instRes);
                if (inst != null) Marshal.FinalReleaseComObject(inst);
                if (dlRes != null) Marshal.FinalReleaseComObject(dlRes);
                if (dl != null) Marshal.FinalReleaseComObject(dl);
                if (toDownload != null) Marshal.FinalReleaseComObject(toDownload);
                if (s != null) Marshal.FinalReleaseComObject(s);
            }
        }

        // Extract "...[UpdateID]" → UpdateID
        private static string ExtractId(string text)
        {
            var i = text.LastIndexOf('['); var j = text.LastIndexOf(']');
            return (i >= 0 && j > i) ? text.Substring(i + 1, j - i - 1) : null;
        }

        public void RefreshView() => btnCheckUpdates_Click(null, null);
    }
}