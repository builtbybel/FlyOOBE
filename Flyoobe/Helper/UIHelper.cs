using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

public static class UIHelper
{
    /// <summary>
    /// Set the Flyoobe logo (app/app.png) as button image, DPI-aware.
    /// </summary>
    public static void SetAppLogo(PictureBox pictureBox, int baseSize)
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app", "AppIcon.png");
            if (!File.Exists(path))
                return;

            // get DPI scale factor from the button
            float dpiScale;
            using (Graphics g = pictureBox.CreateGraphics())
                dpiScale = g.DpiX / 96f;

            int scaledSize = (int)(baseSize * dpiScale);

            using (var original = Image.FromFile(path))
            {
                var logo = new Bitmap(original, new Size(scaledSize, scaledSize));
                pictureBox.Image = logo;

                // pictureBox.Padding = new Padding((int)(6 * dpiScale), 0, (int)(6 * dpiScale), 0);
            }
        }
        catch
        {
            // ignore errors, keep button text
        }
    }

    /// <summary>
    /// Enable rounded corners with a border for a panel.
    /// Corners and border are automatically redrawn on resize.
    /// </summary>
    public static void EnableRoundedPanel(Panel panel, int radius = 12, int borderThickness = 1)
    {
        panel.Resize += (s, e) => ApplyRegion(panel, radius);
        panel.Paint += (s, e) =>
        {
            using (var path = CreatePath(panel, radius))
            using (var pen = new Pen(Color.LightGray, borderThickness))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        };

        // Initial apply
        ApplyRegion(panel, radius);
    }

    /// <summary>
    /// Enable rounded corners with a border for a SplitContainer.
    /// </summary>
    public static void EnableRoundedSplitContainer(SplitContainer split, int radius = 12, int borderThickness = 1)
    {
        split.Resize += (s, e) => ApplyRegion(split, radius);
        split.Paint += (s, e) =>
        {
            using (var path = CreatePath(split, radius))
            using (var pen = new Pen(Color.Transparent, borderThickness))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        };

        ApplyRegion(split, radius);
    }

    /// <summary>
    /// Set the default size for the main form.
    /// </summary>
    public static void SetDefaultFormSize(Form form, int width = 900, int height = 700)
    {
        form.Size = new Size(width, height);
    }

    /// <summary>
    /// Calculate the current DPI scaling factor for consistent UI sizing.
    /// Returns 1.0f at 96 DPI (default baseline).
    /// </summary>
    public static float GetDpiScale(Control ctrl)
    {
        using (Graphics g = ctrl.CreateGraphics())
        {
            return g.DpiX / 96f;
        }
    }

    /// <summary>
    /// Apply the rounded region to the panel.
    /// </summary>
    private static void ApplyRegion(Control ctrl, int radius)
    {
        using (var path = CreatePath(ctrl, radius))
        {
            ctrl.Region = new Region(path);
        }
    }

    /// <summary>
    /// Build a rounded rectangle path for given control size.
    /// </summary>
    private static GraphicsPath CreatePath(Control ctrl, int radius)
    {
        var path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
        path.AddArc(new Rectangle(ctrl.Width - radius, 0, radius, radius), 270, 90);
        path.AddArc(new Rectangle(ctrl.Width - radius, ctrl.Height - radius, radius, radius), 0, 90);
        path.AddArc(new Rectangle(0, ctrl.Height - radius, radius, radius), 90, 90);
        path.CloseFigure();
        return path;
    }
}