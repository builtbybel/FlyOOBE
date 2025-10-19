using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace Flyoobe
{
    public partial class AboutForm : Form

    {    // Accent color (Microsoft blue)
        private Color accentColor = Color.FromArgb(0, 120, 212);
        private Color backgroundTop = Color.FromArgb(241, 231, 222);
        private Color backgroundBottom = Color.FromArgb(230, 240, 240, 240);

        public AboutForm()
        {
            InitializeComponent();

            // Form properties
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            // Close button
            btnClose.Text = "\uE8BB";
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.ForeColor = Color.Gray;
            btnClose.Font = new Font("Segoe Fluent Icons", 14f);

            linkAppVersion.Text = $"You have FlyOOBE version {Program.GetAppVersion()}\n(Fetching updates...)";
            linkAppVersion.LinkColor = accentColor;
            linkAppVersion.ActiveLinkColor = Color.MediumVioletRed;
            chkDonated.Checked = DonationHelper.HasDonated();
        }

        private async void AboutForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            await CheckForUpdate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int r = 90; // corner radius
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // rounded path (for drawing only)
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.Left, rect.Top, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Top, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // gradient background
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(rect, backgroundTop, backgroundBottom, 90f))
                    e.Graphics.FillPath(brush, path);

                // rounded border
                using (var pen = new Pen(Color.FromArgb(80, 0, 0, 0), 1))
                    e.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int r = 20;
            var rect = new Rectangle(0, 0, Width, Height);

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.Left, rect.Top, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Top, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                this.Region?.Dispose();
                this.Region = new Region(path);
            }
        }

        private void chkDonated_CheckedChanged(object sender, EventArgs e)
        {
            DonationHelper.SetDonationStatus(chkDonated.Checked);
        }

        private Version NormalizeVersionString(string version)
        {
            // Split by dot
            var parts = version.Split('.');
            // Add missing zeros to have at least 3 parts
            while (parts.Length < 3)
            {
                version += ".0";
                parts = version.Split('.');
            }
            return Version.Parse(version);
        }

        private async Task CheckForUpdate()
        {
            const string latestReleaseUrl = "https://github.com/builtbybel/Flyoobe/releases/latest";

            try
            {
                using (var handler = new HttpClientHandler() { AllowAutoRedirect = true })
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("FlyoobeUpdateChecker");

                    // GitHub /latest will redirect to /tag/vX.Y.Z
                    var response = await client.GetAsync(latestReleaseUrl);
                    response.EnsureSuccessStatusCode();

                    // After redirects, this contains the "real" release page
                    var finalUri = response.RequestMessage.RequestUri.ToString();

                    // Example: https://github.com/builtbybel/Flyoobe/releases/tag/v1.2.3
                    string latestTag = finalUri.Substring(finalUri.LastIndexOf('/') + 1);

                    if (latestTag.StartsWith("v"))
                        latestTag = latestTag.Substring(1);

                    Version latestVersion = NormalizeVersionString(latestTag);
                    Version currentVersion = NormalizeVersionString(Program.GetAppVersion());

                    if (latestVersion > currentVersion)
                    {
                        UpdateLabel($"Update available: v{latestVersion}", clickable: true);
                    }
                    else if (latestVersion == currentVersion)
                    {
                        UpdateLabel($"FlyOOBE version {currentVersion} (up-to-date)");
                    }
                    else
                    {
                        // User has a nightly/dev or newer version
                        UpdateLabel($"FlyOOBE version {currentVersion} (dev version?)");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLabel($"Update check failed: {ex.Message}");
            }
        }

        // Helper method to update label safely on UI thread
        private void UpdateLabel(string text, bool clickable = false)
        {
            // Update label text
            linkAppVersion.Text = text;

            // If clickable,
            // show bold ; underline ; make cursor a hand
            if (clickable)
            {
                linkAppVersion.Font = new Font(linkAppVersion.Font, FontStyle.Bold | FontStyle.Underline);
                linkAppVersion.Cursor = Cursors.Hand;
            }
            else
            {
                // Otherwise normal font and default cursor
                linkAppVersion.Font = new Font(linkAppVersion.Font, FontStyle.Regular);
                linkAppVersion.Cursor = Cursors.Default;
            }
        }

        private void linkAppVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/builtbybel/Flyoobe/releases/latest",
                UseShellExecute = true
            });
        }

        private void btnGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/Flyoobe");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG",
                UseShellExecute = true
            });
        }
    }
}