using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe.Views
{
    public partial class AppSettingsControlView : UserControl, IView
    {
        private Panel _targetPanel;
        private Label _lblHeader;

        private Button _btnBack;
        private Button _btnRefresh;
        private Button _btnActivity;

        public AppSettingsControlView(
           Panel targetPanel,
           Label lblHeader,
           Button btnBack,
           Button btnRefresh,
           Button btnActivity)
        {
            InitializeComponent();

            _targetPanel = targetPanel;
            _lblHeader = lblHeader;

            _btnBack = btnBack;
            _btnRefresh = btnRefresh;
            _btnActivity = btnActivity;

            UIHelper.EnableRoundedPanel(panelForm, 20, 0);

            chkDonated.Checked = DonationHelper.HasDonated();
        }



        private void btnUIBackground_Click(object sender, EventArgs e)
        {
            BackgroundHelper.ChooseBackground(_targetPanel, _lblHeader);
        }

        private void AppSettingsControlView_Load(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void OpenGitHubUpdatePage()
        {
            try
            {
                var updateUrl = $"https://builtbybel.github.io/FlyOOBE/update-check.html?version={Program.GetAppVersion()}";
                var psi = new ProcessStartInfo
                {
                    FileName = updateUrl,
                    UseShellExecute = true
                };
                Process.Start(psi);

                // Some feedback
                linkAppVersion.Text = "Online update page opened.";
                linkAppVersion.Font = new Font(linkAppVersion.Font, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                linkAppVersion.Text = $"Could not open update page: {ex.Message}";
            }
        }

        private void chkDonated_CheckedChanged(object sender, EventArgs e)
        {
            DonationHelper.SetDonationStatus(chkDonated.Checked);
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            OpenGitHubUpdatePage();
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG",
                UseShellExecute = true
            });
        }

        public async void RefreshView()
        {
            // Show local version
            string currentVersion = Program.GetAppVersion();
            linkAppVersion.Text = "Fetching updates...";
            linkAppVersion.Font = new Font(linkAppVersion.Font, FontStyle.Regular);
            await Task.Delay(2000);
            linkAppVersion.Text = $"You have Flyoobe version {currentVersion}";
        }

        private void linkAppVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/builtbybel/Flyoobe",
                UseShellExecute = true
            });
        }
    }
}