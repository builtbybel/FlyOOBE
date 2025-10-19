using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Management.Deployment;

namespace Flyoobe
{
    public partial class AppsControlView : UserControl, IView
    {
        public string ViewTitle => "Manage Installed Apps";

        private Dictionary<string, string> _appDirectory = new Dictionary<string, string>();
        private string currentSearchTerm = string.Empty;
        private string activePatternFile = "FlyOOBE_Profile_Full.txt";

        public AppsControlView()
        {
            InitializeComponent();
        }

        private async void AppsControlView_Load(object sender, EventArgs e)
        {
            InitializeProfileDropdown();
            await ApplyProfileChange();
        }

        /// <summary>
        /// Initializes the cleanup profile selector.
        /// </summary>
        private void InitializeProfileDropdown()
        {
            profileDropdown.Items.Clear();
            profileDropdown.Items.Add("Full Microsoft Experience – everything included");
            profileDropdown.Items.Add("Balanced – essentials plus Store (recommended)");
            profileDropdown.Items.Add("Minimal Windows – only essentials, zero bloat");
            profileDropdown.Items.Add("Community (from GitHub)");

            profileDropdown.SelectedIndex = 1; // Default: Balanced
            profileDropdown.SelectedIndexChanged += async (s, e) => await ApplyProfileChange();
        }

        /// <summary>
        /// Called when the cleanup profile is changed.
        /// Updates label text, sets pattern file, and reloads the apps.
        /// </summary>
        private async Task ApplyProfileChange()
        {
            string profileName = string.Empty;
            string baseText = "Select the apps you want to uninstall. Use the dropdown to pick a cleanup profile.\n";

            switch (profileDropdown.SelectedIndex)
            {
                case 0: // Full
                    activePatternFile = "FlyOOBE_Profile_Full.txt";
                    profileName = "Full Microsoft Experience – everything included.";
                    break;

                case 1: // Balanced
                    activePatternFile = "FlyOOBE_Profile_Balanced.txt";
                    profileName = "Balanced – essentials plus Store (recommended).";
                    break;

                case 2: // Minimal
                    activePatternFile = "FlyOOBE_Profile_Minimal.txt";
                    profileName = "Minimal Windows – only essentials, zero bloat.";
                    break;

                case 3: // Community
                    await LoadCommunityProfileAsync();
                    return;
            }

            // --- Load apps after profile is set ---
            await LoadAndDisplayApps();

            // --- Update label AFTER apps are loaded ---
            int count = dgvApps.Rows.Count;
            lblStatus.Text = $"{baseText}Currently showing: {profileName} Loaded {count} app(s) from profile: {Path.GetFileNameWithoutExtension(activePatternFile)}.";
        }

