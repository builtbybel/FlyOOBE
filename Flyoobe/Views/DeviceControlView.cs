using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class DeviceControlView : UserControl, IView
    {

        private const string PlaceholderText = "System display language";

        public DeviceControlView()
        {
            InitializeComponent();
            InitializeQuickTools();
            LoadCurrentNames();
            LoadAvailableLanguages();
        }

        /// <summary>
        /// Adds quick access tools to the bottom of the view.
        /// </summary>
        private void InitializeQuickTools()
        {
            FlowLayoutPanel quickToolsPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Bottom,
                Padding = new Padding(10),
                AutoSize = true,
         
            };

            AddQuickTool(quickToolsPanel, "Display Options", "ms-settings:display");
            AddQuickTool(quickToolsPanel, "Accessibility", "ms-settings:easeofaccess");
            AddQuickTool(quickToolsPanel, "System Info", "msinfo32");
            AddQuickTool(quickToolsPanel, "CMD", "cmd.exe");
            AddQuickTool(quickToolsPanel, "PowerShell", "powershell.exe");
            AddQuickTool(quickToolsPanel, "Magnifier", "magnify.exe");
            AddQuickTool(quickToolsPanel, "On-Screen Keyboard", "osk.exe");
            AddQuickTool(quickToolsPanel, "Notepad", "notepad.exe");

            this.Controls.Add(quickToolsPanel);
        }

        private void AddQuickTool(FlowLayoutPanel panel, string text, string command)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = true,
                Margin = new Padding(5),
                FlatStyle = FlatStyle.System,
                Font = new Font("Segoe UI Variable Display", 8.25F),
            };
            button.Click += (s, e) => Process.Start(command);
            panel.Controls.Add(button);
        }

        private void LoadCurrentNames()
        {
            textUsername.Text = Environment.UserName;
            textComputername.Text = Environment.MachineName;
        }

        /// <summary>
        /// Loads available languages from the registry and populates the language selection combo box.
        /// </summary>
        private void LoadAvailableLanguages()
        {
            List<string> languages = GetAvailableLanguagesFromRegistry();

            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add(PlaceholderText); // Add placeholder first

            foreach (var lang in languages)
            {
                cmbLanguage.Items.Add(lang);
            }

            cmbLanguage.SelectedIndex = 0;
        }

        /// <summary>
        /// Retrieves available languages from the Windows registry.
        /// </summary>
        /// <returns></returns>
        private List<string> GetAvailableLanguagesFromRegistry()
        {
            var languages = new List<string>();

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\MUI\UILanguages"))
                {
                    if (key != null)
                    {
                        languages.AddRange(key.GetSubKeyNames());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading languages from registry: " + ex.Message);
            }

            return languages;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string newUserName = textUsername.Text.Trim();
            string newComputerName = textComputername.Text.Trim();
            string selectedLanguage = cmbLanguage.SelectedIndex > 0 ? cmbLanguage.SelectedItem.ToString() : null;

            bool changesMade = false;

            // Rename Computer
            if (!string.IsNullOrEmpty(newComputerName) && newComputerName != Environment.MachineName)
            {
                try
                {
                    RenameComputer(newComputerName);
                    changesMade = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to rename computer: " + ex.Message);
                }
            }

            // Rename User
            if (!string.IsNullOrEmpty(newUserName) && newUserName != Environment.UserName)
            {
                try
                {
                    RenameLocalUser(Environment.UserName, newUserName);
                    changesMade = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to rename user: " + ex.Message);
                }
            }

            // Change Language
            if (!string.IsNullOrEmpty(selectedLanguage))
            {
                try
                {
                    ChangeLanguage(selectedLanguage);
                    changesMade = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to change language: " + ex.Message);
                }
            }

            if (changesMade)
            {
                DialogResult result = MessageBox.Show(
                    "Changes applied successfully.\nDo you want to restart now to apply them?\n\nClick Yes to restart, No to just sign out.",
                    "Apply Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    RestartComputer();
                }
                else if (result == DialogResult.No)
                {
                    LogOffUser();
                }
            }
            else
            {
                MessageBox.Show($"No changes detected, {textUsername.Text}. Looks like everything is just the way you like it! 😎", "Info");
            }
        }

        private void ChangeLanguage(string language)
        {
            string psCommand = $@"
                Set-WinUILanguageOverride -Language {language};
                Set-WinUserLanguageList -LanguageList {language} -Force;
                Set-Culture {language};
                Set-WinSystemLocale {language};
            ";

            RunPowerShell(psCommand);
        }

        // Restart the computer programmatically
        private void RestartComputer()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "shutdown",
                    Arguments = "/r /t 0",
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restarting computer: " + ex.Message);
            }
        }

        // Log off the current user programmatically
        private void LogOffUser()
        {
            try
            {
                Process.Start("shutdown", "/l");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging off: " + ex.Message);
            }
        }

        private void RenameComputer(string newName)
        {
            string psScript = $"Rename-Computer -NewName \"{newName}\" -Force -PassThru";
            RunPowerShell(psScript);
        }

        private void RenameLocalUser(string currentName, string newName)
        {
            string psScript = $"Rename-LocalUser -Name \"{currentName}\" -NewName \"{newName}\"";
            RunPowerShell(psScript);
        }

        /// <summary>
        /// Runs a PowerShell command with elevated privileges.
        /// </summary>
        /// <param name="command"></param>
        private void RunPowerShell(string command)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                    Verb = "runas", // always run as admin
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running PowerShell: " + ex.Message);
            }
        }

        public void RefreshView()
        {
            LoadCurrentNames();
            LoadAvailableLanguages();
        }

        private void btnJoinDomain_Click(object sender, EventArgs e)
        {
            Process.Start("SystemPropertiesComputerName.exe");

        }
    }
}