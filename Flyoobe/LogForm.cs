using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            UIHelper.EnableRoundedPanel(panelControls, 30, 1);
        }

        /// <summary>
        /// Adds a new log entry to the RichTextBox with color support.
        /// </summary>
        public void AddLog(string message, Color color)
        {
            if (richTextBoxLogs.InvokeRequired)
            {
                // Invoke on the UI thread
                richTextBoxLogs.Invoke(new Action(() => AddLog(message, color)));
            }
            else
            {
                // Perform changes directly on the UI thread
                richTextBoxLogs.SelectionColor = color;
                richTextBoxLogs.AppendText(message + Environment.NewLine);
                richTextBoxLogs.ScrollToCaret();
            }
        }

        private void LogForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = this.ClientRectangle;

            using (var brush = new LinearGradientBrush(
                       r, Color.Black, Color.Black, LinearGradientMode.Horizontal))
            {
                // blend left > right
                var blend = new ColorBlend();
                blend.Colors = new[]
                {
                Color.FromArgb(237, 235, 231), // left: soft neutral base
                Color.FromArgb(210, 170, 120), // orange hue
                Color.FromArgb(190, 120, 150), // magenta-pink
                Color.FromArgb(110, 130, 180), // soft blue
                Color.FromArgb(100, 150, 120), // muted green
                Color.FromArgb(180, 170, 120), // subtle yellow-olive
                Color.FromArgb(220, 210, 200)  // right edge: light warm grayish tint
            };
                blend.Positions = new[] { 0f, 0.25f, 0.45f, 0.65f, 0.8f, 0.9f, 1f };

                brush.InterpolationColors = blend;
                e.Graphics.FillRectangle(brush, r);
            }
        }

        private void richTextBoxLogs_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                // open the clicked URL in the default browser
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = e.LinkText,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open link:\n{ex.Message}", "OOBEE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
