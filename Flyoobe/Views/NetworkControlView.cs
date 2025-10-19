using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class NetworkControlView : UserControl, IView

    {
        public string ViewTitle => "Network Control";

        public NetworkControlView()
        {
            InitializeComponent();
        }

        private async Task RefreshNetworks()
        {
            btnConnect.Enabled = false;
            lblStatus.Text = "Scanning for networks...";
            listBoxNetworks.Items.Clear();

            var networks = await Task.Run(() => GetAvailableWifiNetworks());

            if (networks.Count == 0)
            {
                lblStatus.Text = "No networks found.";
            }
            else
            {
                lblStatus.Text = $"Found {networks.Count} networks.";
                listBoxNetworks.Items.AddRange(networks.ToArray());
            }
            btnConnect.Enabled = true;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            btnRefresh.Enabled = false;

            if (radioEthernet.Checked)
            {
                lblStatus.Text = "Ethernet selected. Opening Network Connections...";
                OpenNetworkConnections();
            }
            else
            {
                if (listBoxNetworks.SelectedItem == null)
                {
                    lblStatus.Text = "Please select a WiFi network.";
                    btnConnect.Enabled = true;
                    btnRefresh.Enabled = true;
                    return;
                }

                string ssid = listBoxNetworks.SelectedItem.ToString();
                lblStatus.Text = $"Connecting to {ssid}...";

                await Task.Run(() => ConnectToWifi(ssid));
            }

            btnConnect.Enabled = true;
            btnRefresh.Enabled = true;
        }

        private List<string> GetAvailableWifiNetworks()
        {
            var ssids = new List<string>();

            try
            {
                var psi = new ProcessStartInfo("netsh", "wlan show networks mode=Bssid")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var proc = Process.Start(psi))
                {
                    string output = proc.StandardOutput.ReadToEnd();
                    string error = proc.StandardError.ReadToEnd();
                    proc.WaitForExit();

                    // --- detect location service requirement ---
                    if (proc.ExitCode != 0)

                    {
                        Invoke((Action)(() =>
                        {
                            MessageBox.Show(
                                 "Location services must be enabled to scan for Wi-Fi networks.\n\n" +
                                 "Click OK to open Location Settings.",
                                 "Wi-Fi Scan Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                            EnsureLocationEnabled();   // open settings
                        }));
                        return ssids; // empty
                    }

                    // --- normal parsing ---
                    foreach (var line in output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (line.Trim().StartsWith("SSID ", StringComparison.OrdinalIgnoreCase))
                        {
                            var parts = line.Split(':');
                            if (parts.Length > 1)
                            {
                                string ssid = parts[1].Trim();
                                if (!string.IsNullOrEmpty(ssid) && !ssids.Contains(ssid))
                                    ssids.Add(ssid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show($"Error retrieving networks: {ex.Message}");
                }));
            }

            return ssids;
        }

        // Opens the Location Settings page if location services are required
        private void EnsureLocationEnabled()
        {
            try
            {
                Process.Start(new ProcessStartInfo("ms-settings:privacy-location")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enable Location services manually. Error: " + ex.Message);
            }
        }

        // Attempts to connect to a given Wi-Fi SSID using netsh
        private void ConnectToWifi(string ssid)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("netsh", $"wlan connect name=\"{ssid}\"")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    // Check if the connection was successful
                    if (!output.Contains("completed successfully") || process.ExitCode != 0)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblStatus.Text = $"Connection to {ssid} failed. Opening Wi-Fi settings...";
                        }));
                        OpenWifiSettings();
                    }
                    else
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblStatus.Text = $"Successfully connected to {ssid}.";
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new MethodInvoker(() =>
                {
                    lblStatus.Text = $"Error connecting to {ssid}: {ex.Message}";
                }));
            }
        }

        private void OpenWifiSettings()
        {
            try
            {
                Process.Start("ms-settings:network-wifi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open WiFi settings: " + ex.Message);
            }
        }

        private void OpenNetworkConnections()
        {
            try
            {
                Process.Start("ncpa.cpl");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Network Connections: " + ex.Message);
            }
        }

        public async void RefreshView()
        {
            await RefreshNetworks();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshNetworks();
        }
    }
}