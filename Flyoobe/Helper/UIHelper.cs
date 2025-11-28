using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class UIHelper
{
    /// <summary>
    /// Set the default size for the main form.
    /// </summary>
    public static void SetDefaultFormSize(Form form, int width = 1050, int height = 700)
    {
        form.Size = new Size(width, height);
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
            using (var pen = new Pen(Color.Gainsboro, borderThickness))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        };

        // Initial apply
        ApplyRegion(panel, radius);
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