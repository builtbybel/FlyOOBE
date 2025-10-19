using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Flyoobe
{
    public sealed class RufusProvider : IInstallProvider
    {
        public string Id => "rufus";
        public string DisplayName => "Rufus";
        public string HomepageUrl => "https://rufus.ie";
        public string DirectDownloadUrl => "https://github.com/pbatard/rufus/releases/download/v4.9/rufus-4.9.exe"; // keep homepage
        public string[] ExactExeNames => new[] { "rufus.exe" };
        public string[] WildcardExePatterns => new[] { "rufus*.exe" };
        public bool IsExternalTool => true;   // needs browsing/resolving
        public bool TypicallyNeedsIso => true;

        public string Hint => "Rufus requires you to provide a Windows ISO file. It will create a bootable USB stick.";

        public string ShowOptionsAndBuildArgs(IWin32Window owner, LastSelections last)
        {
            // Ask / ensure ISO first
            var isoPath = EnsureIso(owner, last);
            if (isoPath == null) return null; // user cancelled

            // Show provider-local dialog and build CLI args
            using (var dlg = new RufusOptionsDialog(System.Globalization.CultureInfo.CurrentUICulture?.Name ?? "en-US"))
            {
                if (dlg.ShowDialog(owner) != DialogResult.OK) return null;

                // Build CLI: -g -i -l -f -x -w
                var sb = new StringBuilder();
                sb.Append("-g ");
                sb.Append("-i \"").Append(isoPath).Append("\" ");
                if (!string.IsNullOrWhiteSpace(dlg.SelectedLocale)) sb.Append("-l ").Append(dlg.SelectedLocale).Append(' ');
                if (!string.IsNullOrWhiteSpace(dlg.SelectedFilesystem)) sb.Append("-f ").Append(dlg.SelectedFilesystem).Append(' ');
                if (dlg.ExtraDevices) sb.Append("-x ");
                if (dlg.WaitTensOfSeconds > 0) sb.Append("-w ").Append(dlg.WaitTensOfSeconds).Append(' ');
                return sb.ToString().Trim();
            }
        }

        private static string EnsureIso(IWin32Window owner, LastSelections last)
        {
            // Reuse last ISO if available
            if (!string.IsNullOrEmpty(last.LastIsoPath) && File.Exists(last.LastIsoPath))
            {
                var res = MessageBox.Show(owner, "Use last selected ISO?\n\n" + last.LastIsoPath,
                    "Rufus", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) return null;
                if (res == DialogResult.Yes) return last.LastIsoPath;
            }

            // Ask for ISO
            using (var ofd = new OpenFileDialog
            {
                Title = "Select Windows ISO",
                Filter = "ISO (*.iso)|*.iso|All files (*.*)|*.*"
            })
            {
                if (ofd.ShowDialog(owner) != DialogResult.OK) return null;
                last.LastIsoPath = ofd.FileName;
                return ofd.FileName;
            }
        }

        // --- Provider-local dialog (no Designer needed) --------------------------------
        // Keeping this dialog private to avoid leaking UI details outside the provider.
        private sealed class RufusOptionsDialog : Form
        {
            private ComboBox cmbFilesystem;
            private ComboBox cmbLocale;
            private CheckBox chkExtra;
            private NumericUpDown numWait;
            private Button btnOk;
            private Button btnCancel;

            public string SelectedFilesystem => (cmbFilesystem.SelectedItem as string) ?? "ntfs";
            public string SelectedLocale => string.IsNullOrWhiteSpace(cmbLocale.Text) ? "en-US" : cmbLocale.Text.Trim();
            public bool ExtraDevices => chkExtra.Checked;
            public int WaitTensOfSeconds => (int)numWait.Value;

            public RufusOptionsDialog(string defaultLocale)
            {
                // Minimal, self-contained WinForms dialog
                Text = "Rufus options";
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
                    RowCount = 5,
                    AutoSize = true,
                    Dock = DockStyle.Fill
                };
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                // Filesystem
                layout.Controls.Add(new Label { Text = "Filesystem:", AutoSize = true, Margin = new Padding(0, 6, 8, 6) }, 0, 0);
                cmbFilesystem = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
                cmbFilesystem.Items.AddRange(new object[] { "ntfs", "fat32", "exfat" });
                cmbFilesystem.SelectedIndex = 0;
                layout.Controls.Add(cmbFilesystem, 1, 0);

                // Locale
                layout.Controls.Add(new Label { Text = "Locale:", AutoSize = true, Margin = new Padding(0, 6, 8, 6) }, 0, 1);
                cmbLocale = new ComboBox { DropDownStyle = ComboBoxStyle.DropDown, Width = 160 };
                cmbLocale.Items.AddRange(new object[] { "en-US", "de-DE", "fr-FR", "it-IT", "es-ES" });
                if (!string.IsNullOrEmpty(defaultLocale) && !cmbLocale.Items.Contains(defaultLocale))
                    cmbLocale.Items.Insert(0, defaultLocale);
                cmbLocale.Text = string.IsNullOrEmpty(defaultLocale) ? "en-US" : defaultLocale;
                layout.Controls.Add(cmbLocale, 1, 1);

                // Extra devices
                layout.Controls.Add(new Label { Text = "List extra devices (-x):", AutoSize = true, Margin = new Padding(0, 6, 8, 6) }, 0, 2);
                chkExtra = new CheckBox { Checked = false, AutoSize = true };
                layout.Controls.Add(chkExtra, 1, 2);

                // Wait
                layout.Controls.Add(new Label { Text = "Wait (-w) (tens of seconds):", AutoSize = true, Margin = new Padding(0, 6, 8, 6) }, 0, 3);
                numWait = new NumericUpDown { Minimum = 0, Maximum = 120, Value = 0, Width = 80 };
                layout.Controls.Add(numWait, 1, 3);

                // Buttons
                var panelButtons = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, AutoSize = true, Dock = DockStyle.Fill, Margin = new Padding(0, 12, 0, 0) };
                btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK, AutoSize = true };
                btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, AutoSize = true, Margin = new Padding(6, 0, 0, 0) };
                panelButtons.Controls.Add(btnOk);
                panelButtons.Controls.Add(btnCancel);
                layout.Controls.Add(panelButtons, 0, 4);
                layout.SetColumnSpan(panelButtons, 2);

                Controls.Add(layout);
                AcceptButton = btnOk;
                CancelButton = btnCancel;
            }
        }
    }
}