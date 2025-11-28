using System.Collections.Generic;

namespace Flyoobe.ToolHub
{
    public class ToolHubDefinition
    {
        public string Title { get; }
        public string Description { get; }
        public string Icon { get; }
        public string ScriptPath { get; }
        public List<string> Options { get; } = new List<string>(); // Dropdown options
        public bool UseConsole { get; set; } = false; // Console host
        public bool UseLog { get; set; } // optional log viewer

        // Optional free-text input support for a tool (e.g., ViVe ID list, custom args)
        public bool SupportsInput { get; set; }
        public string InputPlaceholder { get; set; }

        // Optional "Powered by" attribution
        public string PoweredByText { get; set; }   // e.g. "Powered by Chris Titus Tech"
        public string PoweredByUrl { get; set; }

        public ToolHubDefinition(string title, string description, string icon, string scriptPath)
        {
            Title = title;
            Description = description;
            Icon = icon;
            ScriptPath = scriptPath;
            // Defaults for optional features
            SupportsInput = false;
            InputPlaceholder = string.Empty;

            // Defaults for "Powered by"
            PoweredByText = string.Empty;
            PoweredByUrl = string.Empty;
        }
    }
}