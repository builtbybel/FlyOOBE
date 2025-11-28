using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public static class BackgroundHelper
{
    // Path to save selected background setting
    private static string settings = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app", "FlyOOBE.txt");

    private static string current = "None";

    /// <summary>
    /// Loads the saved background style (if available) and applies it to the given panel.
    /// </summary>
    public static void LoadOrAskBackground(
        Panel panel,
        Label lblHeader,
        Button btnBack = null,
        Button btnRefresh = null,
        Button btnActivity = null)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(settings));
        string chosen = File.Exists(settings)
            ? File.ReadAllLines(settings).FirstOrDefault(x => x.StartsWith("background=", StringComparison.OrdinalIgnoreCase))
            : null;

        chosen = chosen != null ? chosen.Substring("background=".Length).Trim() : "None";
        if (string.IsNullOrEmpty(chosen) || chosen == "None") return;

        ApplyBackground(panel, chosen, lblHeader, btnBack, btnRefresh, btnActivity);
    }


    /// <summary>
    /// Opens a simple dialog to choose a background gradient.
    /// </summary>
    public static void ChooseBackground(Panel panel, Label lblHeader)
    {
        string[] styles = {
            "None",
            "Soft Gradient",
            "Sunset Glow",
            "Acrylic Blue",
            "Mica Purple",
            "Neon Mint",
            "Emerald Flow",
            // Darker Styles
            "Cyberpunk Violet",
            "Aurora Night",
            "Zen Blueberry",
            "Midnight Plasma",
            "Lime Circuit",
            "Carbon Sunset",
             // Copilot Styles
            "Copilot Pastel",
            "Copilot Neon",
            "Copilot Chaos",
        };

        using (Form dlg = new Form())
        {
            dlg.Text = "Choose your background";
            dlg.Size = new Size(260, 300);
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.ShowIcon = false;

            ListBox list = new ListBox { Dock = DockStyle.Fill };
            list.Items.AddRange(styles);

            Button ok = new Button { Text = "OK", Dock = DockStyle.Bottom };
            ok.Click += (s, e) => dlg.DialogResult = DialogResult.OK;

            dlg.Controls.Add(list);
            dlg.Controls.Add(ok);

            if (dlg.ShowDialog() == DialogResult.OK && list.SelectedItem != null)
            {
                string sel = list.SelectedItem.ToString();
                SaveBackgroundSetting(sel);
                if (sel != "None") ApplyBackground(panel, sel, lblHeader);
                else panel.Invalidate();
            }
        }
    }

    /// <summary>
    /// Writes the selected background to settings file.
    /// </summary>
    private static void SaveBackgroundSetting(string sel)
    {
        string[] lines = File.Exists(settings)
            ? File.ReadAllLines(settings)
            : new[] { "# FlyOOBE Settings file" };

        bool found = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("background=", StringComparison.OrdinalIgnoreCase))
            {
                lines[i] = "background=" + sel;
                found = true;
                break;
            }
        }

        if (!found)
        {
            var l = lines.ToList();
            l.Add("background=" + sel);
            lines = l.ToArray();
        }

        File.WriteAllLines(settings, lines);
    }

    /// <summary>
    /// Applies the selected background gradient and adjusts all foreground UI colors
    /// so that dark backgrounds use white text and light backgrounds use black text.
    /// </summary>
    private static void ApplyBackground(Panel panel, string style, Label lblHeader,
        Button btnBack = null, Button btnRefresh = null, Button btnActivity = null)
    {
        current = style;
        panel.Paint -= Panel_Paint;
        panel.Paint += Panel_Paint;
        panel.Tag = style;

        panel.Resize -= (s, e) => panel.Invalidate();
        panel.Resize += (s, e) => panel.Invalidate();
        panel.Invalidate();

        bool dark =
            style.Contains("Cyberpunk") ||
            style.Contains("Aurora") ||
            style.Contains("Zen") ||
            style.Contains("Midnight") ||
            style.Contains("Lime") ||
            style.Contains("Carbon") ||
            style.Contains("Dark Mode") ||
            style.Contains("Mica") ||
            style.Contains("Sunset Glow");

        Color txt = dark ? Color.White : Color.FromArgb(40, 40, 40);
        Color btnBackColor = dark ? Color.FromArgb(50, 50, 50) : Color.FromArgb(230, 230, 230);

        if (lblHeader != null) lblHeader.ForeColor = txt;

        // Apply button color changes
        ApplyButtonStyle(btnBack, txt);
        ApplyButtonStyle(btnRefresh, txt);
        ApplyButtonStyle(btnActivity, txt);

    }

    private static void ApplyButtonStyle(Button btn, Color txt)
    {
        if (btn == null) return;

        btn.ForeColor = txt;
    }


    /// <summary>
    /// Paint event handler for panel background rendering.
    /// </summary>
    private static void Panel_Paint(object sender, PaintEventArgs e)
    {
        Panel p = (Panel)sender;
        string style = p.Tag as string;
        if (string.IsNullOrEmpty(style) || style == "None") return;

        Rectangle r = p.ClientRectangle;
        using (LinearGradientBrush b = CreateBrush(style, r))
        {
            if (b != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillRectangle(b, r);
            }
        }
    }
    /// <summary>
    /// Creates the gradient brush for each style.
    /// </summary>
    private static LinearGradientBrush CreateBrush(string style, Rectangle r)
    {
        // --- Soft, clean themes ---
        if (style == "Soft Gradient")
            return new LinearGradientBrush(r,
                Color.FromArgb(255, 230, 245),
                Color.FromArgb(200, 210, 255), 75f);

        if (style == "Sunset Glow")
            return new LinearGradientBrush(r,
                Color.FromArgb(255, 120, 90),
                Color.FromArgb(190, 60, 120), 60f);

        if (style == "Acrylic Blue")
            return new LinearGradientBrush(r,
                Color.FromArgb(90, 170, 255),
                Color.FromArgb(30, 80, 180), 45f);

        if (style == "Mica Purple")
            return new LinearGradientBrush(r,
                Color.FromArgb(170, 140, 255),
                Color.FromArgb(50, 30, 100), 80f);

        if (style == "Neon Mint")
            return new LinearGradientBrush(r,
                Color.FromArgb(120, 255, 210),
                Color.FromArgb(0, 200, 150), 70f);

        if (style == "Emerald Flow")
            return new LinearGradientBrush(r,
                Color.FromArgb(60, 220, 170),
                Color.FromArgb(10, 120, 90), 50f);

        // dark styles
        if (style == "Cyberpunk Violet")
            return new LinearGradientBrush(r,
                Color.FromArgb(255, 0, 200),   // Neon Magenta
                Color.FromArgb(0, 30, 90),     // Deep dark blue-violet
                45f);

        if (style == "Aurora Night")
            return new LinearGradientBrush(r,
                Color.FromArgb(40, 10, 60),    // Deep violet base
                Color.FromArgb(0, 220, 255),   // Cyan-turquoise glow
                80f);

        if (style == "Zen Blueberry")
            return new LinearGradientBrush(r,
                Color.FromArgb(40, 60, 120),   // Navy blue base
                Color.FromArgb(140, 180, 255), // Light blue highlight
                60f);

        if (style == "Midnight Plasma")
            return new LinearGradientBrush(r,
                Color.FromArgb(20, 10, 40),    // Almost black purple
                Color.FromArgb(180, 0, 150),   // Bright magenta-violet
                70f);

        if (style == "Lime Circuit")
            return new LinearGradientBrush(r,
                Color.FromArgb(20, 50, 30),    // Dark green background
                Color.FromArgb(0, 255, 100),   // Vibrant neon lime
                75f);

        if (style == "Carbon Sunset")
            return new LinearGradientBrush(r,
                Color.FromArgb(30, 30, 30),    // Carbon gray
                Color.FromArgb(255, 80, 60),   // Warm neon orange
                50f);
        if (style == "Dark Mode")
            return new LinearGradientBrush(r,
                Color.FromArgb(30, 30, 30),   // Base carbon
                Color.FromArgb(45, 45, 45),   // Slight highlight
                90f);

        // --- Copilot Themes ---

        if (style == "Copilot Pastel")
            return new LinearGradientBrush(r,
                Color.FromArgb(190, 215, 255),   // Soft Copilot blue
                Color.FromArgb(230, 200, 255),   // Gentle purple tint
                65f);

        if (style == "Copilot Neon")
            return new LinearGradientBrush(r,
                Color.FromArgb(0, 160, 255),     // Bright Copilot blue
                Color.FromArgb(200, 0, 255),     // Neon magenta accent
                55f);

        if (style == "Copilot Chaos")
        {
            return new LinearGradientBrush(r,
                Color.FromArgb(255, 0, 255),    // Hot pink
                Color.FromArgb(0, 255, 255),    // Neon cyan
                15f);
        }

        return null;
    }
}