        /// <summary>
        /// Downloads and loads the community cleanup profile from GitHub.
        /// </summary>
        private async Task LoadCommunityProfileAsync()
        {
            string url = "https://raw.githubusercontent.com/builtbybel/Flyoobe/main/assets/Flyoobe_Profile_Community.txt";
            string appDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app");
            string localPath = Path.Combine(appDir, "Flyoobe_Profile_Community.txt");

            try
            {
                var result = MessageBox.Show(
                    "Download the Community Cleanup Profile from GitHub?\n\n" +
                    "This profile contains the most commonly removed apps, curated by the community.",
                    "Community Profile",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Directory.CreateDirectory(appDir);
                    using (var client = new System.Net.WebClient())
                        await client.DownloadFileTaskAsync(new Uri(url), localPath);

                    activePatternFile = Path.GetFileName(localPath);
                    lblStatus.Text = "Community Profile active – showing common bloatware.";
                    await LoadAndDisplayApps();
                }
                else
                {
                    lblStatus.Text = "Community Profile not applied.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Failed to load Community Profile:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads installed UWP apps and applies filtering based on the selected pattern file.
        /// </summary>
        private async Task LoadAndDisplayApps()
        {
            dgvApps.Rows.Clear();
            var (bloatware, whitelist, scanAll) = LoadNativeAppPatterns();
            await LoadInstalledAppsAsync();

            var filtered = _appDirectory
                .Where(app =>
                    !whitelist.Any(w => app.Key.ToLower().Contains(w)) &&
                    (scanAll || bloatware.Any(b => app.Key.ToLower().Contains(b))) &&
                    (string.IsNullOrEmpty(currentSearchTerm) || app.Key.ToLower().Contains(currentSearchTerm)))
                .ToList();

            RefreshAppList(filtered);
        }

        /// <summary>
        /// Loads all installed UWP apps into internal dictionary.
        /// </summary>
        private async Task LoadInstalledAppsAsync()
        {
            _appDirectory.Clear();
            var pm = new PackageManager();

            var packages = await Task.Run(() =>
                pm.FindPackagesForUserWithPackageTypes(string.Empty, PackageTypes.Main));

            foreach (var p in packages)
            {
                string name = p.Id.Name;
                string fullName = p.Id.FullName;

                if (!_appDirectory.ContainsKey(name))
                    _appDirectory[name] = fullName;
            }
        }

        /// <summary>
        /// Updates DataGridView with app name, checkbox and remove button.
        /// </summary>
        private void RefreshAppList(IEnumerable<KeyValuePair<string, string>> apps)
        {
            dgvApps.Rows.Clear();

            foreach (var app in apps)
            {
                int rowIndex = dgvApps.Rows.Add(false, app.Key, "Remove");
                dgvApps.Rows[rowIndex].Tag = app.Value;
            }

            lblStatus.Text = $"{apps.Count()} apps listed.";
        }

        /// <summary>
        /// Reads cleanup patterns from the current profile file.
        /// </summary>
        private (string[] bloatware, string[] whitelist, bool scanAll) LoadNativeAppPatterns()
        {
            var bloatware = new List<string>();
            var whitelist = new List<string>();
            bool scanAll = false;

            string path = GetActivePatternFilePath(activePatternFile);
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                return (Array.Empty<string>(), Array.Empty<string>(), false);

            foreach (var rawLine in File.ReadLines(path))
            {
                string line = rawLine.Split('#')[0].Trim();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line == "*" || line == "*.*")
                {
                    scanAll = true;
                    continue;
                }

                if (line.StartsWith("!"))
                    whitelist.Add(line.Substring(1).Trim().ToLowerInvariant());
                else
                    bloatware.Add(line.ToLowerInvariant());
            }

            return (bloatware.ToArray(), whitelist.ToArray(), scanAll);
        }

        /// <summary>
        /// Gets the path to the selected profile pattern file inside /app directory.
        /// </summary>

        private string GetActivePatternFilePath(string fileName, bool ensureExists = false)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string appDir = Path.Combine(baseDir, "app");
            string path = Path.Combine(appDir, fileName);

            if (ensureExists && !File.Exists(path))
            {
                Directory.CreateDirectory(appDir);
                File.WriteAllText(path, "# Add your app detection patterns here\n");
            }

            return path;
        }

        /// <summary>
        /// Handles clicks on the "Remove" button inside the DataGridView.
        /// Immediately removes the selected app and refreshes the list afterward.
        /// </summary>
        private async void dgvApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Check if "Remove" button column was clicked
            if (dgvApps.Columns[e.ColumnIndex].Name == "ActionColumn")
            {
                var row = dgvApps.Rows[e.RowIndex];
                string appName = row.Cells["NameColumn"].Value?.ToString();
                string fullName = row.Tag?.ToString();

                if (string.IsNullOrEmpty(fullName)) return;

                // Start removal
                lblStatus.Text = $"Removing {appName}...";
                bool success = await UninstallAppAsync(fullName);

                // Update status text
                lblStatus.Text = success
                    ? $"{appName} successfully removed."
                    : $"Failed to remove {appName}.";

                // Automatically refresh list after removal
                await LoadAndDisplayApps();
            }
        }

        /// <summary>
        /// Uninstalls an app by its full package name.
        /// </summary>
        private async Task<bool> UninstallAppAsync(string fullName)
        {
            try
            {
                var pm = new PackageManager();
                var operation = pm.RemovePackageAsync(fullName);

                var resetEvent = new ManualResetEvent(false);
                operation.Completed = (o, s) => resetEvent.Set();

                await Task.Run(() => resetEvent.WaitOne());
                return operation.Status == AsyncStatus.Completed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uninstalling:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private async void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            var selected = dgvApps.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["SelectColumn"].Value))
                .ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("Please select at least one app.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            progressBar.Visible = true;
            progressBar.Maximum = selected.Count;
            progressBar.Value = 0;

            foreach (var row in selected)
            {
                string appName = row.Cells["NameColumn"].Value.ToString();
                string fullName = row.Tag.ToString();

                lblStatus.Text = $"Removing {appName}...";
                bool success = await UninstallAppAsync(fullName);
                progressBar.PerformStep();

                if (!success)
                    lblStatus.Text = $"Failed to remove {appName}";
                else
                    lblStatus.Text = $"Removed {appName}";

                await Task.Delay(150);
            }

            progressBar.Visible = false;
            lblStatus.Text = "Batch removal completed.";
            await LoadAndDisplayApps();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            currentSearchTerm = textSearch.Text.Trim().ToLower();
            _ = LoadAndDisplayApps();
        }

        private void textSearch_Click(object sender, EventArgs e) => textSearch.Clear();

        /// <summary>
        /// Reloads the current view with the selected profile.
        /// </summary>
        public async void RefreshView()
        {
            currentSearchTerm = string.Empty;
            await ApplyProfileChange();
            lblStatus.Text = "Ready.";
        }

        /// <summary>
        /// Selects or deselects all apps in the DataGridView when the master checkbox is toggled.
        /// </summary>
        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAll = checkSelectAll.Checked;

            foreach (DataGridViewRow row in dgvApps.Rows)
            {
                if (row.Cells["SelectColumn"] is DataGridViewCheckBoxCell checkCell)
                {
                    checkCell.Value = checkAll;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = GetActivePatternFilePath(activePatternFile, ensureExists: true);
                Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening profile file:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}