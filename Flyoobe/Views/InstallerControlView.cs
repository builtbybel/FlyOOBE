using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class InstallerControlView : UserControl, IView, IHasSearch
    {
        private bool autoAcceptAgreements = false;

        // List of (DisplayName, WingetId)
        private List<(string Name, string Id)> allApps;

        public InstallerControlView()
        {
            InitializeComponent();

            // Check if Winget is installed
            if (!IsWingetInstalled())
            {
                MessageBox.Show(
                    "Winget is not installed. Please install 'App Installer' from the Microsoft Store first.",
                    "Winget Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnInstall.Enabled = false;
                return;
            }

            InitializeAppList();
        }

        /// <summary>
        /// Predefines a list of commonly used apps with their Winget IDs.
        /// </summary>
        private void InitializeAppList()
        {
            allApps = new List<(string, string)>
            {
                ("7-Zip", "7zip.7zip"),
                ("VLC Media Player", "VideoLAN.VLC"),
                ("Visual Studio Code", "Microsoft.VisualStudioCode"),
                ("Discord", "Discord.Discord"),
                ("Notepad++", "Notepad++.Notepad++"),
                ("Slack", "SlackTechnologies.Slack"),
                ("Microsoft Teams", "Microsoft.Teams"),
                ("Microsoft PowerToys", "Microsoft.PowerToys"),
                ("Paint.NET", "dotPDNLLC.paintdotnet"),
                ("IrfanView", "IrfanSkiljan.IrfanView"),
                ("Everything Search", "voidtools.Everything"),
                ("BleachBit", "BleachBit.BleachBit"),
                ("KeePass", "KeePass.KeePass"),
                ("StartAllBack", "StartIsBack.StartAllBack"),
                ("Git", "Git.Git"),
                ("GitHub Desktop", "GitHub.GitHubDesktop"),
            };

            RefreshAppList(allApps);
        }

        /// <summary>
        /// Checks if Winget is installed on this system.
        /// </summary>
        private bool IsWingetInstalled()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("winget", "--version")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit(3000);
                    string output = process.StandardOutput.ReadToEnd();
                    return output.Contains(".");
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Handles the Install button click — installs all checked apps by their Winget IDs.
        /// </summary>
        private async void btnInstall_Click(object sender, EventArgs e)
        {
            var selectedApps = dgvApps.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value))
                .Select(r => r.Cells["IdColumn"].Value.ToString())
                .ToList();

            if (selectedApps.Count == 0)
            {
                lblStatus.Text = "No apps selected.";
                return;
            }

            var result = MessageBox.Show(
                "Automatically accept all license agreements?",
                "Confirm License Agreements",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            autoAcceptAgreements = result == DialogResult.Yes;

            btnInstall.Enabled = false;
            dgvApps.Enabled = false;

            progressBar.Visible = true;
            progressBar.Maximum = selectedApps.Count;
            progressBar.Value = 0;
            progressBar.Step = 1; // one step per removed app

            foreach (string appId in selectedApps)
            {
                lblStatus.Text = $"Installing {appId}...";
                await Task.Run(() => RunWingetCommand("install", appId));
                progressBar.Invoke((Action)(() => progressBar.PerformStep()));
            }

            lblStatus.Text = "Installation complete.";
            btnInstall.Enabled = true;

            dgvApps.Enabled = true;
            progressBar.Visible = false;
        }

        /// <summary>
        /// Runs a Winget command (install/upgrade) for the specified app ID.
        /// </summary>
        private void RunWingetCommand(string command, string appId)
        {
            string extraArgs = autoAcceptAgreements
                ? "--accept-package-agreements --accept-source-agreements"
                : "";

            // command = "install" or "upgrade"
            ProcessStartInfo psi = new ProcessStartInfo("winget",
                $"{command} --id \"{appId}\" -e --silent --source winget {extraArgs}")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi, EnableRaisingEvents = true })
            {
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        UpdateStatusSafe(e.Data);
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        UpdateStatusSafe("[Error] " + e.Data);
                        Logger.Log(e.Data, LogLevel.Error);
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Updates the status label safely across threads.
        /// </summary>
        private void UpdateStatusSafe(string message)
        {
            if (lblStatus.InvokeRequired)
                lblStatus.Invoke((Action)(() => lblStatus.Text = message));
            else
                lblStatus.Text = message;
        }

        /// <summary>
        /// Applies global search input.
        /// </summary>
        public void OnGlobalSearchChanged(string text)
        {
            string filter = (text ?? "").Trim().ToLowerInvariant();

            var filtered = allApps
                .Where(a => a.Name.ToLower().Contains(filter) || a.Id.ToLower().Contains(filter));

            RefreshAppList(filtered);
        }

        /// <summary>
        /// Updates the checkedListBox with readable "Name (WingetID)" entries.
        /// </summary>
        private void RefreshAppList(IEnumerable<(string Name, string Id)> apps)
        {
            dgvApps.Rows.Clear();
            foreach (var app in apps)
            {
                dgvApps.Rows.Add(false, app.Name, app.Id);
            }
        }

        /// <summary>
        /// Clears selection and resets status label.
        /// </summary>
        public void RefreshView()
        {
            RefreshAppList(allApps);
            lblStatus.Text = "Ready.";
        }

        /// <summary>
        /// Opens a small dialog that allows the user to search for apps in Winget manually,
        /// then enter an app ID to install directly.
        /// </summary>
        private void linkInstallById_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var dialog = new InputDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string appId = dialog.EnteredId.Trim();

                    if (string.IsNullOrEmpty(appId))
                    {
                        MessageBox.Show("No Winget ID entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    lblStatus.Text = $"Installing {appId}...";
                    _ = Task.Run(() => RunWingetCommand("install", appId));
                }
            }
        }

        private async void dgvApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string appId = dgvApps.Rows[e.RowIndex].Cells["IdColumn"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(appId)) return;

            string columnName = dgvApps.Columns[e.ColumnIndex].HeaderText;

            if (columnName == "Install")
            {
                lblStatus.Text = $"Installing {appId}...";
                Logger.Log($"Installing {appId}...", LogLevel.Info);
                await Task.Run(() => RunWingetCommand("install", appId));
                lblStatus.Text = $"{appId} installed.";
            }
            else if (columnName == "Update")
            {
                lblStatus.Text = $"Checking for updates for {appId}...";
                Logger.Log($"Updating {appId}...", LogLevel.Info);
                await Task.Run(() => RunWingetCommand("upgrade", appId));
                lblStatus.Text = $"{appId} updated (if an update was available).";
            }
        }
    }
}

