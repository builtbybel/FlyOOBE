using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public static class Logger
    {
        private static LogForm loggerFormInstance;
        private static readonly List<(string Message, Color Color)> logBuffer = new List<(string, Color)>();
        private static Form mainForm;

        /// <summary>
        /// Sets the LoggerForm instance dynamically.
        /// </summary>
        public static void SetLogForm(LogForm loggerForm)
        {
            if (loggerForm == null)
                throw new ArgumentNullException(nameof(loggerForm), "LoggerForm cannot be null.");

            loggerFormInstance = loggerForm;

            // Flush any buffered logs to the UI
            foreach (var log in logBuffer)
            {
                loggerFormInstance.AddLog(log.Message, log.Color);
            }

            //   logBuffer.Clear();
        }

        /// <summary>
        /// Logs a message using the given LogLevel.
        /// Each level has its own color.
        /// </summary>
        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            Color color;

            switch (level)
            {
                case LogLevel.Warning:
                    color = Color.Olive;
                    break;

                case LogLevel.Error:
                    color = Color.ForestGreen;
                    break;

                default:
                    color = Color.Black;
                    break;
            }

            Log(message, color);
        }

        /// <summary>
        /// Logs a message with an explicit color.
        /// </summary>
        public static void Log(string message, Color color)
        {
            string timestampedMessage = $"{DateTime.Now:HH:mm:ss} - {message}";

            if (loggerFormInstance != null)
            {
                loggerFormInstance.AddLog(timestampedMessage, color);
            }
            else
            {
                logBuffer.Add((timestampedMessage, color));
            }
        }

        /// <summary>
        /// Creates and shows (or hides) the LogForm window.
        /// </summary>
        public static void ToggleLogForm(Form parentForm)
        {
            if (parentForm == null)
                throw new ArgumentNullException(nameof(parentForm));

            mainForm = parentForm;

            // Check if there is no existing form or the old one was disposed
            if (loggerFormInstance == null || loggerFormInstance.IsDisposed)
            {
                loggerFormInstance = new LogForm
                {
                    Text = "OOBEE • Console",
                    Size = new Size(400, 600),
                    TopMost = true,
                    StartPosition = FormStartPosition.Manual
                };

                // Prevent the form from being destroyed when the user clicks "X"
                // Instead, just hide it and reset the main form opacity
                loggerFormInstance.FormClosing += (s, e) =>
                {
                    e.Cancel = true;
                    loggerFormInstance.Hide();
                    if (mainForm != null)
                        mainForm.Opacity = 1.0;
                };

                // Register this form as the global logger target
                SetLogForm(loggerFormInstance);
            }

            // Safety check in case the form was disposed unexpectedly
            if (loggerFormInstance == null || loggerFormInstance.IsDisposed)
                return;

            // Toggle visibility
            if (loggerFormInstance.Visible)
            {
                // Hide the logger form and restore main form opacity
                loggerFormInstance.Hide();
                mainForm.Opacity = 1.0;
            }
            else
            {
                // Position the logger window relative to the main form
                loggerFormInstance.Location = new Point(
                    parentForm.Right - 400,
                    parentForm.Top + 50);

                // Show the logger form and dim the main form slightly
                loggerFormInstance.Show();
                loggerFormInstance.BringToFront();
                mainForm.Opacity = 0.9;
            }
        }
    }
}