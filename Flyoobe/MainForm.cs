using Flyoobe.Views;
using System;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class MainForm : Form
    {
        private ViewNavigator _navigator;

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set default form size
            UIHelper.SetDefaultFormSize(this);

            // Create navigator
            _navigator = new ViewNavigator(
              panelHost,
              name =>
              {
                  this.Text = "FlyOOBE";
                  lblHeader.Text = name;
              },
              btnBack
          );

            // Register all views
            RegisterViews();

            // Show initial view
            _navigator.ShowView("Home");

            // Set default active nav
            ActivateNav(btnHome);

            // Wire navigation buttons
            WireNavButtons();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Rounded panel
            UIHelper.EnableRoundedPanel(panelForm, 20, 1);
            UIHelper.EnableRoundedPanel(panelHost, 20, 0);

            // Set background
            BackgroundHelper.LoadOrAskBackground(
           panelForm,
           lblHeader,
           btnBack,
           btnRefresh,
           btnActivity
         );

            // Initialize Logger view
            InitializeLogger();
        }

        private void RegisterViews()
        {
            // Register main pages
            _navigator.RegisterView("Home", () => new HomeControlView(_navigator));
            _navigator.RegisterView("Settings", () =>
                new AppSettingsControlView(panelForm, lblHeader, btnBack, btnRefresh, btnActivity));
            _navigator.RegisterView("Extensions", () => new ToolHub.ToolHubControlView());

            // Register OOBE pages directly, central navigator handles routing
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
            _navigator.RegisterView("Advanced", () => new AdvancedControlView());

 
        }

        private void WireNavButtons()
        {
            // Navigation icons
            btnHome.IconGlyph = "\uEA8A";
            btnOobe.IconGlyph = "\uE71D";
            btnExtensions.IconGlyph = "\uEA86";
            btnSettings.IconGlyph = "\uE713";

            // Header command bar icons
            btnActivity.Text = "\uEA8F";
            btnBack.Text = "\uE72B";
            btnRefresh.Text = "\uE72C";

            // Click bindings
            btnHome.Click += (s, e) =>
            {
                ActivateNav(btnHome);
                _navigator.ShowView("Home");
            };
            btnOobe.Click += (s, e) =>
            {
                ActivateNav(btnOobe);
                _navigator.ShowView("Device");  // First OOBE page
            };
            btnExtensions.Click += (s, e) =>
            {
                ActivateNav(btnExtensions);
                _navigator.ShowView("Extensions");
            };
            btnSettings.Click += (s, e) =>
            {
                ActivateNav(btnSettings);
                _navigator.ShowView("Settings");
            };
        }

        private void InitializeLogger()
        {
            // Logger View
            _navigator.RegisterView("Activity", () =>
            {
                var view = new LoggerControlView();
                Logger.SetLoggerControl(view); // connect logger output to this view
                return view;
            });

            Logger.AttachNavigator(_navigator);

            // startup logs
            Logger.Log($"FlyOOBE {Program.GetAppVersion()} is airborne!", LogLevel.Info);
            Logger.Log("OOBEE warming up the engines... 🚀", LogLevel.Info);
            Logger.Log("Code. Fly. Repeat. Source & updates:", LogLevel.Info);
            Logger.Log("GitHub → https://github.com/builtbybel/Flyoobe", LogLevel.Info);
            Logger.Log("X (Twitter) → https://x.com/builtbybel", LogLevel.Info);
            Logger.Log("FlyOOBE – built for speed, built by bel.", LogLevel.Info);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textSearch.Text = ""; // Clear global search box

            // Inform the active view about the reset (fixes search reset issue!)
            if (_navigator.CurrentView is IHasSearch searchable)
                searchable.OnGlobalSearchChanged(string.Empty);

            // If the current view implements IView, trigger its RefreshView method
            if (_navigator.CurrentView is IView view)
            {
                view.RefreshView();
            }
        }

        private void btnActivity_Click(object sender, EventArgs e)
        {
            Logger.ShowLogView();
        }

        /// <summary>
        /// Sets the visual "active" state for the navigation bar.
        /// Only one NavButton can be active at any time.
        /// </summary>
        /// <param name="active">The button that should be highlighted as active.</param>
        private void ActivateNav(NavButton active)
        {
            // Reset all navigation buttons to inactive state
            btnHome.SetActive(false);
            btnOobe.SetActive(false);
            btnExtensions.SetActive(false);
            btnSettings.SetActive(false);

            // Activate the selected button
            active.SetActive(true);
        }

        // Global search
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            var view = _navigator.CurrentView as IHasSearch;
            if (view != null)
                view.OnGlobalSearchChanged(textSearch.Text);
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DonationHelper.HasDonated())
            {
                DonationHelper.ShowDonationPrompt();
            }
        }
    }
}