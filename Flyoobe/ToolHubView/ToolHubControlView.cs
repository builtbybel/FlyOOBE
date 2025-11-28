using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe.ToolHub
{
    public partial class ToolHubControlView : UserControl, IView, IHasSearch
    {
        private ToolHubCategory _category; // The category this view represents
        private readonly List<ToolHubDefinition> _allTools = new List<ToolHubDefinition>();

        // Caches UI controls for each tool so they are not recreated every time.
        private readonly Dictionary<ToolHubDefinition, ToolHubItemControl> _controlCache
            = new Dictionary<ToolHubDefinition, ToolHubItemControl>();

        // Pending tool selection (if any) to apply after loading
        private string _pendingSelectTool = null;

        // Overloaded constructor with category filter
        public ToolHubControlView(ToolHubCategory category = ToolHubCategory.All)
        {
            InitializeComponent();
            _category = category;
            comboFilter.Items.AddRange(new object[] { "All", "Tool", "Pre", "Mid", "Post" });
            //comboFilter.SelectedItem = _category.ToString();
            // Prevent the SelectedIndexChanged event from firing during initial setup,
            // because changing SelectedIndex will otherwise trigger LoadTools() too early.
            comboFilter.SelectedIndexChanged -= comboFilter_SelectedIndexChanged;
            comboFilter.SelectedIndex = 0; // Set default filter UI state without applying filtering logic yet
            comboFilter.SelectedIndexChanged += comboFilter_SelectedIndexChanged;

            LoadTools();
        }

        private async void LoadTools()
        {
            lblStatus.Visible = true;
            // Prevent flicker during bulk UI update
            flowLayoutPanelTools.SuspendLayout();
            flowLayoutPanelTools.Controls.Clear();
            _controlCache.Clear();
            _allTools.Clear();

            // Define the scripts directory relative to the executable path
            string scriptDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");

            // If the directory does not exist, create it
            if (!Directory.Exists(scriptDirectory))
            {
                Directory.CreateDirectory(scriptDirectory);
                flowLayoutPanelTools.ResumeLayout();
                return;
            }

            // Get all .ps1 files in the folder (async to avoid UI freeze)
            string[] scriptFiles = await Task.Run(() => Directory.GetFiles(scriptDirectory, "*.ps1"));

            // Parse metadata and construct tool definitions in background
            var loadedTools = await Task.Run(() =>
            {
                var list = new List<ToolHubDefinition>();

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
                    tool.SupportsInput = meta.inputEnabled;
                    tool.InputPlaceholder = meta.inputPh;
                    tool.PoweredByText = meta.poweredByText;
                    tool.PoweredByUrl = meta.poweredByUrl;
                    list.Add(tool);                // Save for search/filter
                }

                return list;
            });

            // Create UI controls now, but only once (no recreation during filtering)
            foreach (var tool in loadedTools)
            {
                var control = new ToolHubItemControl(tool);
                _controlCache[tool] = control; // Cache it so filtering is instant
                flowLayoutPanelTools.Controls.Add(control);
                _allTools.Add(tool);
            }

            lblStatus.Visible = false;
            flowLayoutPanelTools.ResumeLayout();

            // After everything is loaded, apply the pending selection (if any)
            if (!string.IsNullOrEmpty(_pendingSelectTool))
            {
                SelectTool(_pendingSelectTool);
                _pendingSelectTool = null;
            }
        }

        /// <summary>
        /// Reads metadata from a script header, such as description, category, and options.
        /// Example in .ps1:
        /// # Description: Cleans pre-installed apps
        /// # Category: Post
        /// # Options: Light;Full
        /// # Host: log
        /// </summary>
        // Parses script header metadata (first ~15 lines) and returns all fields.
        private (string description,
                 List<string> options,
                 ToolHubCategory category,
                 bool useConsole,
                 bool useLog,
                 bool inputEnabled,
                 string inputPh,
                 string poweredByText,
                 string poweredByUrl)
            ReadMetadataFromScript(string scriptPath)
        {
            string description = "No description available.";
            var options = new List<string>();
            ToolHubCategory category = ToolHubCategory.All;
            bool useConsole = false;
            bool useLog = false;
            bool inputEnabled = false;
            string inputPh = string.Empty;
            string poweredByText = string.Empty;
            string poweredByUrl = string.Empty;

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
                    else if (line.StartsWith("# Input:", StringComparison.OrdinalIgnoreCase))
                    {
                        var raw = line.Substring(8).Trim().ToLowerInvariant();
                        inputEnabled = (raw == "true" || raw == "yes" || raw == "1");
                    }
                    else if (line.StartsWith("# InputPlaceholder:", StringComparison.OrdinalIgnoreCase))
                    {
                        inputPh = line.Substring(19).Trim();
                    }
                    // PoweredBy metadata (optional)
                    else if (line.StartsWith("# PoweredBy:", StringComparison.OrdinalIgnoreCase))
                        poweredByText = line.Substring(12).Trim();   // 11 chars + 1 for :
                    else if (line.StartsWith("# PoweredUrl:", StringComparison.OrdinalIgnoreCase))
                        poweredByUrl = line.Substring(13).Trim();    // 12 chars + 1 for :

                    // Use the first regular comment as description (if none yet)
                    else if (line.StartsWith("#"))
                    {
                        if (description == "No description available.")
                            description = line.TrimStart('#').Trim();
                    }
                }
            }
            catch
            {
                // Ignore errors and keep defaults
            }
            return (description, options, category, useConsole, useLog, inputEnabled, inputPh, poweredByText, poweredByUrl);
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

            string f = filter?.ToLowerInvariant() ?? "";

            foreach (var kv in _controlCache)
            {
                var tool = kv.Key;
                var control = kv.Value;

                bool show = string.IsNullOrWhiteSpace(f)
                            || tool.Title.ToLower().Contains(f)
                            || tool.Description.ToLower().Contains(f);

                if (show)
                    flowLayoutPanelTools.Controls.Add(control);
            }

            flowLayoutPanelTools.ResumeLayout();
        }

        /// <summary>
        /// Selects a tool in the ToolHub by its display title.
        /// If the tools are not loaded yet (asynchronous loading), the selection request is stored
        /// and applied automatically once loading finishes.
        /// </summary>
        /// <param name="toolName">The display title of the tool to select.</param>
        public void SelectTool(string toolName)
        {
            // If controls havent been created yet (async load still ongoing),
            // defer selection until after loading completes.
            if (_controlCache.Count == 0)
            {
                _pendingSelectTool = toolName;
                return;
            }

            // Show only the tool matching the requested title and hide all others
            foreach (var kv in _controlCache)
            {
                var tool = kv.Key;
                var control = kv.Value;

                bool match = string.Equals(tool.Title, toolName, StringComparison.OrdinalIgnoreCase);

                control.Visible = match;

                if (match)
                {
                    // Highlight selected tool
                    control.BackColor = Color.FromArgb(230, 240, 255);
                }
                else
                {
                    // Reset background of non-selected tools
                    control.BackColor = SystemColors.Control;
                }
            }
        }

        public void RefreshView()
        {
            flowLayoutPanelTools.Controls.Clear();
            LoadTools();
        }

        /// <summary>
        /// Applies global search input to the tool list.
        /// </summary>
        public void OnGlobalSearchChanged(string text)
        {
            DisplayFilteredTools(text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            contextDropDown.Show(btnAdd, new Point(0, btnAdd.Height));
        }

        private async void toolStripMenuInstallUrl_Click(object sender, EventArgs e)
        {
            await ToolHub.ExtensionsHelper.InstallFromUrlAsync(this);
        }

        private void toolStripMenuInstallLocal_Click(object sender, EventArgs e)
        {
            ToolHub.ExtensionsHelper.ImportLocalFile(this);
        }

        private void toolStripMenuWriteExtension_Click(object sender, EventArgs e)
        {
            ToolHub.ExtensionsHelper.OpenExtensionGuide();
        }

        private void toolStripMenuExtensionDirectory_Click(object sender, EventArgs e)
        {
            ToolHub.ExtensionsHelper.OpenScriptsFolder(this);
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboFilter.SelectedItem.ToString())
            {
                case "Tool": _category = ToolHubCategory.Tool; break;
                case "Pre": _category = ToolHubCategory.Pre; break;
                case "Mid": _category = ToolHubCategory.Mid; break;
                case "Post": _category = ToolHubCategory.Post; break;
                default: _category = ToolHubCategory.All; break;
            }

            LoadTools(); // re-render based on new category
        }
    }
}