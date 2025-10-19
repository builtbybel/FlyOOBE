using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    /// <summary>
    /// Start page with a scrollable list of tiles (Win11 upgrade, install, OOBE, extensions, etc.)
    /// </summary>
    public partial class HomeControlView : UserControl, IView
    {
        private readonly ViewNavigator _navigator;
        public string ViewTitle => "Startsite";

        // MDL2 glyphs
        private const string GLYPH_WINDOWS = "\uE9F3";
        private const string GLYPH_MEDIA = "\uE8A5";
        private const string GLYPH_OOBE = "\uE790";
        private const string GLYPH_EXT = "\uE71D";
        private const string GLYPH_CHEVRON = "\uE76C";

        // Colors
        private readonly Color BaseColor = Color.White;

        private readonly Color HoverColor = Color.FromArgb(246, 246, 246);
        private readonly Color SeparatorColor = Color.FromArgb(230, 230, 230);

        public HomeControlView(ViewNavigator navigator)
        {
            _navigator = navigator;
            BuildLayout();
        }

        // =========================
        // Layout setup
        // =========================
        private void BuildLayout()
        {
            float dpi = this.CreateGraphics().DpiX / 96f;

            var root = CreateRootPanel();
            var list = CreateListPanel();

            // First tile depends on OS
            if (!Utils.DetectWindows11())
            {
                AddRow(list, CreateListTile(
                    GLYPH_WINDOWS,
                    "Get Windows 11",
                    "Download or upgrade to Windows 11",
                    () => _navigator.ShowView("Upgrade"),
                    dpi));
            }
            else
            {
                AddRow(list, CreateOobeAssistListTile(dpi));
            }

            // Additional static tiles
            AddRow(list, CreateListTile(
                GLYPH_MEDIA, "Install from image", "Install Windows from ISO, repair this PC.",
                () => _navigator.ShowView("Reinstall"), dpi));

            AddRow(list, CreateListTile(
                GLYPH_OOBE, "Customize OOBE", "Tweak and personalize after install",
                () => _navigator.ShowView("Personalization"), dpi));

            AddRow(list, CreateListTile(
                GLYPH_EXT, "Setup Extensions", "Enhance your setup with community tools",
                () => _navigator.ShowView("Extensions"), dpi));

            root.Controls.Add(list, 0, 0);
            Controls.Add(root);
        }

        private TableLayoutPanel CreateRootPanel()
        {
            return new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 1,
                BackColor = BaseColor
            };
        }

        private TableLayoutPanel CreateListPanel()
        {
            return new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                ColumnCount = 1,
                BackColor = BaseColor
            };
        }

        /// <summary>
        /// Adds one row = [tile] + [separator line].
        /// </summary>
        private void AddRow(TableLayoutPanel tlp, Control tile)
        {
            float dpi = this.CreateGraphics().DpiX / 96f;

            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.Controls.Add(tile, 0, tlp.RowCount++);

            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, Math.Max(1, (int)(1 * dpi))));
            tlp.Controls.Add(new Panel
            {
                Height = Math.Max(1, (int)(1 * dpi)),
                Dock = DockStyle.Top,
                BackColor = SeparatorColor,
                Margin = new Padding(0)
            }, 0, tlp.RowCount++);
        }

        // =========================
        // Tile creation
        // =========================

        /// <summary>
        /// Generic clickable tile:
        /// [icon] [title + description] [chevron].
        /// </summary>
        private Control CreateListTile(string iconGlyph, string title, string subtitle, Action onClick, float dpi)
        {
            var row = CreateRowPanel(120 * dpi);

            // Left: icon
            var icon = CreateIconLabel(iconGlyph, 48 * dpi, 20f * dpi, Color.FromArgb(31, 31, 31));

            // Right: chevron
            var chevron = CreateIconLabel(GLYPH_CHEVRON, 32 * dpi, 12f * dpi, Color.FromArgb(120, 120, 120), DockStyle.Right);

            // Middle: title + subtitle
            var textHost = CreateTextBlock(title, subtitle, dpi);

            row.Controls.Add(textHost);
            row.Controls.Add(chevron);
            row.Controls.Add(icon);

            ApplyHover(row);
            WireClickRecursive(row, onClick);

            return row;
        }

        /// <summary>
        /// Windows 11 specific tile:
        /// [icon] [title + description] [dropdown menu].
        /// No row click, navigation via ComboBox.
        /// </summary>
        private Control CreateOobeAssistListTile(float dpi)
        {
            var row = CreateRowPanel(100 * dpi);

            // Left: icon
            var icon = CreateIconLabel(GLYPH_WINDOWS, 48 * dpi, 20f * dpi, Color.FromArgb(224, 68, 181));

            // Right: dropdown menu
            var combo = new ComboBox
            {
                Dock = DockStyle.Right,
                Width = (int)(260 * dpi),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10f, FontStyle.Regular)
            };

            combo.Items.Add(new ComboOption("Select an action...", null));
            combo.Items.Add(new ComboOption("Remove bundled apps and bloatware", "Apps"));
            combo.Items.Add(new ComboOption("Pick a browser that’s not Edge as default", "Browser"));
            combo.Items.Add(new ComboOption("Install must-have apps you’re missing", "Installer"));
            combo.Items.Add(new ComboOption("Run post-setup actions: update Defender...", "Extensions"));
            combo.Items.Add(new ComboOption("Create or switch to a local account", "Account"));
            combo.Items.Add(new ComboOption("Adjust AI features to your needs", "AI"));
            combo.SelectedIndex = 0;

            combo.SelectedIndexChanged += (s, e) =>
            {
                var opt = combo.SelectedItem as ComboOption;
                if (opt != null && !string.IsNullOrEmpty(opt.Key))
                    _navigator.ShowView(opt.Key);
            };

            // special link for 25H2 Enablement Package
            var linkEP = new LinkLabel
            {
                Dock = DockStyle.Bottom,
                Height = (int)(24 * dpi),
                Font = new Font("Segoe UI", 10f, FontStyle.Regular),
                Text = "Windows 11 25H2 is here – activate now!",
                LinkColor = Color.FromArgb(0, 102, 204),
                TextAlign = ContentAlignment.MiddleRight
            };

            linkEP.Click += (s, e) =>
            {
                // Open Extensions view
                _navigator.ShowView("Extensions");

                // Tell ToolHub to select this tool
                if (_navigator.CurrentView is Flyoobe.ToolHub.ToolHubControlView hub)
                {
                    hub.SelectTool("Windows 11 25H2 Enablement Package");
                }
            };

            // === Middle: title + description ===
            var textHost = CreateTextBlock(
                "Finish what Setup skipped",
                "Quick actions after Windows is already installed",
                dpi);

            // Add all UI parts into the row
            row.Controls.Add(textHost);
            row.Controls.Add(combo);
            row.Controls.Add(icon);
            row.Controls.Add(linkEP); 

            ApplyHover(row);
            return row;
        }

        // =========================
        // Control factories
        // =========================

        private Panel CreateRowPanel(float height)
        {
            return new Panel
            {
                Dock = DockStyle.Top,
                Height = (int)height,
                BackColor = BaseColor,
                Padding = new Padding(16),
                Margin = new Padding(0),
                Cursor = Cursors.Hand
            };
        }

        private Label CreateIconLabel(string text, float width, float fontSize, Color color, DockStyle dock = DockStyle.Left)
        {
            return new Label
            {
                AutoSize = false,
                Width = (int)width,
                Dock = dock,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe MDL2 Assets", fontSize, FontStyle.Regular),
                ForeColor = color,
                Text = text
            };
        }

        /// <summary>
        /// Builds a text block with header (title) and description (subtitle).
        /// </summary>
        private Panel CreateTextBlock(string title, string subtitle, float dpi)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding((int)(4 * dpi), 0, (int)(4 * dpi), 0)
            };

            // Description below
            var lblSub = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f, FontStyle.Regular),
                Text = subtitle,
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis = true
            };

            // Title on top
            var lblTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = (int)(28 * dpi),
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(lblSub);
            panel.Controls.Add(lblTitle);
            return panel;
        }

        // =========================
        // Hover / click helpers
        // =========================

        private void WireClickRecursive(Control root, Action onClick)
        {
            Action<Control> attach = null;
            attach = (c) =>
            {
                c.Click += (s, e) => onClick?.Invoke();
                foreach (Control child in c.Controls)
                    attach(child);
            };
            attach(root);
        }

        private void ApplyHover(Control root)
        {
            WireHoverRecursive(root,
                () => root.BackColor = HoverColor,
                () =>
                {
                    if (!root.ClientRectangle.Contains(root.PointToClient(Cursor.Position)))
                        root.BackColor = BaseColor;
                });
        }

        private static void WireHoverRecursive(Control root, Action onEnter, Action onLeave)
        {
            EventHandler enter = (s, e) => onEnter?.Invoke();
            EventHandler leave = (s, e) => onLeave?.Invoke();

            Action<Control> attach = null;
            attach = (c) =>
            {
                c.MouseEnter += enter;
                c.MouseLeave += leave;
                foreach (Control child in c.Controls)
                    attach(child);
            };
            attach(root);
        }

        // =========================
        // Helper class for ComboBox
        // =========================
        private class ComboOption
        {
            public string Text { get; }
            public string Key { get; }

            public ComboOption(string text, string key)
            { Text = text; Key = key; }

            public override string ToString()
            { return Text; }
        }

        public void RefreshView()
        { }
    }
}