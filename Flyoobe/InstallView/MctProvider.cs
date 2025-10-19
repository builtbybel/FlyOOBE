using System.Text;
using System.Windows.Forms;

namespace Flyoobe
{
    public sealed class MctProvider : IInstallProvider
    {
        public string Id => "mct";
        public string DisplayName => "Media Creation Tool (Windows 11 Version 25H2)";
        public string HomepageUrl => "https://www.microsoft.com/software-download/windows11";
        public string DirectDownloadUrl => "https://go.microsoft.com/fwlink/?linkid=2156295";
        public string[] ExactExeNames => new[] { "MediaCreationTool_Win11.exe" };
        public string[] WildcardExePatterns => new[] { "MediaCreationTool*.exe" };
        public bool IsExternalTool => true;   // needs browsing/resolving
        public bool TypicallyNeedsIso => false;

        public string Hint => "The Media Creation Tool can download and create media itself. ISO is not mandatory.";

        public string ShowOptionsAndBuildArgs(IWin32Window owner, LastSelections last)
        {
            using (var dlg = new MctOptionsDialog())
            {
                if (dlg.ShowDialog(owner) != DialogResult.OK) return null;

                // Keep GUI visible: only partial switches
                var sb = new StringBuilder();
                if (dlg.AcceptEula) sb.Append("/Eula Accept ");
                if (!string.IsNullOrWhiteSpace(dlg.SelectedArchitecture)) sb.Append("/MediaArch ").Append(dlg.SelectedArchitecture).Append(' ');
                if (!string.IsNullOrWhiteSpace(dlg.LanguageCode)) sb.Append("/MediaLangCode ").Append(dlg.LanguageCode.ToLowerInvariant()).Append(' ');
                if (dlg.RetailMode) sb.Append("/Retail ");
                if (dlg.Selfhost) sb.Append("/Selfhost ");
                return sb.ToString().Trim();
            }
        }

        // --- Provider-local dialog (no designer) ------------------------------------------------------
        private sealed class MctOptionsDialog : Form
        {
            private ComboBox cmbArch;
            private TextBox txtLang;
            private CheckBox chkEula;
            private CheckBox chkRetail;
            private CheckBox chkSelfhost;
            private Button btnOk;
            private Button btnCancel;

            public string SelectedArchitecture => (cmbArch.SelectedItem as string) ?? "x64";
            public string LanguageCode => string.IsNullOrWhiteSpace(txtLang.Text) ? "en-us" : txtLang.Text.Trim().ToLowerInvariant();
            public bool AcceptEula => chkEula.Checked;
            public bool RetailMode => chkRetail.Checked;
            public bool Selfhost => chkSelfhost.Checked;

            public MctOptionsDialog()
            {
                Text = "Media Creation Tool – Preset Options";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                ShowInTaskbar = false;
                AutoSize = true;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                Padding = new Padding(12);

                var layout = new TableLayoutPanel
                {
                    ColumnCount = 2,
                    AutoSize = true,
                    Dock = DockStyle.Fill
                };
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

                // Architecture
                layout.Controls.Add(new Label { Text = "Architecture:", AutoSize = true, Margin = new Padding(0, 6, 8, 6) }, 0, 0);
                cmbArch = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
                cmbArch.Items.AddRange(new object[] { "x64", "x86", "Both" });
                cmbArch.SelectedIndex = 0;
                layout.Controls.Add(cmbArch, 1, 0);

                // Language
                layout.Controls.Add(new Label { Text = "Language code:", AutoSize = true, Margin = new Padding(0, 6, 8, 6) }, 0, 1);
                var defLang = System.Globalization.CultureInfo.CurrentUICulture?.Name?.ToLowerInvariant() ?? "en-us";
                txtLang = new TextBox { Width = 200, Text = defLang };
                layout.Controls.Add(txtLang, 1, 1);

                // Options
                chkEula = new CheckBox { Text = "Accept EULA", Checked = true, AutoSize = true };
                chkRetail = new CheckBox { Text = "Retail mode", Checked = false, AutoSize = true };
                chkSelfhost = new CheckBox { Text = "Selfhost", Checked = false, AutoSize = true };
                var opts = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
                opts.Controls.Add(chkEula);
                opts.Controls.Add(chkRetail);
                opts.Controls.Add(chkSelfhost);
                layout.Controls.Add(new Label { Text = "Options:", AutoSize = true, Margin = new Padding(0, 6, 8, 6) }, 0, 2);
                layout.Controls.Add(opts, 1, 2);

                // Buttons
                var pnlButtons = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, AutoSize = true, Margin = new Padding(0, 12, 0, 0) };
                btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK, AutoSize = true };
                btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, AutoSize = true, Margin = new Padding(6, 0, 0, 0) };
                pnlButtons.Controls.Add(btnOk);
                pnlButtons.Controls.Add(btnCancel);
                layout.Controls.Add(pnlButtons, 0, 3);
                layout.SetColumnSpan(pnlButtons, 2);

                Controls.Add(layout);
                AcceptButton = btnOk;
                CancelButton = btnCancel;
            }
        }
    }
}