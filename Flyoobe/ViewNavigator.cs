using Flyoobe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public sealed class ViewNavigator
{
    private readonly Panel _host;                    // hosts the active view inside the main panel
    private readonly TreeView _tree;                 // navigation tree for switching setup sections
    private readonly Action<string> _onViewChanged;  // callback to update window title or UI when view changes
    private readonly ToolStripButton _nextBtn;       // "Next" button that shows the current step and moves to the next one

    private readonly Dictionary<string, Func<UserControl>> _factories = new Dictionary<string, Func<UserControl>>();
    private readonly Dictionary<string, UserControl> _cache = new Dictionary<string, UserControl>();

    public UserControl CurrentView { get; private set; }

    // track the current logical nav key (matches arrays)
    private string _currentKey;

    // Logical navigation order
    private static readonly string[] SetupViews = { "Home", "Upgrade", "Reinstall" };

    private static readonly string[] OobeViews = {
        "Device", "Personalization", "Browser", "AI", "Network",
        "Account", "Apps", "Experience", "Installer", "Updates"
    };

    // Extension-related setup steps
    private static readonly string[] ExtensionViews = {
            "Extensions", "Post-Setup"
        };

    public ViewNavigator(Panel hostPanel, TreeView treeView, Action<string> onViewChanged, ToolStripButton nextButton = null)
    {
        _host = hostPanel;
        _tree = treeView;
        _onViewChanged = onViewChanged;
        _nextBtn = nextButton;

        ConfigureTreeAppearance();
        WireTreeEvents();

        if (_nextBtn != null)
            _nextBtn.Click += (s, e) => ShowNextView();
    }

    // ---------- TREEVIEW STYLE ----------
    /// <summary>
    /// Applies style to the TreeView.
    /// </summary>
    private void ConfigureTreeAppearance()
    {
        _tree.BorderStyle = BorderStyle.None;
        _tree.BackColor = Color.FromArgb(248, 249, 251);
        _tree.ForeColor = Color.FromArgb(30, 30, 30);
        _tree.FullRowSelect = true;
        _tree.HideSelection = false;
        _tree.Indent = 20;
        _tree.ItemHeight = 28;
    }

    /// <summary>
    /// Handles click navigation for TreeView nodes.
    /// Loads the appropriate view when a leaf node is selected,
    /// and ignores category headers.
    /// </summary>
    private void WireTreeEvents()
    {
        _tree.AfterSelect += (s, e) =>
        {
            string key = e.Node.Text;

            // Handle main headers (expand only)
            if (key == "Install Operating System" || key == "Setup Operating System")
            {
                if (e.Node.IsExpanded)
                    e.Node.Collapse();
                else
                    e.Node.Expand();
                return;
            }

            // Handle Finalize Setup header
            if (key == "Finalize Setup")
            {
                e.Node.Expand();
                // Show the same view as Extensions
                ShowView("Extensions");
                return;
            }

            // Show the corresponding view
            ShowView(key);
        };
    }

    /// <summary>
    /// Register a view and its factory.
    /// </summary>
    public void RegisterView(string name, Func<UserControl> factory)
    {
        _factories[name] = factory;
    }

    /// <summary>
    /// Build the navigation tree (Install + Setup).
    /// </summary>
    public void BuildSidebarNavigation()
    {
        _tree.Nodes.Clear();
        Font headerFont = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);

        // Install OS section
        TreeNode installNode = new TreeNode("Install Operating System") { NodeFont = headerFont };
        foreach (string v in SetupViews)
            installNode.Nodes.Add(new TreeNode(v));

        // OOBE setup section
        TreeNode setupNode = new TreeNode("Setup Operating System") { NodeFont = headerFont };
        foreach (string v in OobeViews)
            setupNode.Nodes.Add(new TreeNode(v));

        // Extensions section
        TreeNode extensionsGroup = new TreeNode("Finalize Setup") { NodeFont = headerFont };
        foreach (string view in ExtensionViews)
            extensionsGroup.Nodes.Add(new TreeNode(view));

        // Add the new section to the setup tree
        setupNode.Nodes.Add(extensionsGroup);
        extensionsGroup.Collapse();

        // ========== FINALIZE TREE ==========
        // Expand or collapse sections depending on Windows version
        bool isWin11 = Utils.DetectWindows11();
        installNode.Expand();
        if (isWin11)
            setupNode.Expand();
        else
            setupNode.Collapse();

        // Add the root nodes to the TreeView control
        _tree.Nodes.Add(installNode);
        _tree.Nodes.Add(setupNode);
    }

    /// <summary>
    /// Displays a view in the host panel.
    /// </summary>
    public void ShowView(string name)
    {
        // always set current key first – even for special cases like "Upgrade"
        _currentKey = name;

        if (name == "Upgrade")
        {
            TryLaunchUpgradeHelper();
            return;
        }

        if (!_factories.ContainsKey(name))
            return;

        _host.Controls.Clear();

        if (!_cache.TryGetValue(name, out var control))
        {
            control = _factories[name]();
            control.Dock = DockStyle.Fill;
            _cache[name] = control;
        }

        CurrentView = control;
        _host.Controls.Add(control);

        _onViewChanged?.Invoke((control as IView)?.ViewTitle ?? name);

        HighlightActiveNode(name);
        //Update the Next button label after switching view
        UpdateNextButton();
    }

    /// <summary>
    /// Launches Flyby11.exe (Upgrade Helper) safely.
    /// </summary>
    private void TryLaunchUpgradeHelper()
    {
        try
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app", "Flyby11.exe");
            if (File.Exists(exePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = "--f-u-tpm",
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Flyby11.exe not found in the app folder.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to start Flyby11.exe:\n" + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Keeps the TreeView node selection in sync.
    /// </summary>
    private void HighlightActiveNode(string name)
    {
        foreach (TreeNode root in _tree.Nodes)
        {
            foreach (TreeNode node in root.Nodes)
            {
                if (string.Equals(node.Text, name, StringComparison.OrdinalIgnoreCase))
                {
                    _tree.SelectedNode = node;
                    node.EnsureVisible();
                    node.Parent?.Expand();
                    return;
                }
            }
        }
    }

    // ========== Next Button ==========
    /// <summary>
    /// Shows the next logical setup view.
    /// </summary>
    private void ShowNextView()
    {
        var allViews = SetupViews.Concat(OobeViews).Concat(ExtensionViews).ToList();

        int index = allViews.IndexOf(_currentKey);
        if (index >= 0 && index < allViews.Count - 1)
            ShowView(allViews[index + 1]);
    }

    /// <summary>
    /// Updates the button label to match the current step.
    /// </summary>
    private void UpdateNextButton()
    {
        if (_nextBtn == null)
            return;

        var allViews = SetupViews.Concat(OobeViews).Concat(ExtensionViews).ToList();

        // Label shows current step, or "Start" initially
        string label = string.IsNullOrEmpty(_currentKey) ? "Start Setup" : $"{_currentKey}";
        _nextBtn.Text = label;

        // Optional tooltip
        _nextBtn.ToolTipText = "Click to move to the next setup step";
    }
}