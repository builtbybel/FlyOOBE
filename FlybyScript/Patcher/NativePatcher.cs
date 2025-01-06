using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * NativePatcher class is responsible for automating the Windows 11 24H2 installation process.
 * It uses the Fido.ps1 script https://github.com/pbatard/Fido to download the ISO, mounts the ISO, and runs Server setupprep.exe
 */

namespace FlybyScript
{
    public class NativePatcher
    {
        private Logger _logger;
        private string _fidoScriptPath;

        public NativePatcher(Logger logger)
        {
            this._fidoScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "upgraider", "Fido.ps1");
            this._logger = logger;
        }

        public async Task AutomateWindowsInstallation()
        {
            // Step 1: Download Windows 24H2 ISO using Fido.ps1
            await DownloadISO();

            // Step 2: Allow user to select the ISO after download
            MessageBox.Show("Please select the ISO file to mount.", "ISO Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Step 3: Mount the ISO and get the mounted drive letter
            string mountedDriveLetter = await MountISO();

            if (string.IsNullOrEmpty(mountedDriveLetter))
            {
                _logger.Log("ISO のマウントに失敗しました。終了します。", Color.Crimson);
                return;
            }

            // Step 2: Run the setup process with the mounted drive letter
            await RunSetup(mountedDriveLetter);
        }

        // Step 1: Download Windows 24H2 ISO by running the Fido.ps1 script
        private async Task DownloadISO()
        {
            try
            {
                _logger.Log("Windows 24H2 ISO のダウンロードを開始しています...", Color.Blue);

                // Run Fido.ps1 to download the ISO (PowerShell script)
                string downloadCommand = $"& \"{_fidoScriptPath}\"";
                await ExecutePowerShellCommand(downloadCommand);

                _logger.Log("Windows 24H2 ISO のダウンロードが完了しました。", System.Drawing.Color.Green);

                MessageBox.Show("Please wait for the ISO file to download, and then select the ISO file.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                _logger.Log("Please wait for the ISO file to download, and then select the ISO file. " +
                    "If you cancel the process here and wait for the ISO download, you will need to restart the patching process, " +
                    "but you can skip the ISO download.", System.Drawing.Color.Black);
            }
            catch (Exception ex)
            {
                _logger.Log($"Error during ISO download: {ex.Message}", System.Drawing.Color.Crimson);
            }
        }

        private async Task<string> MountISO()
        {
            try
            {
                string isoFilePath = SelectISOFile();

                if (!string.IsNullOrEmpty(isoFilePath))
                {
                    MessageBox.Show($"Selected ISO file: {isoFilePath}. Now mounting the ISO.", "ISO Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _logger.Log($"Mounting ISO: {isoFilePath}...", System.Drawing.Color.Blue);

                    string mountCommand = $"Mount-DiskImage -ImagePath \"{isoFilePath}\"";
                    await ExecutePowerShellCommand(mountCommand);  // Run asynchronously for mounting

                    // After mounting, try to get the drive letter
                    string mountedDriveLetter = await GetMountedDriveLetter();

                    if (string.IsNullOrEmpty(mountedDriveLetter))
                    {
                        _logger.Log("Failed to get mounted drive letter.", System.Drawing.Color.Crimson);
                        return null;
                    }
                    else
                    {
                        _logger.Log($"ISO mounted successfully. Drive letter: {mountedDriveLetter}", System.Drawing.Color.Green);
                        return mountedDriveLetter;  // Return the mounted drive letter
                    }
                }
                else
                {
                    _logger.Log("ISO が選択されていません。", System.Drawing.Color.Black);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error mounting ISO: {ex.Message}", System.Drawing.Color.Crimson);
                return null;
            }
        }

        private async Task RunSetup(string mountedDriveLetter)
        {
            if (string.IsNullOrEmpty(mountedDriveLetter))
            {
                _logger.Log("No mounted drive found. Exiting.", System.Drawing.Color.Crimson);
                return;
            }

            // Log the drive letter and build the sources folder path
            string sourcesFolderPath = Path.Combine(mountedDriveLetter, "sources");
            _logger.Log($"Mounted drive letter: {mountedDriveLetter}", System.Drawing.Color.Gray);
            _logger.Log($"Checking Sources folder at: {sourcesFolderPath}", System.Drawing.Color.Gray);

            // Check if Sources folder exists
            if (!Directory.Exists(sourcesFolderPath))
            {
                _logger.Log($"Sources folder not found at {sourcesFolderPath}.", System.Drawing.Color.Crimson);
                return;
            }

            await LaunchSetupFromSourcesFolder(sourcesFolderPath);
        }

        private async Task LaunchSetupFromSourcesFolder(string sourcesFolderPath)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(sourcesFolderPath, "setupprep.exe"),
                Arguments = "/product server",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (var process = Process.Start(processInfo))
                {
                    // Capture output and wait for exit
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    await process.WaitForExitAsync();

                    // Log output and errors if any
                    if (!string.IsNullOrEmpty(output)) _logger.Log($"Output: {output}", System.Drawing.Color.Gray);
                    if (!string.IsNullOrEmpty(error)) _logger.Log($"Error: {error}", System.Drawing.Color.Crimson);
                }

                MessageBox.Show("Follow the Windows Server Setup window now. You can close this message box and the FlybyScript.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.Log($"Error running setupprep.exe: {ex.Message}", System.Drawing.Color.Crimson);
            }
        }

        public async Task RunSetupFromMountedISO()
        {
            // Choose an ISO file
            string isoFilePath = SelectISOFile();
            if (isoFilePath == null) return;

            try
            {
                _logger.Log($"Please wait...", System.Drawing.Color.Crimson);

                // Mount the selected ISO
                await ExecutePowerShellCommand($"Mount-DiskImage -ImagePath \"{isoFilePath}\"");

                // Get the mounted drive letter
                string mountedDriveLetter = await GetMountedDriveLetter();
                if (string.IsNullOrEmpty(mountedDriveLetter))
                {
                    _logger.Log("Failed to get mounted drive letter.", System.Drawing.Color.Crimson);
                    return;
                }

                _logger.Log($"Mounted drive letter: {mountedDriveLetter}", System.Drawing.Color.Gray);

                // Define Sources folder path and check if it exists
                string sourcesFolderPath = Path.Combine(mountedDriveLetter, "sources");
                if (Directory.Exists(sourcesFolderPath))
                {
                    await LaunchSetupFromSourcesFolder(sourcesFolderPath);
                }
                else
                {
                    _logger.Log($"Sources folder not found at {sourcesFolderPath}.", System.Drawing.Color.Crimson);
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error mounting ISO or launching setup: {ex.Message}", System.Drawing.Color.Crimson);
            }
        }

        private void ProcessStart(string command)
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = command;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = false;

                    // Start the process
                    process.Start();

                    // Wait for the process to finish
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error executing CMD command: {ex.Message}", System.Drawing.Color.Crimson);
            }
        }

        private async Task<string> ExecutePowerShellCommand(string command)
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    // Output and error handlers
                    var outputBuilder = new StringBuilder();
                    var errorBuilder = new StringBuilder();

                    process.OutputDataReceived += (sender, args) =>
                    {
                        if (args.Data != null)
                        {
                            outputBuilder.AppendLine(args.Data);  // Collect output data
                            _logger.Log(args.Data, System.Drawing.Color.LightPink);
                        }
                    };

                    process.ErrorDataReceived += (sender, args) =>
                    {
                        if (args.Data != null)
                        {
                            errorBuilder.AppendLine(args.Data);  // Collect error data
                            _logger.Log(args.Data, System.Drawing.Color.Crimson);
                        }
                    };

                    // Start the process
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    // Wait for the process to exit
                    await Task.Run(() => process.WaitForExit());

                    // Combine the full output and error logs
                    string output = outputBuilder.ToString();
                    string error = errorBuilder.ToString();

                    if (!string.IsNullOrEmpty(error))
                    {
                        _logger.Log(error, System.Drawing.Color.Crimson);
                    }

                    // Return the entire output of ps command
                    return output;
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"PowerShell command execution failed: {ex.Message}", System.Drawing.Color.Crimson);
                return string.Empty;  // Return an empty string if an error occurs
            }
        }

        // Get the mounted drive letter
        private async Task<string> GetMountedDriveLetter()
        {
            try
            {
                // List all the drives to find the mounted drive letter
                var drives = DriveInfo.GetDrives();

                foreach (var drive in drives)
                {
                    // Check if the drive is a CD/DVD and if it's mounted
                    if (drive.DriveType == DriveType.CDRom && drive.IsReady)
                    {
                        // Return the letter of the mounted drive
                        return drive.Name.Substring(0, 2);
                    }
                }

                return null;  // Return null if no mounted drive is found
            }
            catch (Exception ex)
            {
                _logger.Log($"Error getting mounted drive letter: {ex.Message}", System.Drawing.Color.Crimson);
                return null;
            }
        }

        private string SelectISOFile()
        {
            using (var openFileDialog = new OpenFileDialog
            {
                Title = "Windows 11 ISO ファイルを選択",
                Filter = "ISO ファイル (*.iso)|*.iso|すべてのファイル (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            })
            {
                return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
            }
        }
    }
}