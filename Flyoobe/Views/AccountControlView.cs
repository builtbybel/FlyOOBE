using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class AccountControlView : UserControl, IView
    {
        public string ViewTitle => "Account";

        public AccountControlView()

        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("You need to run the application as Administrator to create a local account.", "Insufficient Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = textUsername.Text.Trim();
            string password = textPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CreateLocalAccount(username, password);
        }

        private bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private void CreateLocalAccount(string username, string password)
        {
            string arguments = $"/c net user \"{username}\" \"{password}\" /add";
            var processInfo = new ProcessStartInfo("cmd.exe", arguments)
            {
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            };

            try
            {
                Process.Start(processInfo);
                MessageBox.Show($"Local account '{username}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkOnlineAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("ms-settings:emailandaccounts");
        }

        private void btnCreateAccountWizard_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", "ms-cxh:localonly");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open local account creation: {ex.Message}");
            }
        }

        public void RefreshView()
        {
            textUsername.Text =
            textPassword.Text = "";
        }
    }
}