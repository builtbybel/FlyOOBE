using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe.Views
{
    /// <summary>
    /// Home dashboard screen that displays setup pages and extensions.
    /// Provides search filtering and section grouping.
    /// </summary>
    public partial class HomeControlView : UserControl, IView, IHasSearch
    {
        private readonly ViewNavigator _navigator;

        public string ViewTitle
        { get { return "Start"; } }

        public string ViewSubtitle
        { get { return null; } }

        // Stores all tiles for search
        private readonly List<HomeItemControl> _allTiles = new List<HomeItemControl>();

        // Ensures each tile is created once and reused
        private readonly Dictionary<string, HomeItemControl> _tileCache =
            new Dictionary<string, HomeItemControl>(StringComparer.OrdinalIgnoreCase);


        public HomeControlView(ViewNavigator navigator)
        {
            _navigator = navigator;
            InitializeComponent();
            BuildUI();
        }

        private void HomeControlView_Load(object sender, EventArgs e)
        {
            comboFilter.Items.Clear();
            comboFilter.Items.Add("All");
            comboFilter.Items.Add("OOBE");
            comboFilter.Items.Add("Extensions");

            comboFilter.SelectedIndex = 0;
        }

        /// <summary>
        /// Rebuilds all home-screen content.
        /// </summary>
        private void BuildUI()
        {
            flowRoot.SuspendLayout();
            flowRoot.Controls.Clear();

            // Recommended Section
            var ext = AddSection("☆ Featured Extensions", "ext");
            AddExtensionTile(ext, "Flyby11", "Upgrade to Windows 11", "Safely migrate Windows 10 to Windows 11");

            AddExtensionTile(ext, "Windows 11 25H2 Enablement Package", "Activate Windows 11 25H2", "Enable new features now");
            AddExtensionTile(ext, "ViVeTool-Bridge", "ViVeTool", "Toggle experimental Windows features");

            // Native Tool Pages
            AddTile(ext, "Dumputer", "Remove unwanted apps", delegate { _navigator.ShowView("Apps"); }, "debloat bloatware remove apps cleanup");
            AddTile(ext, "CoTweaker", "Enhance privacy settings and optimize system, gaming etc.", delegate { _navigator.ShowView("Experience"); }, "bloatware tweak copilot ai privacy boost");
            AddTile(ext, "App Installer", "Install recommended software", delegate { _navigator.ShowView("Installer"); }, "install apps software winget");

            // OOBE Setup Pages
            var oobe = AddSection("📄 All Setup Pages", "oobe");
            foreach (string page in _navigator.OobeStepsWithoutHome)
            {
                ViewMetadata.Pages.TryGetValue(page, out var meta);

                string title = meta.Title ?? page;
                string subtitle = meta.Subtitle ?? "";
                ViewMetadata.SearchTags.TryGetValue(page, out var tags);

                AddTile(oobe, title, subtitle,
                    delegate { _navigator.ShowView(page); }, tags);
            }


            // Extensions Hub
            var tools = AddSection("🧩 Extensions Hub", "ext");
            AddTile(tools, "Extensions", "Open extension manager", delegate { _navigator.ShowView("Extensions"); }, ViewMetadata.SearchTags["Extensions"]);

            flowRoot.ResumeLayout();
            ApplyFilter();
        }

        /// <summary>
        /// Creates a section block with a header label.
        /// </summary>
        private FlowLayoutPanel AddSection(string headerText, string filterKey)
        {
            var section = new FlowLayoutPanel();
            section.AutoSize = true;
            section.FlowDirection = FlowDirection.TopDown;
            section.WrapContents = false;
            section.Tag = filterKey;

            flowRoot.Controls.Add(section);

            var header = new Label();
            header.Text = headerText;
            header.AutoSize = true;
            header.Font = new Font("Segoe UI Semibold", 13f);
            header.Margin = new Padding(8, 0, 8, 12);
            section.Controls.Add(header);

            var row = new FlowLayoutPanel();
            row.AutoSize = true;
            row.FlowDirection = FlowDirection.LeftToRight;
            row.WrapContents = true;
            row.Margin = new Padding(8, 0, 8, 12);
            section.Controls.Add(row);

            return row;
        }

        /// <summary>
        /// Creates (or reuses) a tile UI element.
        /// </summary>
        private void AddTile(FlowLayoutPanel target, string title, string description, Action click, string tags)
        {
            HomeItemControl tile;

            if (!_tileCache.TryGetValue(title, out tile))
            {
                tile = new HomeItemControl();
                tile.ItemTitle = title;
                tile.ItemDescription = description;
                tile.SearchTags = (tags ?? "").ToLowerInvariant();
                tile.Margin = new Padding(8);
                tile.Clicked += click;

                _tileCache[title] = tile;
                _allTiles.Add(tile);
            }

            target.Controls.Add(tile);
        }


        /// <summary>
        /// Tile that opens the Extensions Hub and selects a specific tool.
        /// </summary>
        private void AddExtensionTile(FlowLayoutPanel panel, string toolKey, string title, string description)
        {
            // tile == visible UI title, e.g. Upgrade to Windows 11
            // toolKey == internal extension identifier, e.g. Flyby11
            string tags;
            ViewMetadata.SearchTags.TryGetValue(toolKey, out tags);

            AddTile(panel, title, description, delegate
            {
                _navigator.ShowView("Extensions");

                var hub = _navigator.CurrentView as Flyoobe.ToolHub.ToolHubControlView;
                if (hub != null)
                    hub.SelectTool(toolKey);
            }, tags);

            // assign user count using toolKey
            string userCount;
            if (ViewMetadata.UserCounts.TryGetValue(toolKey, out userCount))
            {
                _tileCache[title].UserCount = userCount; // key = title (UI), but lookup = toolKey
            }
        }

        /// <summary>
        /// Shows/hides sections based on filter dropdown.
        /// </summary>
        private void ApplyFilter()
        {
            string mode = comboFilter.SelectedItem != null ? comboFilter.SelectedItem.ToString() : "All";

            foreach (Control c in flowRoot.Controls)
            {
                var section = c as FlowLayoutPanel;
                if (section == null) continue;

                string key = section.Tag as string;

                if (mode == "OOBE")
                    section.Visible = key == "oobe";
                else if (mode == "Extensions")
                    section.Visible = key == "ext";
                else
                    section.Visible = true;
            }
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        public void RefreshView()

        {
            BuildUI();
        }

        /// <summary>
        /// Applies a global search filter to all home screen tiles.
        /// This method is called by the MainForm whenever the user updates the
        /// search box in the global header (outside of this view).
        public void OnGlobalSearchChanged(string text)
        {
            string filter = (text ?? "").Trim().ToLowerInvariant();

            foreach (var tile in _allTiles)
            {
                bool match =
                    tile.ItemTitle.ToLowerInvariant().Contains(filter) ||
                    tile.ItemDescription.ToLowerInvariant().Contains(filter) ||
                    tile.SearchTags.Contains(filter);

                tile.Visible = match;
            }
        }
    }
}