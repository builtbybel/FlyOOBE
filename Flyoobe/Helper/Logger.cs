using System;
using System.Collections.Generic;
using System.Drawing;

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
        // The active log view control where log messages are displayed
        private static LoggerControlView loggerControlInstance;

        // Temporary storage for logs before the UI is ready (e.g., during app startup)
        private static readonly List<(string Message, Color Color)> logBuffer = new List<(string, Color)>();

        // Reference to the view navigation system so we can switch to the log view on demand
        private static ViewNavigator navigator;

        // Optional: name of the current log "section" (helps group logs visually)
        private static string currentSection;

        /// <summary>
        /// Sets the LoggerControlView instance dynamically.
        /// </summary>
        public static void SetLoggerControl(LoggerControlView loggerControl)
        {
            if (loggerControl == null)
                throw new ArgumentNullException(nameof(loggerControl), "LoggerControlView cannot be null.");

            loggerControlInstance = loggerControl;

            // Flush any buffered logs to the UI
            foreach (var log in logBuffer)
            {
                loggerControlInstance.AddLog(log.Message, log.Color);
            }

            // logBuffer.Clear(); // keep buffer if history retention needed
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
                    color = Color.Firebrick;
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

            if (loggerControlInstance != null)
            {
                loggerControlInstance.AddLog(timestampedMessage, color);
            }
            else
            {
                // LoggerControlView not ready yet, so store temporarily
                logBuffer.Add((timestampedMessage, color));
            }
        }

        /// <summary>
        /// Registers the ViewNavigator so the log view can be shown when needed.
        /// </summary>
        public static void AttachNavigator(ViewNavigator nav)
        {
            navigator = nav;
        }

        /// <summary>
        /// Shows the log view.
        /// </summary>
        public static void ShowLogView()
        {
            if (navigator != null)
                navigator.ShowView("Activity");
        }

        /// <summary>
        /// Starts a new log section, visually separated in the log window.
        /// Example: Logger.BeginSection("Extension/Tool Name");
        /// </summary>
        public static void BeginSection(string sectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
                sectionName = "Unnamed Section";

            // Visually separate sections with a blank line and a header line
            string header = $"===== {sectionName.ToUpper()} ({DateTime.Now:HH:mm:ss}) =====";

            currentSection = sectionName;

            if (loggerControlInstance != null)
            {
                loggerControlInstance.AddLog(string.Empty, Color.Black);
                loggerControlInstance.AddLog(header, Color.DarkSlateBlue);
                loggerControlInstance.AddLog(string.Empty, Color.Black);
            }
            else
            {
                logBuffer.Add((string.Empty, Color.Black));
                logBuffer.Add((header, Color.DarkSlateBlue));
                logBuffer.Add((string.Empty, Color.Black));
            }
        }
    }
}
