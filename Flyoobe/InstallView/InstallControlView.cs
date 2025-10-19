using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class InstallControlView : UserControl, IView
    {
        public string ViewTitle => "Custom: Install & Repair";

        // Providers & per-provider last selections
        private readonly List<IInstallProvider> _providers = new List<IInstallProvider>();

        // Store last selections (ISO/exe) per provider ID
        private readonly Dictionary<string, LastSelections> _lastByProvider =
            new Dictionary<string, LastSelections>(StringComparer.OrdinalIgnoreCase);

        public InstallControlView()
        {
            InitializeComponent();
            InitProviderCombo();

            WireUpTooltips();
            HookUpEvents();
            HookSearchBox();
            UpdateHint();
        }

        private void InitProviderCombo()
        {
            // Register install sources
            _providers.Add(new NativeResetProvider());
            _providers.Add(new RufusProvider());
            _providers.Add(new MctProvider());
            _providers.Add(new VentoyProvider());

            _providers.Add(new InPlaceRepairProvider());
            _providers.Add(new RunSetupFromIsoProvider());
            _providers.Add(new MountIsoProvider());

            _providers.Add(new RebootToUefiProvider());
            _providers.Add(new BootMenuInfoProvider());
            _providers.Add(new BackupDriversProvider());

            // Bind providers to dropdown
            if (cboSource != null)
            {
                cboSource.DropDownStyle = ComboBoxStyle.DropDownList;
                cboSource.DisplayMember = nameof(IInstallProvider.DisplayName);
                cboSource.DataSource = _providers;

                cboSource.FormattingEnabled = true;
                cboSource.Format += (s, e) =>
                {
                    var p = e.ListItem as IInstallProvider;
                    if (p == null) { e.Value = e.ListItem?.ToString(); return; }

                    var badgeTool = p.IsExternalTool ? "🧰" : "🪟";
                    var badgeIso = p.TypicallyNeedsIso ? " 💿" : string.Empty;
                    var badgeDl = !string.IsNullOrEmpty(p.DirectDownloadUrl) ? " ⬇️" : string.Empty;
                    e.Value = $"{badgeTool}{badgeIso}{badgeDl}  {p.DisplayName}";
                };

                // In InitProviderCombo(): nur EIN Aufruf statt zweier
                cboSource.SelectedIndexChanged += (s, e) =>
                {
                    UpdateHint();
                    UpdateBadgeLegend(SelectedProvider);   // update badges
                };

                if (cboSource.Items.Count > 0) cboSource.SelectedIndex = 0;

                // Initial legend
                UpdateBadgeLegend(SelectedProvider);
            }
        }

        // Reset all badges and highlight active ones.
        private void UpdateBadgeLegend(IInstallProvider p)
        {
            // local helper to style a "badge" label
            void Style(Label lbl, System.Drawing.Color back, System.Drawing.Color fore)
            {
                if (lbl == null) return;
                lbl.BackColor = back;
                lbl.ForeColor = fore;
                lbl.Padding = new Padding(6, 2, 6, 2);
            }

            // base (dim) + highlight colors
            var dimBack = System.Drawing.Color.FromArgb(240, 240, 240);
            var dimFore = System.Drawing.Color.Black;
            var hiBack = System.Drawing.Color.FromArgb(204, 222, 246); // blue badge
            var hiFore = System.Drawing.Color.Black;

            // reset all badges
            Style(lblBadgeNative, dimBack, dimFore);
            Style(lblBadgeExternal, dimBack, dimFore);
            Style(lblBadgeIso, dimBack, dimFore);
            Style(lblBadgeDl, dimBack, dimFore);

            if (p == null) return;

            // highlight active badges
            if (p.IsExternalTool) Style(lblBadgeExternal, hiBack, hiFore);
            else Style(lblBadgeNative, hiBack, hiFore);

            if (p.TypicallyNeedsIso) Style(lblBadgeIso, hiBack, hiFore);
            if (!string.IsNullOrEmpty(p.DirectDownloadUrl)) Style(lblBadgeDl, hiBack, hiFore);
        }

        public void RefreshView()
        {
            textProviderSearch.Clear();
        }

        // --------------------------------------------------------------------------------
        // Event wiring
        // --------------------------------------------------------------------------------
        private void HookUpEvents()
        {
            // Install section
            if (btnRun != null) btnRun.Click += async (s, e) => await RunSelectedAsync();
            if (btnHomepage != null) btnHomepage.Click += (s, e) => OpenHomepage();
            if (btnDownload != null) btnDownload.Click += async (s, e) => await DownloadProviderAsync();

            // One-click actions
            if (btnQuickRepair != null)
                btnQuickRepair.Click += async (s, e) => await RunQuickAsync("winreset"); // NativeResetProvider.Id

            if (btnCreateUsb != null)
                btnCreateUsb.Click += async (s, e) => await RunQuickAsync("mct");        // MctProvider.Id

        }

        private void WireUpTooltips()
        {
            if (toolTip1 == null) return;

            // Install
            toolTip1.SetToolTip(cboSource, "Choose the install source (Rufus, MCT, Ventoy, ...).");
            toolTip1.SetToolTip(btnRun, "Open provider options (if any) and run the selected tool.");
            toolTip1.SetToolTip(btnHomepage, "Open the provider's official website.");
            toolTip1.SetToolTip(btnDownload, "Download the provider binary if a direct URL is available.");
        }

        private void UpdateHint()
        {
            if (lblHint == null) return;
            var p = SelectedProvider;
            lblHint.Text = p?.Hint ?? string.Empty;
        }

        // --------------------------------------------------------------------------------
        // Provider selection helpers
        // --------------------------------------------------------------------------------
        private IInstallProvider SelectedProvider
            => cboSource?.SelectedItem as IInstallProvider;

        private LastSelections GetLast(IInstallProvider p)
        {
            if (p == null) return null;
            if (!_lastByProvider.TryGetValue(p.Id, out var last))
            {
                last = new LastSelections();
                _lastByProvider[p.Id] = last;
            }
            return last;
        }

        // --------------------------------------------------------------------------------
        // Install: run selected provider
        // --------------------------------------------------------------------------------
        private async System.Threading.Tasks.Task RunSelectedAsync()
        {
            var p = SelectedProvider;
            if (p == null) return;

            var last = GetLast(p);

            // Let provider collect options / handle itself.
            var args = p.ShowOptionsAndBuildArgs(this, last);
            if (args == null) return; // canceled or fully handled inside provider

            if (p.IsExternalTool)
            {
                // External: resolve/browse EXE as before
                var exePath = ToolHelpers.ResolveToolPath(last.LastExePath, p.ExactExeNames, p.WildcardExePatterns);
                if (exePath == null)
                {
                    using (var ofd = new OpenFileDialog
                    {
                        Title = $"Select {p.DisplayName} executable",
                        Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*"
                    })
                    {
                        try
                        {
                            var downloads = System.IO.Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                            if (System.IO.Directory.Exists(downloads)) ofd.InitialDirectory = downloads;
                        }
                        catch { }

                        if (ofd.ShowDialog(this) != DialogResult.OK) return;
                        exePath = ofd.FileName;
                        last.LastExePath = exePath;
                    }
                }

                ToolHelpers.Run(exePath, args, asAdmin: true);
            }
            else
            {
                // Native/built-in: run by command name without file picker (UseShellExecute=true)
                var cmd = (p.ExactExeNames != null && p.ExactExeNames.Length > 0)
                            ? p.ExactExeNames[0]        // e.g., "systemreset.exe"
                            : null;

                if (string.IsNullOrEmpty(cmd))
                {
                    MessageBox.Show(this, "No command specified for native provider.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ToolHelpers.Run(cmd, args, asAdmin: true);
            }
        }

        private void OpenHomepage()
        {
            var p = SelectedProvider;
            if (p == null)
                return;

            if (string.IsNullOrEmpty(p.HomepageUrl))
            {
                MessageBox.Show(this,
                    $"No homepage is defined for {p.DisplayName}.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            ToolHelpers.OpenUri(p.HomepageUrl);
        }


        private async Task DownloadProviderAsync()
        {
            var p = SelectedProvider;
            if (p == null) return;

            if (string.IsNullOrEmpty(p.DirectDownloadUrl))
            {
                MessageBox.Show(this,
                    $"Direct download is not available for {p.DisplayName}. Please visit the homepage instead.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var fileName = p.Id + ".exe"; // simple default filename
            await ToolHelpers.DownloadAsync(this, p.DirectDownloadUrl, fileName);
        }

        // --------------------------------------------------------------------------------
        // Finds a provider by its Id in the already-registered _providers list (Quick-click)
        // --------------------------------------------------------------------------------


        private IInstallProvider FindProviderById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            foreach (var p in _providers)
                if (string.Equals(p.Id, id, StringComparison.OrdinalIgnoreCase))
                    return p;
            return null;
        }

        // Selects the provider in the combo (for UI consistency) and runs it via existing pipeline
        private async System.Threading.Tasks.Task RunQuickAsync(string providerId)
        {
            var p = FindProviderById(providerId);
            if (p == null)
            {
                MessageBox.Show(this, $"Provider '{providerId}' not available.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Select in UI so hint/badges update
            if (cboSource != null)
                cboSource.SelectedItem = p;

            // Reuse your normal execution path
            await RunSelectedAsync();
        }

        // --------------------------------------------------------------------------------
        // Wires the search box to filter the providers list on-the-fly
        // --------------------------------------------------------------------------------

        private void HookSearchBox()
        {
            if (textProviderSearch == null || cboSource == null) return;

            textProviderSearch.TextChanged += (s, e) =>
            {
                var q = textProviderSearch.Text?.Trim() ?? string.Empty;
                FilterProviders(q);
            };
        }

        // Filters the combo by DisplayName/Id/Hint (case-insensitive).
        private void FilterProviders(string query)
        {
            if (cboSource == null) return;

            // filtered view on the fly
            var list = string.IsNullOrEmpty(query)
                ? _providers
                : _providers.FindAll(p =>
                      (p.DisplayName ?? "").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                   || (p.Id ?? "").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                   || (p.Hint ?? "").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

            // Rebind
            cboSource.DataSource = null;
            cboSource.DataSource = list;
            cboSource.DisplayMember = nameof(IInstallProvider.DisplayName);

            if (cboSource.Items.Count > 0) cboSource.SelectedIndex = 0;
        }

        private void textProviderSearch_Click(object sender, EventArgs e)
        {
            textProviderSearch.Clear();
        }

    }
}