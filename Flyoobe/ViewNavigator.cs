using Flyoobe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Central navigation controller for the entire application.
///
/// Responsibilities:
/// - Hosts all top-level pages (Home, OobeControl, Settings, Extensions).
/// - Hosts all OOBE sub-pages (Device, Network, etc.) *inside* the active OobeControl.
/// - Maintains a global back-stack.
/// - Updates the main window title via callback.
/// - Allows pages to refresh when shown.
/// - Supports metadata-driven titles.
///
/// No Next button is required. Only a global Back button exists.
/// </summary>
public sealed class ViewNavigator
{
    // --------------------------------------------------------------------
    // Fields
    // --------------------------------------------------------------------

    private readonly Panel _rootHost;                 // Panel on MainForm that hosts top-level views
    private readonly Action<string> _onViewChanged;   // Callback to update MainForm title/header
    private readonly Button _backBtn;                 // Global back button (MainForm only)

    /// <summary>
    /// Factory map:  
    /// Holds a collection of view-constructors keyed by logical view name.
    /// 
    /// Purpose:
    /// - Allows any view to be created on demand by name.
    /// - Decouples navigation from concrete UserControl types.
    /// - Ensures views are created only when needed.
    /// </summary>
    private readonly Dictionary<string, Func<UserControl>> _factories
        = new Dictionary<string, Func<UserControl>>(StringComparer.OrdinalIgnoreCase);


    /// <summary>
    /// View cache:  
    /// Stores already-created view instances to avoid recreating controls.
    /// 
    /// Purpose:
    /// - Ensures expensive UserControls are only constructed once.
    /// - Improves performance and preserves state between navigations.
    /// - Allows ShowView() to instantly re-display previously loaded screens.
    /// </summary>
    private readonly Dictionary<string, UserControl> _cache
        = new Dictionary<string, UserControl>(StringComparer.OrdinalIgnoreCase);


    /// <summary>
    /// Global navigation history:  
    /// Tracks previously visited views in reverse order (stack-based).
    /// 
    /// Purpose:
    /// - Implements the global Back-button behavior.
    /// - Allows a single central Back-button to undo navigation steps.
    /// - Works across all pages, including OOBE and top-level views.
    /// </summary>
    private readonly Stack<string> _history = new Stack<string>();



    // --------------------------------------------------------------------
    // Public Properties
    // --------------------------------------------------------------------

    /// <summary>
    /// The logical OOBE setup sequence.
    /// These steps will be loaded into OobeControl.ContentPanel.
    /// </summary>
    public readonly string[] OobeSteps =
    {
        "Device", "Personalization", "Browser", "AI", "Network",
        "Account", "Apps", "Experience", "Installer", "Updates", "Advanced"
    };

    /// <summary>
    /// Provides external access to the OOBE step list.
    /// Used e.g. in HomeControlView to build tiles dynamically.
    /// </summary>
    public IEnumerable<string> OobeStepsWithoutHome => OobeSteps;

    /// <summary>
    /// Current loaded view key.
    /// </summary>
    public string CurrentKey { get; private set; }

    /// <summary>
    /// Current loaded UserControl instance.
    /// </summary>
    public UserControl CurrentView { get; private set; }

    // --------------------------------------------------------------------
    // Constructor
    // --------------------------------------------------------------------

    private readonly OobeControl _oobeControl;
    public ViewNavigator(
        Panel rootHost,
        Action<string> onViewChanged,
        Button backButton)
    {
        _rootHost = rootHost;
        _onViewChanged = onViewChanged;
        _backBtn = backButton;

        // Create and prepare OOBE container internally
        _oobeControl = new OobeControl();
        _oobeControl.Dock = DockStyle.Fill;
        _oobeControl.Visible = false;

        // Add it to the root host once (stays hidden until needed)
        _rootHost.Controls.Add(_oobeControl);

        if (_backBtn != null)
            _backBtn.Click += (s, e) => Back();

        UpdateBackButtonState();
    }


    // --------------------------------------------------------------------
    // Registration
    // --------------------------------------------------------------------

    /// <summary>
    /// Registers a view factory for a specific name.
    /// </summary>
    public void RegisterView(string name, Func<UserControl> factory)
    {
        _factories[name] = factory;
    }

    // --------------------------------------------------------------------
    // Core Load Logic
    // --------------------------------------------------------------------