/// <summary>
/// Input dialog for manual Winget installation.
/// Lets the user search in Winget Terminal and then install by ID.
/// </summary>

public class InputDialog : Form
{
    private readonly TextBox txtSearch;
    private readonly TextBox txtInput;
    private readonly Button btnSearch;
    private readonly Button btnOk;
    private readonly Button btnCancel;
    private readonly Label lblInfo;
    private readonly GroupBox grpSearch;
    private readonly GroupBox grpInstall;

    private const string PlaceholderSearch = "Enter app name (e.g. chrome)";
    private const string PlaceholderId = "Enter Winget ID (e.g. Google.Chrome)";

    public string EnteredId => txtInput.Text.Trim();

    public InputDialog()
    {
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScaleDimensions = new SizeF(96F, 96F);

        Text = "Manual Winget Installation";
        Font = SystemFonts.MessageBoxFont;
        BackColor = SystemColors.Control;
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(420, 260);

        // === Info ===
        lblInfo = new Label
        {
            Text = "① Enter a keyword to search in Winget.\n" +
                   "② Winget will open and show results.\n" +
                   "③ Copy the found ID below and click Install.",
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 55,
            TextAlign = ContentAlignment.MiddleLeft
        };
        Controls.Add(lblInfo);

        // === Search Group ===
        grpSearch = new GroupBox
        {
            Text = "Search in Winget",
            Dock = DockStyle.Top,
            Height = 80,
            Padding = new Padding(10)
        };
        Controls.Add(grpSearch);

        // === Layout: Textbox + Button
        var searchLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            AutoSize = true
        };
        searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        grpSearch.Controls.Add(searchLayout);

