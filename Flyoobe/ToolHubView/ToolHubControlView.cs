using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Flyoobe.ToolHub
{
    public partial class ToolHubControlView : UserControl, IView
    {
        private readonly ToolHubCategory _category; // The category this view represents
        private readonly List<ToolHubDefinition> _allTools = new List<ToolHubDefinition>();

        public virtual string ViewTitle => "Setup Extensions";

        // Default constructor (shows Post-Setup tools)
        public ToolHubControlView() : this(ToolHubCategory.Tool) { }

        // Overloaded constructor with category filter
        public ToolHubControlView(ToolHubCategory category)
        {
            InitializeComponent();
            _category = category;
            LoadTools();
        }

        private void LoadTools()
        {
            _allTools.Clear();
            flowLayoutPanelTools.Controls.Clear();

            // Define the scripts directory relative to the executable path
            string scriptDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");

            // If the directory does not exist, create it
            if (!Directory.Exists(scriptDirectory))
            {
                Directory.CreateDirectory(scriptDirectory);
                return;
            }

            // Get all .ps1 files in the folder
            string[] scriptFiles = Directory.GetFiles(scriptDirectory, "*.ps1");

            // Loop through each script and create a tool item
            foreach (var scriptPath in scriptFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(scriptPath); // Use file name as title
                string icon = PickIconForScript(fileName);                      // Choose an icon based on the name

                // Read metadata (description, options, category, etc.)
                var meta = ReadMetadataFromScript(scriptPath);

                // Skip tools not matching the current category
                if (_category != ToolHubCategory.All && meta.category != _category)
                    continue;

                // Create tool definition
                var tool = new ToolHubDefinition(fileName, meta.description, icon, scriptPath);
                tool.Options.AddRange(meta.options);
                tool.UseConsole = meta.useConsole;
                tool.UseLog = meta.useLog;

                // Create the UI control for this tool
                var control = new ToolHubItemControl(tool);
                flowLayoutPanelTools.Controls.Add(control);

                // Save for search/filter
                _allTools.Add(tool);

                // Debugging aid
                // MessageBox.Show($"Tool: {fileName}\nUseConsole={tool.UseConsole}\nUseLog={tool.UseLog}");
            }

            DisplayFilteredTools("");
        }

        /// <summary>
        /// Reads metadata from a script header, such as description, category, and options.
        /// Example in .ps1:
        /// # Description: Cleans pre-installed apps
        /// # Category: Post
        /// # Options: Light;Full
        /// # Host: log
        /// </summary>
        private (string description, List<string> options, ToolHubCategory category, bool useConsole, bool useLog)
            ReadMetadataFromScript(string scriptPath)
        {
            string description = "No description available.";
            var options = new List<string>();
            ToolHubCategory category = ToolHubCategory.All;
            bool useConsole = false;
            bool useLog = false;

            try
            {
                // Only scan the first lines for metadata.
                // Extensions put their headers (# Description, # Host, # Options) at the top,
                // so we dont waste time parsing a huge script body.
                var lines = File.ReadLines(scriptPath).Take(15);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    if (line.StartsWith("# Description:", StringComparison.OrdinalIgnoreCase))
                    {
                        description = line.Substring(14).Trim();
                    }
                    else if (line.StartsWith("# Category:", StringComparison.OrdinalIgnoreCase))
                    {
                        string raw = line.Substring(11).Trim().ToLowerInvariant();
                        if (raw == "pre") category = ToolHubCategory.Pre;
                        else if (raw == "mid") category = ToolHubCategory.Mid;
                        else if (raw == "tool") category = ToolHubCategory.Tool;
                        else if (raw == "post") category = ToolHubCategory.Post;
                        else category = ToolHubCategory.All;
                    }
                    else if (line.StartsWith("# Options:", StringComparison.OrdinalIgnoreCase))
                    {
                        // Parse dropdown options
                        options = line.Substring(10)
                            .Split(';')
                            .Select(x => x.Trim())
                            .Where(x => !string.IsNullOrEmpty(x)) // ignore empty entries
                            .ToList();
                    }
                    else if (line.StartsWith("# Host:", StringComparison.OrdinalIgnoreCase))
                    {
                        // Parse host type
                        var raw = line.Substring(7).Trim().ToLowerInvariant();
                        if (raw == "console") // standard console window
                            useConsole = true;
                        else if (raw == "log") // custom log viewer
                            useLog = true;
                        // "embedded"/"silent" == both false
                    }
                    else if (line.StartsWith("#"))
                    {
                        // Use the first regular comment as description (if none yet)
                        if (description == "No description available.")
                            description = line.TrimStart('#').Trim();
                    }
                }
            }
            catch
            {
                // Ignore errors and keep defaults
            }

            return (description, options, category, useConsole, useLog);
        }

        private string PickIconForScript(string name)
        {
            name = name.ToLower();

            // Basic keyword-based icon picking using Segoe MDL2 Assets
            if (name.Contains("debloat")) return "\uE74D";      // Trash icon (cleanup)
            if (name.Contains("network")) return "\uE701";      // Network icon (network tools)
            if (name.Contains("explorer")) return "\uE8B7";     // File Explorer icon (file management)
            if (name.Contains("update")) return "\uE895";       // Update icon (system updates)
            if (name.Contains("context")) return "\uE8A5";      // Menu icon (context menu tweaks)

            // Additional general categories
            if (name.Contains("backup")) return "\uE8C7";       // Save icon (backup tools)
            if (name.Contains("security")) return "\uE72E";     // Shield icon (security tools)
            if (name.Contains("performance")) return "\uE7B8";  // Speedometer icon (performance)
            if (name.Contains("privacy")) return "\uF552";      // Privacy icon (privacy settings)
            if (name.Contains("app")) return "\uED35";          // App icon (application management)
            if (name.Contains("setup")) return "\uE8FB";        // Install icon (installers)

            return "\uE7C5"; // Wrench icon (default for uncategorized tools)
        }

        private void DisplayFilteredTools(string filter)
        {
            flowLayoutPanelTools.SuspendLayout();
            flowLayoutPanelTools.Controls.Clear();

            // Apply case-insensitive search filter
            foreach (var tool in _allTools)
            {
                if (string.IsNullOrWhiteSpace(filter) ||
                    tool.Title.ToLower().Contains(filter.ToLower()) ||
                    tool.Description.ToLower().Contains(filter.ToLower()))
                {
                    var control = new ToolHubItemControl(tool);
                    flowLayoutPanelTools.Controls.Add(control);
                }
            }

            flowLayoutPanelTools.ResumeLayout();
        }

        /// <summary>
        /// Selects a specific tool in the ToolHub by its name.
        /// Called from outside (e.g. HomeControlView) to directly show or highlight a tool.
        /// </summary>
        public void SelectTool(string toolName)
        {
            if (string.IsNullOrWhiteSpace(toolName))
                return;

            // Try to find the tool in the loaded list (_allTools) by title
            // Comparison is case-insensitive
            var tool = _allTools.FirstOrDefault(t =>
                t.Title.Equals(toolName, StringComparison.OrdinalIgnoreCase));

            if (tool != null)
            {
                // Clear the tool panel and show just the requested tool
                flowLayoutPanelTools.SuspendLayout();
                flowLayoutPanelTools.Controls.Clear();

                // Create a new UI control for the found tool
                var control = new ToolHubItemControl(tool);

                // Highlight and auto-select
                control.BackColor = Color.FromArgb(230, 240, 255);

                flowLayoutPanelTools.Controls.Add(control);
                flowLayoutPanelTools.ResumeLayout();
            }
            else
            {
                // just a Fallback behavior
                // If no exact tool match was found, use the normal filter logic.
                // This will show all tools that contain the search string.
                DisplayFilteredTools(toolName);
            }
        }

        public void RefreshView()
        {
            textSearch.Clear();
            flowLayoutPanelTools.Controls.Clear();
            LoadTools();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            var keyword = textSearch.Text.Trim();
            DisplayFilteredTools(keyword);
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Clear();
        }
    }
}
