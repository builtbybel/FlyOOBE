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


        public ToolHubDefinition(string title, string description, string icon, string scriptPath)
        {
            Title = title;
            Description = description;
            Icon = icon;
            ScriptPath = scriptPath;
        }
    }
}