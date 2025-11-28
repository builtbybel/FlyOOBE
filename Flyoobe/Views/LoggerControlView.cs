using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class LoggerControlView : UserControl, IView
    {
        public LoggerControlView()
        {
            InitializeComponent();
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

        public void RefreshView()
        { richTextBoxLogs.Clear(); }
    }
}