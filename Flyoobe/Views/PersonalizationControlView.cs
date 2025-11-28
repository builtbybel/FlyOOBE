using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class PersonalizationControlView : UserControl, IView
    {
        // Import necessary API functions for theme changes to trigger visual updates
        [DllImport("user32.dll", SetLastError = false, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageTimeout(
            IntPtr hWnd, uint Msg, IntPtr wParam, string lParam,
            uint flags, uint timeout, out IntPtr result);

        private void NotifyThemeChanged()
        {
            const int HWND_BROADCAST = 0xffff;
            const int WM_SETTINGCHANGE = 0x001A;
            const int SMTO_ABORTIFHUNG = 0x0002;

            SendMessageTimeout(
                (IntPtr)HWND_BROADCAST,
                WM_SETTINGCHANGE,
                IntPtr.Zero,
                "ImmersiveColorSet",
                SMTO_ABORTIFHUNG,
                100,
                out _);
        }

        public PersonalizationControlView()
        {
            InitializeComponent();
            InitializeThemeDropdowns();
            LoadCurrentSettings();
            LoadWallpaperPreview();
        }

        /// <summary>
        /// Populates the dropdowns for app and system theme selection.
        /// </summary>
        private void InitializeThemeDropdowns()
        {
            comboAppTheme.Items.Clear();
            comboSystemTheme.Items.Clear();

            // Populate app theme options
            comboAppTheme.Items.Add("Light");
            comboAppTheme.Items.Add("Dark");

            // Populate system theme options
            comboSystemTheme.Items.Add("Light");
            comboSystemTheme.Items.Add("Dark");

            // Populate taskbar alignment options
            comboTaskbarAlignment.Items.Add("Left");
            comboTaskbarAlignment.Items.Add("Center");

            comboAppTheme.SelectedIndex = 0;    // Default to Light
            comboSystemTheme.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads the current personalization settings like theme and transparency.
        /// </summary>
        private void LoadCurrentSettings()
        {
            try
            {
                // --- Theme & transparency ---
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (key != null)
                    {
                        int appsUseLightTheme = Convert.ToInt32(key.GetValue("AppsUseLightTheme", 1));
                        int systemUseLightTheme = Convert.ToInt32(key.GetValue("SystemUsesLightTheme", 1));
                        int enableTransparency = Convert.ToInt32(key.GetValue("EnableTransparency", 1));

                        comboAppTheme.SelectedIndex = (appsUseLightTheme == 1) ? 0 : 1;
                        comboSystemTheme.SelectedIndex = (systemUseLightTheme == 1) ? 0 : 1;
                        checkToggleTransparency.Checked = (enableTransparency == 1);
                    }
                }

                // --- Taskbar alignment ---
                using (RegistryKey adv = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
                {
                    if (adv != null)
                    {
                        object raw = adv.GetValue("TaskbarAl", 1); // default 1 = Center
                        int taskbarAl = Convert.ToInt32(raw);

                        // 0 = Left, 1 = Center
                        comboTaskbarAlignment.SelectedIndex = (taskbarAl == 0) ? 0 : 1;
                    }
                    else
                    {
                        // Key not found -> fallback Center
                        comboTaskbarAlignment.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading personalization settings: " + ex.Message);
            }
        }

        /// <summary>
        /// Apply taskbar alignment (0 = Left, 1 = Center) and refresh Explorer if needed.
        /// </summary>
        private void SetTaskbarAlignment(int alignment)
        {
            try
            {
                using (RegistryKey adv = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", writable: true))
                {
                    if (adv != null)
                        adv.SetValue("TaskbarAl", alignment == 0 ? 0 : 1, RegistryValueKind.DWord);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to set taskbar alignment: " + ex.Message);
            }
        }

        /// <summary>
        /// Toggles the transparency effect based on the given flag.
        /// </summary>
        private void ToggleTransparency(bool enable)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
                if (key != null)
                {
                    key.SetValue("EnableTransparency", enable ? 1 : 0, RegistryValueKind.DWord);
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to change transparency: " + ex.Message);
            }
        }

        /// <summary>
        /// Sets the Windows theme (0 = Light, 1 = Dark).
        /// </summary>
        private void SetTheme(bool appsLight, bool systemLight)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", writable: true))
                {
                    if (key != null)
                    {
                        key.SetValue("AppsUseLightTheme", appsLight ? 1 : 0, RegistryValueKind.DWord);
                        key.SetValue("SystemUsesLightTheme", systemLight ? 1 : 0, RegistryValueKind.DWord);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to apply theme settings: " + ex.Message);
            }

            NotifyThemeChanged(); // Notify the system that the theme has changed
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        /// <summary>
        /// Sets the desktop wallpaper to the specified image path.
        /// </summary>
        private void SetWallpaper(string path)
        {
            const int SPI_SETDESKWALLPAPER = 20;
            const int SPIF_UPDATEINIFILE = 0x01;
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE);
        }

        /// <summary>
        /// Applies the selected theme and transparency settings.
        /// </summary>
        private void btnApplyTheme_Click(object sender, EventArgs e)
        {
            bool appsLight = comboAppTheme.SelectedIndex == 0;     // 0 = Light
            bool systemLight = comboSystemTheme.SelectedIndex == 0;

            SetTheme(appsLight, systemLight);

            bool enableTransparency = checkToggleTransparency.Checked;
            ToggleTransparency(enableTransparency);

            // apply taskbar alignment from designer combo
            if (comboTaskbarAlignment != null && comboTaskbarAlignment.SelectedIndex >= 0)
            {
                int alignment = (comboTaskbarAlignment.SelectedIndex == 0) ? 0 : 1; // Left or Center
                SetTaskbarAlignment(alignment);
            }

            lblStatus.Text= "Personalization settings updated";
        }

        /// <summary>
        /// Changes the wallpaper and refreshes the preview.
        /// </summary>
        private void btnChangeWallpaper_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SetWallpaper(ofd.FileName);
                lblStatus.Text = "Wallpaper changed.";
                LoadWallpaperPreview();
            }
        }

        /// <summary>
        /// Retrieves the current wallpaper path from the registry.
        /// </summary>
        private string GetCurrentWallpaperPath()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
            {
                return key?.GetValue("WallPaper")?.ToString();
            }
        }

        /// <summary>
        /// Loads the current wallpaper preview into the PictureBox.
        /// </summary>
        private void LoadWallpaperPreview()
        {
            string wallpaperPath = GetCurrentWallpaperPath();
            if (!string.IsNullOrEmpty(wallpaperPath) && System.IO.File.Exists(wallpaperPath))
            {
                pictureBoxWallpaper.ImageLocation = wallpaperPath;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:colors");
        }

        public void RefreshView()
        {
            LoadCurrentSettings();
            LoadWallpaperPreview();
        }

        private void btnChangeDesktopIcons_Click(object sender, EventArgs e)
        {
            try
            {
                // Classic desktop icon settings dialog
                Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL desk.cpl,,0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open Desktop Icon Settings: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}