    /// <summary>
    /// Loads a view by name.
    ///
    /// There are two rendering modes:
    /// 1. OOBE steps > rendered inside the OobeControl container.
    /// 2. Normal top-level pages > rendered directly into the root host panel.
    /// </summary>
    private void Load(string name)
    {
        // Ensure the view exists
        if (!_factories.ContainsKey(name))
            return;

        CurrentKey = name;

        // Retrieve or create cached instance
        if (!_cache.TryGetValue(name, out var control))
        {
            control = _factories[name]();
            control.Dock = DockStyle.Fill;
            _cache[name] = control;
        }

        CurrentView = control;

        // Update window title based on metadata or fallback
        if (ViewMetadata.Pages.TryGetValue(name, out var meta))
            _onViewChanged?.Invoke(meta.Title);
        else
            _onViewChanged?.Invoke(name);

        // --------------------------------------------------------------------
        // CASE 1: OOBE step > display inside OobeControl
        // --------------------------------------------------------------------
        if (OobeSteps.Contains(name))
        {
            // Show the OOBE container
            _oobeControl.Visible = true;

            // Activate the OobeControl inside the root host.
            // We only replace the current root-host content if it is NOT
            // already displaying the OobeControl. This bprevents unnecessary Clear() + Add() operations,
            // which would otherwise cause visible flicker when switching
            if (_rootHost.Controls.Count == 0 || _rootHost.Controls[0] != _oobeControl)
            {
                _rootHost.Controls.Clear();   // Remove any existing top-level page only once
                _rootHost.Controls.Add(_oobeControl);     // Insert the OobeControl as the active container
            }


            // Build sidebar only once
            if (_oobeControl.SidebarPanel.Controls.Count == 0)
                BuildOobeSidebar(_oobeControl.SidebarPanel);

            // Load the step into the OOBE content panel
            var host = _oobeControl.ContentPanel;
            host.Controls.Clear();
            host.Controls.Add(control);

            // Highlight the active step in the sidebar
            HighlightStep(name);

            UpdateBackButtonState();
            return;
        }

        // --------------------------------------------------------------------
        // CASE 2: Normal top-level page > hide the OOBE container
        // --------------------------------------------------------------------
        _oobeControl.Visible = false;

        _rootHost.Controls.Clear();
        _rootHost.Controls.Add(control);

        UpdateBackButtonState();
    }

    // --------------------------------------------------------------------
    // Navigation
    // --------------------------------------------------------------------

    public void ShowView(string name)
    {
        if (CurrentKey != null && CurrentKey != name)
            _history.Push(CurrentKey);

        Load(name);
    }

    public void Back()
    {
        if (_history.Count == 0)
            return;

        var previous = _history.Pop();
        Load(previous);
    }

    // --------------------------------------------------------------------
    // Sidebar (OOBE)
    // --------------------------------------------------------------------

    private void BuildOobeSidebar(Panel sidebar)
    {
        sidebar.Controls.Clear();

        using (var g = sidebar.CreateGraphics())
        {
            // Dynamically scale height based on font and system DPI
            int textHeight = TextRenderer.MeasureText(g, "Ag", sidebar.Font).Height;
            int paddingScaled = (int)(20 * (g.DpiY / 96f));  // padding scaled with DPI
            int btnHeight = textHeight + paddingScaled;

            foreach (var step in OobeSteps.Reverse()) // lets ensure correct top-down order
            {
                var btn = new Button
                {
                    Text = step,
                    Tag = step,
                    Dock = DockStyle.Top,
                    Height = btnHeight,
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true,
                    Padding = new Padding(10, 0, 0, 0),
                    ForeColor = Color.DimGray,
                    BackColor = Color.Transparent
                };

                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.White;

                btn.Click += (s, e) =>
                {
                    string key = btn.Tag.ToString();
                    ShowView(key);
                };

                sidebar.Controls.Add(btn);
            }
        }

        HighlightStep(CurrentKey);
    }

    private void HighlightStep(string step)
    {
        if (_oobeControl == null) return;

        foreach (Control c in _oobeControl.SidebarPanel.Controls)
        {
            if (c is Button btn)
            {
                bool active = btn.Tag.ToString() == step;
                btn.ForeColor = active ? Color.FromArgb(91, 95, 194) : Color.DimGray;
            }
        }
    }

    // --------------------------------------------------------------------
    // Button Handling
    // --------------------------------------------------------------------

    private void UpdateBackButtonState()
    {
        if (_backBtn != null)
            _backBtn.Enabled = _history.Count > 0;
    }
}