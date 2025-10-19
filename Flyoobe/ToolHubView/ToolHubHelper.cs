using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe.ToolHub
{
    /// <summary>
    /// Provides helper methods for installing and managing extension scripts (.ps1).
    /// </summary>
    public static class ExtensionsHelper
    {
        /// <summary>
        /// Switch the current view to the Extensions page (ToolHubControlView).
        /// </summary>
        public static void SwitchToExtensionsView(ViewNavigator navigator)
        {
            if (navigator == null) return;   // safeguard
            navigator.ShowView("Extensions");
        }

        /// <summary>
        /// Refresh the ToolHubControlView
        /// </summary>
        /// <param name="navigator"></param>
        public static void SwitchAndRefreshToExtensionsView(ViewNavigator navigator)
        {
            if (navigator == null) return;

            navigator.ShowView("Extensions");

            // Only refresh if the current view is ToolHubControlView
            if (navigator.CurrentView is ToolHubControlView extView)
            {
                extView.RefreshView();
            }
        }

        /// <summary>
        /// Install an extension from a direct .ps1 URL.
        /// </summary>
        public static async Task InstallFromUrlAsync(IWin32Window owner, ViewNavigator navigator = null)
        {
            using (var dlg = new InputDialog("Install from URL", "Paste a direct .ps1 URL:"))
            {
                if (dlg.ShowDialog(owner) != DialogResult.OK) return;
                var url = dlg.InputText?.Trim();

                if (string.IsNullOrWhiteSpace(url) || !url.EndsWith(".ps1", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(owner, "Please provide a direct link to a .ps1 file.", "Invalid URL",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string content;
                    using (var hc = new HttpClient())
                        content = await hc.GetStringAsync(url);

                    if (!content.TrimStart().StartsWith("#"))
                    {
                        if (MessageBox.Show(owner, "This file has no header comments. Install anyway?", "No metadata",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    }

                    var scriptsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");
                    Directory.CreateDirectory(scriptsDir);

                    var name = Path.GetFileName(new Uri(url).LocalPath);
                    var dest = Path.Combine(scriptsDir, name);

                    if (File.Exists(dest))
                    {
                        if (MessageBox.Show(owner, $"{name} already exists. Overwrite?", "File exists",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    }

                    File.WriteAllText(dest, content, Encoding.UTF8);
                    MessageBox.Show(owner, $"Installed: {name}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Switch and refresh
                    SwitchAndRefreshToExtensionsView(navigator);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(owner, "Install failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Import a local .ps1 file into the extensions folder.
        /// </summary>
        public static void ImportLocalFile(IWin32Window owner, ViewNavigator navigator = null)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "PowerShell scripts (*.ps1)|*.ps1";
                ofd.Title = "Select an extension script";

                if (ofd.ShowDialog(owner) != DialogResult.OK) return;

                try
                {
                    var scriptsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");
                    Directory.CreateDirectory(scriptsDir);

                    var dest = Path.Combine(scriptsDir, Path.GetFileName(ofd.FileName));
                    File.Copy(ofd.FileName, dest, overwrite: true);

                    MessageBox.Show(owner, $"Imported: {Path.GetFileName(dest)}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Switch and refresh
                    SwitchAndRefreshToExtensionsView(navigator);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(owner, "Import failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Open the extensions scripts folder in Explorer.
        /// </summary>
        public static void OpenScriptsFolder(IWin32Window owner)
        {
            string scriptDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");
            Directory.CreateDirectory(scriptDirectory);

            try
            {
                Process.Start("explorer.exe", scriptDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, "Could not open folder: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Open the online guide for writing extensions.
        /// </summary>
        public static void OpenExtensionGuide()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/builtbybel/Flyoobe/blob/main/Flyoobe.Extensions/Write-an-Extension.md",
                UseShellExecute = true
            });
        }
    }
}