using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class AiControlView : UserControl, IView
    {
        public AiControlView()
        {
            InitializeComponent();
            btnCheck.Click += async (s, e) => await DoScan();
            btnDisable.Click += async (s, e) => await DoRemove();
        }

        // IView Refreshes the UI by re-scanning.
        public async void RefreshView()
        {
            await DoScan();
        }

        /// <summary>
        /// Scans relevant registry/policy/Appx states and populates the list.
        /// </summary>
        private async Task DoScan()
        {
            lblStatus.Text = "Checking status...";
            listResults.Items.Clear();

            await Task.Run(() =>
            {
                string copilotBtn = CheckCopilotButton();
                string clickToDo = CheckClickToDo();
                string recall = CheckRecall();
                string copilotPolicy = CheckCopilotPolicy();
                string edgeSidebar = CheckEdgeSidebar();
                string edgeHubs = CheckEdgeHubs();
                string edgeAllowCopilot = CheckEdgeAllowCopilot();
                string edgeConfigureCopilot = CheckEdgeConfigureCopilot();
                string copilotApp = HasCopilotApp() ? "Installed" : "Not found";

                this.Invoke((Action)(() =>
                {
                    AddItem("Copilot taskbar button", copilotBtn);
                    AddItem("Copilot policy (TurnOff)", copilotPolicy);
                    AddItem("Click To Do", clickToDo);
                    AddItem("Recall component", recall);
                    AddItem("Edge: Sidebar enabled", edgeSidebar);
                    AddItem("Edge: Show side panel hubs", edgeHubs);
                    AddItem("Edge: Allow Copilot", edgeAllowCopilot);
                    AddItem("Edge: Configure Copilot", edgeConfigureCopilot);
                    AddItem("Copilot Appx (because Microsoft loves AI)", copilotApp);

                    lblStatus.Text = "Check finished. AI is everywhere, whether you like it or not.";
                    listResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }));
            });
        }

        /// <summary>
        /// Applies changes for all checked items.
        /// </summary>
        private async Task DoRemove()
        {
            if (listResults.CheckedItems.Count == 0)
            {
                lblStatus.Text = "Nothing selected.";
                return;
            }

            lblStatus.Text = "Applying change...";

            // Snapshot only the display texts
            var selectedNames = listResults.CheckedItems
                .Cast<ListViewItem>()
                .Select(it => it.SubItems[0].Text)
                .ToList();

            // Perform work in background and collect per-item result text
            var results = await Task.Run(() =>
            {
                var dict = selectedNames.ToDictionary(n => n, n => "Removed/Disabled");

                foreach (var name in selectedNames)
                {
                    try
                    {
                        if (name == "Copilot taskbar button")
                            WriteDwordHKCU(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowCopilotButton", 0);
                        else if (name == "Copilot policy (TurnOff)")
                            WriteDwordHKLM(@"SOFTWARE\Policies\Microsoft\Windows\WindowsCopilot", "TurnOffWindowsCopilot", 1);
                        else if (name == "Click To Do")
                            WriteDwordHKCU(@"Software\Microsoft\Windows\Shell\ClickToDo", "DisableClickToDo", 1);
                        else if (name == "Recall component")
                            WriteDwordHKLM(@"SOFTWARE\Policies\Microsoft\Windows\WindowsAI", "AllowRecallEnablement", 0);
                        else if (name == "Edge: Sidebar enabled")
                            WriteDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "EdgeSidebarEnabled", 0);
                        else if (name == "Edge: Show side panel hubs")
                        {
                            // Apply policy at machine level (requires admin rights)
                            WriteDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "HubsSidebarEnabled", 0);

                            // Also apply at user policy level, in case HKLM is not used
                            WriteDwordHKCU(@"SOFTWARE\Policies\Microsoft\Edge", "SHubsSidebarEnabled", 0);

                            // Finally, set the normal user preference (ignored if a policy exists)
                            WriteDwordHKCU(@"Software\Microsoft\Edge", "HubsSidebarEnabled", 0);
                        }
                        else if (name == "Edge: Allow Copilot")
                            WriteDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "AllowCopilot", 0);
                        else if (name == "Edge: Configure Copilot")
                            WriteDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "ConfigureCopilot", 0);
                        else if (name.StartsWith("Copilot Appx", StringComparison.OrdinalIgnoreCase))
                        {
                            var (ok, msg) = RemoveCopilotApp();
                            dict[name] = ok ? "Removed (Appx)" : "Error: " + msg;
                        }
                    }
                    catch (Exception ex)
                    {
                        dict[name] = "Error: " + ex.Message;
                    }
                }

                return dict;
            });

            // Update UI once, on UI thread
            foreach (ListViewItem it in listResults.Items)
            {
                var name = it.SubItems[0].Text;
                if (results.TryGetValue(name, out var status))
                    it.SubItems[1].Text = status;
            }

            lblStatus.Text = "All set. Your AI settings have been updated.";
        }

        // ------------------- Checks -------------------

        /// <summary>Returns Copilot button state from HKCU.</summary>
        private string CheckCopilotButton()
        {
            int val = ReadDwordHKCU(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowCopilotButton", -1);
            return val == 1 ? "Enabled" : val == 0 ? "Disabled" : "Not set";
        }

        /// <summary>Returns Click To Do state from HKCU.</summary>
        private string CheckClickToDo()
        {
            int val = ReadDwordHKCU(@"Software\Microsoft\Windows\Shell\ClickToDo", "DisableClickToDo", -1);
            return val == 1 ? "Disabled" : val == 0 ? "Enabled" : "Not set";
        }

        /// <summary>Returns Recall policy state from HKLM.</summary>
        private string CheckRecall()
        {
            int val = ReadDwordHKLM(@"SOFTWARE\Policies\Microsoft\Windows\WindowsAI", "AllowRecallEnablement", -1);
            return val == 1 ? "Allowed" : val == 0 ? "Blocked" : "Not set";
        }

        /// <summary>Returns Copilot policy (TurnOffWindowsCopilot) from HKLM.</summary>
        private string CheckCopilotPolicy()
        {
            int val = ReadDwordHKLM(@"SOFTWARE\Policies\Microsoft\Windows\WindowsCopilot", "TurnOffWindowsCopilot", -1);
            return val == 1 ? "Disabled (policy)" : val == 0 ? "Enabled (policy)" : "Not set";
        }

        /// <summary>Returns Edge Sidebar policy from HKLM.</summary>
        private string CheckEdgeSidebar()
        {
            int val = ReadDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "EdgeSidebarEnabled", -1);
            return val == 0 ? "Disabled" : val == 1 ? "Enabled" : "Not set";
        }

        /// <summary>
        /// Checks Edge Hubs (side panel) status.
        /// Priority: Policy (HKLM/HKCU) > User setting.
        /// </summary>
        private string CheckEdgeHubs()
        {
            // 1) Check machine-wide policy (HKLM)
            int policyMachine = ReadDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "HubsSidebarEnabled", -1);
            if (policyMachine == 0) return "Disabled (policy)";
            if (policyMachine == 1) return "Enabled (policy)";

            // 2) Check user policy (HKCU\Policies)
            int policyUser = ReadDwordHKCU(@"SOFTWARE\Policies\Microsoft\Edge", "HubsSidebarEnabled", -1);
            if (policyUser == 0) return "Disabled (policy)";
            if (policyUser == 1) return "Enabled (policy)";

            // 3) Fallback: regular user setting (no policy enforced)
            int userSetting = ReadDwordHKCU(@"Software\Microsoft\Edge", "HubsSidebarEnabled", -1);
            if (userSetting == 0) return "Disabled (user)";
            if (userSetting == 1) return "Enabled (user)";

            // 4) Nothing set anywhere
            return "Not set";
        }

        /// <summary>Returns Edge Allow Copilot policy from HKLM.</summary>
        private string CheckEdgeAllowCopilot()
        {
            int val = ReadDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "AllowCopilot", -1);
            return val == 0 ? "Disabled" : val == 1 ? "Enabled" : "Not set";
        }

        /// <summary>Returns Edge Configure Copilot policy from HKLM.</summary>
        private string CheckEdgeConfigureCopilot()
        {
            int val = ReadDwordHKLM(@"SOFTWARE\Policies\Microsoft\Edge", "ConfigureCopilot", -1);
            return val == 0 ? "Disabled" : val == 1 ? "Enabled" : "Not set";
        }

        // ------------------- Registry helpers ---------

        /// <summary>Reads a DWORD from HKCU, returns default if missing.</summary>
        private int ReadDwordHKCU(string subKey, string name, int defVal)
        {
            using (var k = Registry.CurrentUser.OpenSubKey(subKey))
            {
                if (k == null) return defVal;
                var v = k.GetValue(name);
                return v == null ? defVal : Convert.ToInt32(v);
            }
        }

        /// <summary>Reads a DWORD from HKLM, returns default if missing.</summary>
        private int ReadDwordHKLM(string subKey, string name, int defVal)
        {
            using (var k = Registry.LocalMachine.OpenSubKey(subKey))
            {
                if (k == null) return defVal;
                var v = k.GetValue(name);
                return v == null ? defVal : Convert.ToInt32(v);
            }
        }

        /// <summary>Writes a DWORD to HKCU (creates the key if needed).</summary>
        private void WriteDwordHKCU(string subKey, string name, int val)
        {
            using (var k = Registry.CurrentUser.CreateSubKey(subKey))
            {
                k.SetValue(name, val, RegistryValueKind.DWord);
            }
        }

        /// <summary>Writes a DWORD to HKLM (creates the key if needed).</summary>
        private void WriteDwordHKLM(string subKey, string name, int val)
        {
            using (var k = Registry.LocalMachine.CreateSubKey(subKey))
            {
                k.SetValue(name, val, RegistryValueKind.DWord);
            }
        }

        // ------------------- Copilot Appx --------------
        /// <summary>
        /// Returns true if any Appx with "copilot" is present.
        /// </summary>
        private bool HasCopilotApp()
        {
            try
            {
                var psi = new ProcessStartInfo("powershell.exe",
                    "-NoProfile -Command \"Get-AppxPackage *copilot*\"")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                using (var p = Process.Start(psi))
                {
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    return !string.IsNullOrWhiteSpace(output);
                }
            }
            catch { return false; }
        }

        /// <summary>
        /// Tries to remove Copilot Appx elevated; waits and returns (success, message).
        /// Note: UseShellExecute=true is required for Verb=runas; no stream redirect.
        /// ExitCode 0 = success, otherwise failure.
        /// </summary>
        private (bool ok, string msg) RemoveCopilotApp()
        {
            try
            {
                var psi = new ProcessStartInfo("powershell.exe",
                    "-NoProfile -Command \"Get-AppxPackage *copilot* | Remove-AppxPackage\"")
                {
                    UseShellExecute = true,
                    Verb = "runas",
                    CreateNoWindow = true
                };

                using (var p = Process.Start(psi))
                {
                    if (p == null) return (false, "Process did not start.");
                    p.WaitForExit();

                    // Treat ExitCode 0 as success, otherwise failure
                    return p.ExitCode == 0
                        ? (true, "Copilot Appx removal executed.")
                        : (false, "Removal failed (exit code " + p.ExitCode + ").");
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                return (false, "Elevation canceled: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        // ------------------- UI helper -----------------

        /// <summary>Adds a row to the ListView with name and status.</summary>
        private void AddItem(string name, string status)
        {
            var it = new ListViewItem(name);
            it.SubItems.Add(status);
            listResults.Items.Add(it);
        }
    }
}