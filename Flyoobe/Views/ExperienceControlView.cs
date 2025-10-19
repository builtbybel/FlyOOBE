using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class ExperienceControlView : UserControl, IView
    {
        public string ViewTitle => "Optimize Experience Settings";

        private readonly FeatureManager _featureManager;
        private List<FeatureNode> _currentTweaks;

        public ExperienceControlView()
        {
            InitializeComponent();
            _featureManager = new FeatureManager();

            // Load categories when control is loaded
            Load += (_, __) => InitializeView();
        }

        /// <summary>
        /// Initializes the category dropdown.
        /// </summary>
        private void InitializeView()
        {
            comboCategories.Items.Clear();
            comboCategories.Items.Add("Let's configure your device");
            comboCategories.Items.Add("Use quick settings (Recommended)");
            comboCategories.Items.AddRange(_featureManager.GetCategories().ToArray());

            //  if (comboCategories.Items.Count > 0)
            // comboCategories.SelectedIndex = 0; //Triggers category load

            comboCategories.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads tweak list when category changes.
        /// </summary>
        private async void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCategories.SelectedIndex <= 0) // Prevent loading if "Select Category" is selected
            {
                listSettings.Items.Clear();
                return;
            }

            string category = comboCategories.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(category))
            {
                await LoadTweaksForCategory(category);
            }
        }

        /// <summary>
        /// Loads tweak nodes and their current state for the selected category.
        /// </summary>
        private async Task LoadTweaksForCategory(string category)
        {
            listSettings.Items.Clear();

            if (category == "Use quick settings (Recommended)")
            {
                _currentTweaks = _featureManager.GetAllRecommendedFeatures();
            }
            else
            {
                _currentTweaks = _featureManager.GetFeaturesByCategory(category);
            }

            foreach (var tweak in _currentTweaks)
            {
                bool isEnabled = await _featureManager.IsEnabled(tweak);
                listSettings.Items.Add(tweak, isEnabled);
            }

            if (_currentTweaks.Count > 0)
                listSettings.SelectedIndex = 0; // Select first tweak to show info
            else
                UpdateUiContextForNoneSelected();
        }

        /// <summary>
        /// Displays tweak information and reflects state in the shared UI.
        /// </summary>
        private void listTweaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listSettings.SelectedIndex;
            if (index < 0 || index >= _currentTweaks.Count)
            {
                UpdateUiContextForNoneSelected();
                return;
            }

            var node = _currentTweaks[index];
            var feature = node.Feature;

            // Update UI
            textHelp.Text = $"{feature.Info()}\r\n\r\nDetails:\r\n{feature.GetFeatureDetails()}\r\n\r\n{feature.SupportedOS()}";
        }
        /// <summary>
        /// Applies or undoes tweaks based on checkbox state.
        /// </summary>
        private async void btnApply_Click(object sender, EventArgs e)
        {
            var appliedTweaks = new List<string>();

            for (int i = 0; i < listSettings.Items.Count; i++)
            {
                var node = _currentTweaks[i];
                bool shouldEnable = listSettings.GetItemChecked(i);
                bool isCurrentlyEnabled = await _featureManager.IsEnabled(node);

                if (shouldEnable && !isCurrentlyEnabled)
                {
                    if (await _featureManager.ApplyFeature(node))
                        appliedTweaks.Add($"✔ Applied: {node.Feature.ID()}");
                    else
                        MessageBox.Show($"Failed to apply: {node.Feature.ID()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!shouldEnable && isCurrentlyEnabled)
                {
                    if (_featureManager.UndoFeature(node))
                        appliedTweaks.Add($"✖ Reverted: {node.Feature.ID()}");
                    else
                        MessageBox.Show($"Failed to undo: {node.Feature.ID()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Show applied tweaks or fallback message
            textHelp.Text = appliedTweaks.Count > 0
                ? string.Join(Environment.NewLine, appliedTweaks)
                : "No changes were made.";

            //await ReloadCurrentCategory(); // Refresh the list to reflect changes
        }

        /// <summary>
        /// Refreshes checkbox states after apply/undo operations.
        /// </summary>
        private async Task ReloadCurrentCategory()
        {
            for (int i = 0; i < _currentTweaks.Count; i++)
            {
                var node = _currentTweaks[i];
                bool isEnabled = await _featureManager.IsEnabled(node);
                listSettings.SetItemChecked(i, isEnabled);
            }

            if (_currentTweaks.Count > 0)
            {
                listSettings.SelectedIndex = 0;
            }
            else
            {
                UpdateUiContextForNoneSelected();
            }
        }

        /// <summary>
        /// Toggles all items in the list between checked and unchecked.
        /// </summary>
        private void btnToggleAll_Click(object sender, EventArgs e)
        {
            // Determine if we should check or uncheck all items
            bool checkAll = false;
            for (int i = 0; i < listSettings.Items.Count; i++)
            {
                if (!listSettings.GetItemChecked(i))
                {
                    checkAll = true;
                    break; // As soon as one is unchecked, we'll check all
                }
            }

            // Apply the determined state to all items
            for (int i = 0; i < listSettings.Items.Count; i++)
            {
                listSettings.SetItemChecked(i, checkAll);
            }

            // Update the help text to reflect the action taken
            string action = checkAll ? "All features have been selected." : "All features have been deselected.";
            textHelp.Text = action;
        }


        /// <summary>
        /// Clears shared UI when no tweak is selected.
        /// </summary>
        private void UpdateUiContextForNoneSelected()
        {
            textHelp.Text = "";
        }

        /// <summary>
        /// Refreshes the view by reloading the current category's tweaks.
        /// </summary>
        public void RefreshView()
        {
            if (comboCategories.SelectedItem is string selectedCategory)
            {
                _ = LoadTweaksForCategory(selectedCategory);
            }
        }

        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/CrapFixer");
        }

 
    }
}