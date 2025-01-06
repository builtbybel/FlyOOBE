using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlybyScript
{
    public class USBManagement
    {
        private readonly Logger _logger;
        private ProgressBar _progressBar;

        public Action<string> UpdateLabelStatus;
        private int currentStep = 0;

        private static readonly HttpClient httpClient = new HttpClient();

        public USBManagement(Logger logger, Action<string> updateLabelStatus, ProgressBar progressBar)
        {
            _logger = logger;
            _progressBar = progressBar;
            UpdateLabelStatus = updateLabelStatus; // Set the delegate to update UI
        }

        private string[] steps = new[]
            {
                "Format and Boot USB Drive",
                "Mount ISO",
                "Copy ISO to USB",
                "Split Install.wim",
                "Finalize Installation Media (Install.wim)"
            };

        /// <summary>
        /// Updates the LabelStatus with the current step
        /// </summary>
        public void UpdateStatusLabel()
        {
            currentStep++;
            if (currentStep <= steps.Length)
            {
                string statusText = $"{currentStep}/{steps.Length} - {steps[currentStep - 1]}";

                // Call the delegate to update the label in the user control
                UpdateLabelStatus?.Invoke(statusText);

                // Log to the logger as well
                _logger.Log($"Step {currentStep}: {steps[currentStep - 1]} started.", Color.Blue);
            }
        }

        /// <summary>
        /// Updates the progress bar with the specified value
        /// </summary>
        private void UpdateProgress(int value)
        {
            if (_progressBar.InvokeRequired)
            {
                _progressBar.Invoke(new Action(() => _progressBar.Value = value));
            }
            else
            {
                _progressBar.Value = value;
            }
        }

        /// <summary>
        ///  Formats the USB drive using DiskPart
        /// </summary>
        /// <param name="diskNumber">Diskpart Device ID</param>
        /// <returns></returns>
        public async Task FormatDriveAsync(string diskNumber, string partitionScheme)
        {
            await Task.Run(() =>
            {
                try
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = "diskpart.exe",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(processInfo))
                    {
                        using (StreamWriter writer = process.StandardInput)
                        {
                            if (writer.BaseStream.CanWrite)
                            {
                                // Step 1: Format and Boot USB Drive
                                UpdateStatusLabel(); // Updates to 1/5 - Format and Boot USB Drive

                                // Send commands to DiskPart
                                writer.WriteLine($"select disk {diskNumber}"); // Select the disk 

                                UpdateProgress(10); // Update progress
                                writer.WriteLine("clean"); // Clean the disk

                                // Check partition scheme selection
                                if (partitionScheme == "GPT")
                                {
                                    writer.WriteLine("convert gpt"); // Convert to GPT
                                }
                                else if (partitionScheme == "MBR")
                                {
                                    writer.WriteLine("convert mbr"); // Convert to MBR
                                }

                                UpdateProgress(20);
                                writer.WriteLine("create partition primary"); // Create a new partition
                                writer.WriteLine("select partition 1"); // Select the new partition
                                writer.WriteLine("active"); // Set the new partition active

                                UpdateProgress(60);
                                writer.WriteLine("format fs=fat32 quick label=\"FlybyWin11\""); // Quick format to FAT32

                                writer.WriteLine("exit"); // Exit DiskPart
                                UpdateProgress(100); // Final progress
                            }
                        }

                        string output = process.StandardOutput.ReadToEnd(); // Get the output from DiskPart
                        process.WaitForExit();
                        _logger.Log($"Formatting completed: {output}", Color.Black);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log($"Error formatting drive: {ex.Message}", Color.Red);
                }
            });
        }


        /// <summary>
        /// Copies the contents of the specified ISO file to the USB drive using Robocopy.
        /// </summary>
        /// <param name="usbDrive">The drive letter of the USB drive.</param>
        /// <param name="isoPath">The path to the ISO file.</param>
        public async Task CopyISOAsync(string usbDrive, string isoPath)
        {
            try
            {
                // Step 1: Mount the ISO using PowerShell
                UpdateStatusLabel(); // Updates to "2/5 - Mount ISO"
                string mountCommand = $"Mount-DiskImage -ImagePath \"{isoPath}\"";
                ProcessStartInfo mountInfo = new ProcessStartInfo("powershell", mountCommand)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process mountProcess = Process.Start(mountInfo))
                {
                    string output = await mountProcess.StandardOutput.ReadToEndAsync();
                    await mountProcess.WaitForExitAsync(); // Wait for the process to complete
                    _logger.Log($"ISO mounted: {output}", Color.Black);
                }

                // Step 2: Get the drive letter of the mounted ISO
                string isoDriveLetter = await GetMountedDriveLetterAsync(); // Get the drive letter of the mounted ISO
                if (string.IsNullOrEmpty(isoDriveLetter))
                {
                    _logger.Log("Failed to get the mounted ISO drive letter.", Color.Red);
                    return; // Exit if we cant find the drive letter
                }

                _logger.Log($"Mounted ISO drive letter: {isoDriveLetter}", Color.Black);
                _logger.Log($"USB drive letter: {usbDrive}", Color.Black);

                // Step 3: Prepare the Robocopy command to copy everything except install.wim
                string robocopyCommand = $"robocopy {isoDriveLetter.TrimEnd('\\')} {usbDrive.TrimEnd('\\')} /MIR /XF \"install.wim\"";

                // Step 4: Execute the Robocopy command
                ProcessStartInfo robocopyInfo = new ProcessStartInfo("cmd.exe", $"/C {robocopyCommand}")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                // Step 3: Copy ISO to USB
                UpdateStatusLabel(); // Updates to "3/5 - Copy ISO to USB"
                using (Process robocopyProcess = Process.Start(robocopyInfo))
                {
                    robocopyProcess.OutputDataReceived += (s, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            _logger.Log(e.Data, Color.Black);

                            // Calculate and update progress based on Robocopy output
                            int progress = CalculateProgressFromRobocopy(e.Data);
                            UpdateProgress(progress);
                        }
                    };

                    robocopyProcess.BeginOutputReadLine();

                    // Wait for the process to finish
                    await robocopyProcess.WaitForExitAsync();
                }

                // Step 5: Get the path to the original WIM file (from the ISO)
                string wimFilePath = Path.Combine(isoDriveLetter, "sources", "install.wim");
                _logger.Log("Preparing install.wim... This may take a moment, please wait.", Color.Blue);

                // Step 4: Split Install.wim
                UpdateStatusLabel(); // Updates to "4/5 - Split Install.wim"
                if (File.Exists(wimFilePath))
                {
                    // Step 7: Define the path for the split files
                    string swmFilePath = Path.Combine(usbDrive, "sources", "install.swm"); // First split file

                    // Step 8: Dism command to split WIM
                    string splitDismCommand = $"/C Dism /Split-Image /ImageFile:\"{wimFilePath}\" /SWMFile:\"{swmFilePath}\" /FileSize:3000";

                    // Execute the command
                    ProcessStartInfo splitInfo = new ProcessStartInfo("cmd.exe", splitDismCommand)
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    // Step 5: Finalize Installation Media
                    UpdateStatusLabel(); // Updates to 5/5 - Finalize Installation Media

                    using (Process splitProcess = Process.Start(splitInfo))
                    {
                        splitProcess.OutputDataReceived += (s, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                            {
                                _logger.Log(e.Data, Color.Black); // Log the output from Dism
                            }
                        };

                        splitProcess.BeginOutputReadLine();

                        // Wait for the process to finish
                        await splitProcess.WaitForExitAsync();
                        _logger.Log($"WIM file split completed with exit code: {splitProcess.ExitCode}", Color.Blue);
                    }
                }
                else
                {
                    _logger.Log($"WIM file not found at {wimFilePath}.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error copying ISO: {ex.Message}", Color.Red);
            }

            MessageBox.Show("Your installation media is ready! You can now proceed with the installation.", "Installation Media", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Retrieves the drive letter of the currently mounted drive.
        /// </summary>
        /// <returns>The drive letter of the mounted CD/DVD drive, or null if not found.</returns>
        private async Task<string> GetMountedDriveLetterAsync()
        {
            try
            {
                // List all the drives to find the mounted CD/DVD drive
                var drives = DriveInfo.GetDrives();

                foreach (var drive in drives)
                {
                    // Check if the drive is a CD/DVD and if it's mounted
                    if (drive.DriveType == DriveType.CDRom && drive.IsReady)
                    {
                        // Return the letter of the mounted drive
                        return drive.Name; // Returns "D:\", "E:\", etc.
                    }
                }

                return null; // Return null if no mounted CD/DVD drive is found
            }
            catch (Exception ex)
            {
                _logger.Log($"Error getting mounted drive letter: {ex.Message}", Color.Crimson);
                return null;
            }
        }

        /// <summary>
        /// Downloads a specified tool (Media Creation Tool or Installation Assistant) from a provided URL.
        /// </summary>
        /// <param name="downloadUrl">The URL of the tool to download.</param>
        /// <param name="fileName">The name of the file to save.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DownloadMediaTool(string downloadUrl, string fileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "実行可能なファイル (*.exe)|*.exe";
                saveFileDialog.Title = $"Save {fileName}";
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = saveFileDialog.FileName;

                    try
                    {
                        _logger.Log($"Preparing to download {fileName}...", Color.Black);
                        _logger.Log("Download may take some time, please wait...", Color.RoyalBlue);

                        var response = await httpClient.GetAsync(downloadUrl);
                        response.EnsureSuccessStatusCode();

                        using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            await response.Content.CopyToAsync(fileStream);
                        }

                        _logger.Log($"{fileName} download completed successfully!", Color.Green);

                        // Start the downloaded tool
                        _logger.Log($"Starting {fileName}...", Color.Black);
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = destinationPath,
                            UseShellExecute = true // To run .exe files
                        });
                    }
                    catch (Exception ex)
                    {
                        _logger.Log($"An error occurred while downloading {fileName}: {ex.Message}", Color.Red);
                    }
                }
                else
                {
                    _logger.Log($"{fileName} download canceled by user.", Color.Red);
                }
            }
        }


        /// <summary>
        /// Calculates progress based on Robocopy output
        /// </summary>
        private int CalculateProgressFromRobocopy(string robocopyOutput)
        {
            // Find the percentage completion in Robocopy output
            var match = Regex.Match(robocopyOutput, @"(\d+)\%");

            if (match.Success)
            {
                // Extract the percentage number from the match and convert it to an integer
                if (int.TryParse(match.Groups[1].Value, out int progress))
                {
                    return progress;
                }
            }

            return 0; // Return 0 if no percentage was found
        }

        /// <summary>
        /// Copy the ISO to the USB drive and optionally create an unattend.xml file
        /// </summary>
        /// <param name="usbDrive"></param>
        /// <param name="isoPath"></param>
        /// <param name="createUnattend"></param>
        /// <returns></returns>
        public async Task CopyISOWithUnattendAsync(string usbDrive, string isoPath, bool createUnattend)
        {
            await CopyISOAsync(usbDrive, isoPath);

            if (createUnattend)
            {
                CreateUnattendXml(usbDrive); // Only create unattend.xml if checkbox is checked
            }
        }

        /// <summary>
        /// // Create unattend.xml file in the sources\$OEM$\$$\Panther directory
        /// </summary>
        /// <param name="usbDrive"></param>
        public void CreateUnattendXml(string usbDrive)
        {
            string unattendDir = Path.Combine(usbDrive, "sources", "$OEM$", "$$", "Panther");
            Directory.CreateDirectory(unattendDir); // Create the directory if it doesn't exist

            string unattendPath = Path.Combine(unattendDir, "unattend.xml");

            // Check if the file already exists
            if (!File.Exists(unattendPath))
            {
                // Create the unattend.xml content
                string xmlContent = @"<unattend xmlns='urn:schemas-microsoft-com:unattend'>
<settings pass='disabled'>
<component xmlns:wcm='http://schemas.microsoft.com/WMIConfig/2002/State' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' name='Microsoft-Windows-Setup' processorArchitecture='amd64' language='neutral' publicKeyToken='31bf3856ad364e35' versionScope='nonSxS'>
<UserData>
<ProductKey>
<Key/>
</ProductKey>
</UserData>
<RunSynchronous>
<RunSynchronousCommand wcm:action='add'>
<Order>1</Order>
<Path>reg add HKLM\SYSTEM\Setup\LabConfig /v BypassTPMCheck /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
<RunSynchronousCommand wcm:action='add'>
<Order>2</Order>
<Path>reg add HKLM\SYSTEM\Setup\LabConfig /v BypassSecureBootCheck /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
<RunSynchronousCommand wcm:action='add'>
<Order>3</Order>
<Path>reg add HKLM\SYSTEM\Setup\LabConfig /v BypassRAMCheck /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
</RunSynchronous>
</component>
</settings>
<settings pass='specialize'>
<component xmlns:wcm='http://schemas.microsoft.com/WMIConfig/2002/State' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' name='Microsoft-Windows-Deployment' processorArchitecture='amd64' language='neutral' publicKeyToken='31bf3856ad364e35' versionScope='nonSxS'>
<RunSynchronous>
<RunSynchronousCommand wcm:action='add'>
<Order>1</Order>
<Path>reg add HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\OOBE /v BypassNRO /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
</RunSynchronous>
</component>
</settings>
</unattend>";

                File.WriteAllText(unattendPath, xmlContent);
                _logger.Log("Created unattend.xml in the sources\\$OEM$\\$$\\Panther directory.", Color.Green);
            }
            else
            {
                _logger.Log("unattend.xml already exists in the sources\\$OEM$\\$$\\Panther directory.", Color.Blue);
            }
        }
    }
}