using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class DefaultsControlView : UserControl, IView
    {
        public string ViewTitle => "Set Default Browser";

        // winget IDs for common browsers
        private readonly Dictionary<string, string> WingetIds = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Google Chrome",   "Google.Chrome" },
            { "Mozilla Firefox", "Mozilla.Firefox" },
            { "Brave",           "Brave.Brave" },
            { "Opera",           "Opera.Opera" },
            { "Vivaldi",         "Vivaldi.Vivaldi" },
            { "Zen Browser",     "Zen-Team.Zen-Browser" }
        };

        public DefaultsControlView()
        {
            InitializeComponent();
            LoadRegisteredBrowsers();

            if (comboDownload != null)
            {
                comboDownload.Items.Clear();
                comboDownload.Items.AddRange(new object[]
                {
                    "Google Chrome", "Mozilla Firefox", "Brave", "Opera", "Vivaldi", "Zen Browser"
                });
                comboDownload.SelectedIndex = 0;
            }

            if (panelDownload != null) panelDownload.Visible = false;
        }

        /// <summary>
        /// Load installed browsers from registry and populate the comboBrowsers dropdown.
        /// </summary>
        private void LoadRegisteredBrowsers()
        {
            comboBrowsers.Items.Clear();

            using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\RegisteredApplications"))
            {
                if (key != null)
                {
                    foreach (var appName in key.GetValueNames())
                    {
                        string display = MapBrowserName(appName);
                        if (!string.IsNullOrEmpty(display))
                            comboBrowsers.Items.Add(new ComboItem(display, appName));
                    }
                }
            }

            if (comboBrowsers.Items.Count == 0)
                comboBrowsers.Items.Add(new ComboItem("Microsoft Edge", "Microsoft Edge"));

            comboBrowsers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBrowsers.SelectedIndex = 0;
        }

        /// <summary>
        /// Map raw registry application name to a friendly browser name.
        /// </summary>
        private string MapBrowserName(string appName)
        {
            var lower = appName.ToLower();

            if (appName.Equals("Microsoft Edge", StringComparison.OrdinalIgnoreCase)) return "Microsoft Edge";
            if (appName.Equals("Google Chrome", StringComparison.OrdinalIgnoreCase)) return "Google Chrome";
            if (lower.Contains("brave")) return "Brave";
            if (lower.Contains("opera")) return "Opera";
            if (lower.Contains("vivaldi")) return "Vivaldi";

            if (appName.StartsWith("Firefox-", StringComparison.OrdinalIgnoreCase))
            {
                if (appName.Contains("308046B0AF4A39CB")) return "Mozilla Firefox";
                if (appName.Contains("F0DC299D809B9700")) return "Zen Browser";
                return "Firefox (variant)";
            }

            return null;
        }

        /// <summary>
        /// Opens Windows Settings for the selected browser.
        /// </summary>
        private async void btnSetDefaultBrowser_Click(object sender, EventArgs e)
        {
            if (comboBrowsers.SelectedItem is ComboItem item)
            {
                string realAppName = item.Value;

                // Give feedback immediately
                lblStatus.Text = "Opening Settings, please wait...";
                btnSetDefaultBrowser.Enabled = false;

                try
                {
                    Process.Start("ms-settings:defaultapps?registeredAppMachine=" +
                                  Uri.EscapeDataString(realAppName));
                }
                catch
                {
                    Process.Start("ms-settings:defaultapps");
                }

                // Small delay before resetting UI
                await Task.Delay(3000);
                lblStatus.Text = "Choose default browser";
                btnSetDefaultBrowser.Enabled = true;
            }
        }

        public void RefreshView()
        {
            LoadRegisteredBrowsers();
        }

        /// <summary>
        /// Helper to run winget with optional elevation.
        /// </summary>
        private void RunWinget(string args, bool elevate = false)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = args,
                    UseShellExecute = true
                };
                if (elevate) psi.Verb = "runas";
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not start winget: " + ex.Message);
            }
        }

        private static string Quote(string s) => "\"" + s.Replace("\"", "\"\"") + "\"";

        /// <summary>
        /// Handles the Install button click.
        /// Uses winget to install the selected browser and gives simple feedback.
        /// </summary>
        private async void btnInstall_Click(object sender, EventArgs e)
        {
            if (comboDownload?.SelectedItem == null) return;

            string name = comboDownload.SelectedItem.ToString();
            string id;
            if (!WingetIds.TryGetValue(name, out id))
            {
                // If browser is not in our known WingetIds, just run a search
                RunWinget("search " + Quote(name));
                return;
            }

            lblStatus.Text = $"Installing {name} via winget...";
            btnInstall.Enabled = false;

            // Start the installation
            RunWinget($"install --id {id} -e --silent", elevate: checkRunAsAdmin != null && checkRunAsAdmin.Checked);

            // cosmetic feedback only
            await Task.Delay(4000);

            lblStatus.Text = "Choose your browser";
            btnInstall.Enabled = true;
        }


        /// <summary>
        /// Show or hide the download panel when checkbox is toggled.
        /// </summary>
        private void checkNeedOtherBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (panelDownload != null) panelDownload.Visible = checkNeedOtherBrowser.Checked;
        }

        /// <summary>
        /// Helper class for ComboBox items (display vs. real value).
        /// </summary>
        private class ComboItem
        {
            public string Text { get; }
            public string Value { get; }

            public ComboItem(string text, string value)
            { Text = text; Value = value; }

            public override string ToString() => Text;
        }
    }
}