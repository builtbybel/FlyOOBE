using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class MainForm : Form
    {
        private ViewNavigator _navigator;
        private AboutForm aboutForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set up buttons
            InitializeButtons();
            // Rounded panel
            UIHelper.EnableRoundedPanel(panelControls, 30, 1);
            UIHelper.EnableRoundedSplitContainer(splitContainer, 10, 0);
            // Set default form size
            UIHelper.SetDefaultFormSize(this);
            // Set app logo
            UIHelper.SetAppLogo(pictureApp, 24);
            // DPI scale
            float dpiScale = UIHelper.GetDpiScale(this);

            // Initialize ViewNavigator, which manages loading and switching between different views inside host panel
            _navigator = new ViewNavigator(
                   panelHost,
                   navTree, ViewTitle => this.Text = $"FlyOOBE",
                   toolStripButtonNext);

            // Register views
            _navigator.RegisterView("Home", () => new HomeControlView(_navigator));
            _navigator.RegisterView("Reinstall", () => new InstallControlView());
            _navigator.RegisterView("Device", () => new DeviceControlView());
            _navigator.RegisterView("Personalization", () => new PersonalizationControlView());
            _navigator.RegisterView("Browser", () => new DefaultsControlView());
            _navigator.RegisterView("AI", () => new AiControlView());
            _navigator.RegisterView("Network", () => new NetworkControlView());
            _navigator.RegisterView("Account", () => new AccountControlView());
            _navigator.RegisterView("Apps", () => new AppsControlView());
            _navigator.RegisterView("Experience", () => new ExperienceControlView());
            _navigator.RegisterView("Installer", () => new InstallerControlView());
            _navigator.RegisterView("Updates", () => new UpdatesControlView());
            _navigator.RegisterView("Extensions", () => new ToolHub.ToolHubControlView());
            _navigator.RegisterView("Post-Setup", () => new Flyoobe.ToolHub.PostToolHubControlView());

            // Load OOBE navigation with system status
            _navigator.BuildSidebarNavigation();

            // Show initial view
            _navigator.ShowView("Home");
            Logger.Log($"FlyOOBE {Program.GetAppVersion()} is airborne!", LogLevel.Info);
            Logger.Log("OOBEE warming up the engines... 🚀", LogLevel.Info);
            Logger.Log("Code. Fly. Repeat. Source & updates:", LogLevel.Info);
            Logger.Log("GitHub → https://github.com/builtbybel/Flyoobe", LogLevel.Info);
            Logger.Log("X (Twitter) → https://x.com/builtbybel", LogLevel.Info);
            Logger.Log("FlyOOBE – built for speed, built by bel.", LogLevel.Info);
        }

        private void InitializeButtons()
        {
            btnToggle.Text = "\uEDE3";    // Hamburger menu
            btnMore.Text = "\uE712";      // More
            btnSettings.Text = "\uE713";  // Settings
            btnRefresh.Text = "\uE72C";   // Refresh
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DonationHelper.HasDonated())
            {
                DonationHelper.ShowDonationPrompt();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // If the current view implements IView, trigger its RefreshView method
            if (_navigator.CurrentView is IView view)
            {
                view.RefreshView();
            }
        }

        // Navigation toggle button click handler
        private void btnToggle_Click(object sender, EventArgs e)
        {
            splitContainer.Panel1Collapsed = !splitContainer.Panel1Collapsed;
        }

        private void manageExtensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolHub.ExtensionsHelper.SwitchToExtensionsView(_navigator);
        }

        private async void installFromUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ToolHub.ExtensionsHelper.InstallFromUrlAsync(this, _navigator);
        }

        private void installFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolHub.ExtensionsHelper.ImportLocalFile(this, _navigator);
        }

        private void writeAnExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolHub.ExtensionsHelper.OpenExtensionGuide();
        }

        private void extensionFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolHub.ExtensionsHelper.OpenScriptsFolder(this);
        }

        private void btnMore_Click(object sender, EventArgs e) => Logger.ToggleLogForm(this);

        private void btnSettings_Click(object sender, EventArgs e) => ShowAboutForm();

        private void PositionAboutForm(Form owner)
        {
            if (aboutForm != null && !aboutForm.IsDisposed)
            {
                int x = owner.Left + (owner.Width - aboutForm.Width) / 2;
                int y = owner.Top + (owner.Height - aboutForm.Height) / 2;
                aboutForm.Location = new Point(x, y);
            }
        }

        private void ShowAboutForm()
        {
            var owner = this.FindForm(); // find MainForm
            if (owner == null) return;

            if (aboutForm == null || aboutForm.IsDisposed)
            {
                aboutForm = new AboutForm
                {
                    StartPosition = FormStartPosition.Manual,
                    Owner = owner
                };

                // On owner move/resize, reposition about form
                owner.LocationChanged += (s, e) => PositionAboutForm(owner);
                owner.SizeChanged += (s, e) => PositionAboutForm(owner);

                aboutForm.Show(owner);
            }

            PositionAboutForm(owner);
        }
    }
}