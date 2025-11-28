using System.Drawing;
using System.Windows.Forms;

public class NavButton : Button
{
    public string IconGlyph { get; set; } = "";
    public string LabelText { get; set; } = "";

    private const int IconTextSpacing = 5; // distance between icon and text


    // Marks whether the button is currently active
    public bool IsActive { get; private set; } = false;

    // Active and inactive colors
    private static readonly Color ActiveColor = Color.FromArgb(91, 95, 194);
    private static readonly Color InactiveColor = Color.DimGray;

    public NavButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Cursor = Cursors.Hand;
        TextAlign = ContentAlignment.MiddleCenter;
        Font = new Font("Segoe UI", 9f, FontStyle.Regular);
        ForeColor = InactiveColor;    // default
        BackColor = Color.Transparent;
    }

    public void SetActive(bool active)
    {
        IsActive = active;
        ForeColor = active ? ActiveColor : InactiveColor;
        Invalidate(); // repaint
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        var g = pe.Graphics;

        var iconColor = IsActive ? ActiveColor : InactiveColor;
        var textColor = iconColor;

        // Fonts for icon and label
        using (var iconFont = new Font("Segoe MDL2 Assets", 15.25f))
        using (var textFont = new Font("Segoe UI", 7.5f))
        using (var brush = new SolidBrush(iconColor))
        {
            // Measure both elements
            var iconSize = g.MeasureString(IconGlyph, iconFont);
            var textSize = g.MeasureString(LabelText, textFont);

            // If active > ONLY icon, no text
            if (IsActive)
            {
                g.DrawString(
                    IconGlyph,
                    iconFont,
                    new SolidBrush(iconColor),
                    new PointF(
                        (Width - iconSize.Width) / 2,
                        (Height - iconSize.Height) / 2
                    )
                );
                return; // let us Skip drawing text
            }

            // --- inactive state > icon + text --- //
            float totalHeight = iconSize.Height + IconTextSpacing + textSize.Height;

            float startY = (Height - totalHeight) / 2;

            // Draw icon
            g.DrawString(
                IconGlyph,
                iconFont,
                brush,
                new PointF(
                    (Width - iconSize.Width) / 2,
                    startY
                )
            );

            // Draw text
            g.DrawString(
                LabelText,
                textFont,
                brush,
                new PointF(
                    (Width - textSize.Width) / 2,
                    startY + iconSize.Height + IconTextSpacing
                )
            );

        }
    }
}