        txtSearch = new TextBox
        {
            Text = PlaceholderSearch,
            ForeColor = SystemColors.GrayText,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 6, 0)
        };
        txtSearch.GotFocus += (s, e) => ClearPlaceholder(txtSearch, PlaceholderSearch);
        txtSearch.LostFocus += (s, e) => RestorePlaceholder(txtSearch, PlaceholderSearch);

        // Search Button
        btnSearch = new Button
        {
            Text = "&Search...",
            AutoSize = true
        };
        btnSearch.Click += (s, e) => OpenWingetTerminal(txtSearch.Text);

        searchLayout.Controls.Add(txtSearch, 0, 0);
        searchLayout.Controls.Add(btnSearch, 1, 0);

        grpSearch.Controls.Add(searchLayout);

        // === Install Group ===
        grpInstall = new GroupBox
        {
            Text = "Install by ID",
            Dock = DockStyle.Top,
            Height = 80,
            Padding = new Padding(10)
        };
        Controls.Add(grpInstall);

        txtInput = new TextBox
        {
            Text = PlaceholderId,
            ForeColor = SystemColors.GrayText,
            Dock = DockStyle.Fill
        };
        txtInput.GotFocus += (s, e) => ClearPlaceholder(txtInput, PlaceholderId);
        txtInput.LostFocus += (s, e) => RestorePlaceholder(txtInput, PlaceholderId);

        grpInstall.Controls.Add(txtInput);

        // === Bottom Buttons ===
        var pnlButtons = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 40,
        };
        Controls.Add(pnlButtons);

        btnOk = new Button
        {
            Text = "&Install",
            DialogResult = DialogResult.OK,
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
            AutoSize = true
        };

        btnCancel = new Button
        {
            Text = "Cancel",
            DialogResult = DialogResult.Cancel,
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
            AutoSize = true
        };

        // Align bottom buttons like Windows dialogs
        btnCancel.SetBounds(ClientSize.Width - 90, 8, 75, 25);
        btnOk.SetBounds(ClientSize.Width - 170, 8, 75, 25);
        pnlButtons.Controls.Add(btnOk);
        pnlButtons.Controls.Add(btnCancel);

        AcceptButton = btnOk;
        CancelButton = btnCancel;
    }

    // === Placeholder handling ===
    private void ClearPlaceholder(TextBox box, string placeholder)
    {
        if (box.Text == placeholder)
        {
            box.Clear();
            box.ForeColor = SystemColors.WindowText;
        }
    }

    private void RestorePlaceholder(TextBox box, string placeholder)
    {
        if (string.IsNullOrWhiteSpace(box.Text))
        {
            box.Text = placeholder;
            box.ForeColor = SystemColors.GrayText;
        }
    }

    // === Winget Terminal ===
    private void OpenWingetTerminal(string query)
    {
        if (string.IsNullOrWhiteSpace(query) || query == PlaceholderSearch)
        {
            MessageBox.Show("Please enter a search term first.",
                "Missing Search Term", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            string sanitized = query.Replace("\"", "").Trim();
            bool useCmd = false;

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "wt.exe",
                    Arguments = "echo",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                })?.Kill();
            }
            catch { useCmd = true; }

            Process.Start(new ProcessStartInfo
            {
                FileName = useCmd ? "cmd.exe" : "wt.exe",
                Arguments = useCmd
                    ? $"/k winget search {sanitized}"
                    : $"cmd /k \"winget search {sanitized}\"",
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open Winget terminal:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}