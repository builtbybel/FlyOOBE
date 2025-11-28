using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe.ToolHub
{
    public partial class ToolHubItemControl : UserControl
    {
        private readonly ToolHubDefinition _tool;
        private readonly string _placeholderText = "Enter input (e.g., IDs or raw arguments)";

        public ToolHubItemControl(ToolHubDefinition tool)
        {
            InitializeComponent();
            _tool = tool ?? throw new ArgumentNullException(nameof(tool));

            InitializeBasics();
            InitializeOptions();
            InitializeTextInput();
            InitializePoweredByLink();
        }

        /// <summary>
        /// Basic label and layout setup
        /// </summary>
        private void InitializeBasics()
        {
            labelTitle.Text = _tool.Title;
            labelDescription.Text = _tool.Description;
            labelIcon.Text = _tool.Icon;
            progressBar.Visible = false;
            labelStatus.Text = string.Empty;
        }

        /// <summary>
        /// Populate dropdown if # Options are defined
        /// </summary>
        private void InitializeOptions()
        {
            if (_tool.Options != null && _tool.Options.Count > 0)
            {
                comboOptions.Visible = true;
                comboOptions.Items.Clear();
                comboOptions.Items.AddRange(_tool.Options.ToArray());
                comboOptions.SelectedIndex = 0;
            }
            else
            {
                comboOptions.Visible = false;
            }
        }

        /// <summary>
        /// Configure input textbox for # Input:true scripts
        /// </summary>
        private void InitializeTextInput()
        {
            if (textInput == null) return;

            textInput.Visible = _tool.SupportsInput;

            if (!_tool.SupportsInput)
                return;

            // Determine placeholder
            string placeholder = !string.IsNullOrWhiteSpace(_tool.InputPlaceholder)
                ? _tool.InputPlaceholder
                : "Enter input (e.g., IDs or raw arguments)";

            textInput.Text = placeholder;
            textInput.ForeColor = Color.Gray;

            // UX behavior: placeholder clear/restore
            textInput.GotFocus += (s, e) =>
            {
                if (textInput.Text.Equals(placeholder, StringComparison.Ordinal))
                {
                    textInput.Text = string.Empty;
                    textInput.ForeColor = SystemColors.WindowText;
                }
            };

            textInput.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textInput.Text))
                {
                    textInput.Text = placeholder;
                    textInput.ForeColor = Color.Gray;
                }
            };
        }

        /// <summary>
        /// Show "Powered by" link if metadata is provided
        /// </summary>
        private void InitializePoweredByLink()
        {
            if (string.IsNullOrWhiteSpace(_tool.PoweredByText) ||
                string.IsNullOrWhiteSpace(_tool.PoweredByUrl))
            {
                linkPoweredBy.Visible = false;
                return;
            }

            linkPoweredBy.Text = _tool.PoweredByText.Trim();
            linkPoweredBy.Tag = _tool.PoweredByUrl.Trim();
            linkPoweredBy.Visible = true;
            linkPoweredBy.LinkClicked += linkPoweredBy_LinkClicked;
            linkPoweredBy.AccessibleName = "Powered by link";
            linkPoweredBy.AccessibleDescription = "Opens the developer's website";
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {

            if (!File.Exists(_tool.ScriptPath))
            {
                MessageBox.Show("Script not found: " + _tool.ScriptPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Enabled = false;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            labelStatus.Text = "Running...";

            try
            {
                // Defaults from # Host
                bool useConsole = _tool.UseConsole;
                bool useLog = _tool.UseLog;

                // Selected option text (may carry host-suffix overrides)
                string optionArg = null;
                if (comboOptions != null && comboOptions.Visible && comboOptions.SelectedItem != null)
                {
                    optionArg = comboOptions.SelectedItem.ToString();

                    if (optionArg.EndsWith(" (console)", StringComparison.Ordinal))
                    {
                        useConsole = true; useLog = false;
                        optionArg = optionArg.Substring(0, optionArg.Length - " (console)".Length).Trim();
                    }
                    else if (optionArg.EndsWith(" (silent)", StringComparison.Ordinal))
                    {
                        useConsole = false; useLog = false;
                        optionArg = optionArg.Substring(0, optionArg.Length - " (silent)".Length).Trim();
                    }
                    else if (optionArg.EndsWith(" (log)", StringComparison.Ordinal))
                    {
                        useLog = true; useConsole = false;
                        optionArg = optionArg.Substring(0, optionArg.Length - " (log)".Length).Trim();
                    }
                }

                // Optional free text argument (only if visible and real input)
                string inputArg = null;
                if (_tool.SupportsInput && textInput != null && textInput.Visible)
                {
                    var t = (textInput.Text ?? string.Empty).Trim();
                    var placeholder = string.IsNullOrWhiteSpace(_tool.InputPlaceholder) ? _placeholderText : _tool.InputPlaceholder;
                    if (!string.IsNullOrEmpty(t) && !string.Equals(t, placeholder, StringComparison.Ordinal))
                        inputArg = t;
                }

                // Build positional argument string:
                //   <space>"<optionArg>" [space]"<inputArg>"
                // This keeps backward-compatibility with scripts using $args[0]/$args[1]
                // AND also binds to param($Option,$ArgsText) by position when present.
                var extraArgs = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(optionArg))
                    extraArgs.Append(" ").Append(QuoteForPs(optionArg));
                if (!string.IsNullOrWhiteSpace(inputArg))
                    extraArgs.Append(" ").Append(QuoteForPs(inputArg));

                // Live log window if requested
                if (useLog)
                {
                    Logger.ShowLogView();
                    // Start a new visual log section for this specific tool or extension
                    Logger.BeginSection($"Running {_tool.Title ?? _tool.ScriptPath}");
                }

                // Run script (console vs. silent) and stream logs
                var output = await RunScriptAsync(_tool.ScriptPath, extraArgs.ToString(), useConsole);

                labelStatus.Text = useConsole ? "Opened in console."
                                  : useLog ? "Completed with log."
                                           : "Done.";

                if (!string.IsNullOrWhiteSpace(output))
                    Logger.Log(output, LogLevel.Info);
            }
            catch (Exception ex)
            {
                labelStatus.Text = "Error: " + ex.Message;
                Logger.Log("ERROR: " + ex.Message, LogLevel.Error);
            }
            finally
            {
                progressBar.Visible = false;
                this.Enabled = true;

            }
        }

        private Task<string> RunScriptAsync(string scriptPath, string positionalArgs, bool useConsole)
        {
            return Task.Run(() =>
            {
                // Compose final PowerShell commandline; 'positionalArgs' already starts with a space when non-empty
                var argsForPs = $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\"{positionalArgs}";

                if (useConsole)
                {
                    var psi = new ProcessStartInfo("powershell.exe", "-NoExit " + argsForPs)
                    {
                        UseShellExecute = true,
                        CreateNoWindow = false
                    };
                    Process.Start(psi);
                    return "Launched in external console.";
                }
                else
                {
                    var psi = new ProcessStartInfo("powershell.exe", argsForPs)
                    {
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var sb = new StringBuilder();
                    using (var p = new Process { StartInfo = psi })
                    {
                        p.OutputDataReceived += (s, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                            {
                                Logger.Log(e.Data, LogLevel.Info);
                            }
                        };

                        p.ErrorDataReceived += (s, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                            {
                                sb.AppendLine("ERROR: " + e.Data);
                                Logger.Log("ERROR: " + e.Data, LogLevel.Error);
                            }
                        };

                        p.Start();
                        p.BeginOutputReadLine();
                        p.BeginErrorReadLine();
                        p.WaitForExit();
                    }

                    return sb.ToString();
                }
            });
        }

        /// <summary>
        /// Double-quote for PowerShell positional args: "value with \"escaped\" quotes"
        /// </summary>
        private static string QuoteForPs(string value)
        {
            if (value == null) return "\"\"";
            var escaped = value.Replace("\"", "\\\"");
            return "\"" + escaped + "\"";
        }

        /// <summary>
        /// Open the "Powered by" link in default browser
        /// </summary>
        private void linkPoweredBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(linkPoweredBy.Tag.ToString())
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open link:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(_tool.ScriptPath))
                {
                    MessageBox.Show("File already missing:\n" + _tool.ScriptPath,
                        "Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Parent?.Controls.Remove(this); // remove from UI anyway
                    return;
                }

                var confirm = MessageBox.Show(
                    "Do you want to remove this extension?\n\n" + _tool.Title,
                    "Confirm uninstall",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);

                if (confirm != DialogResult.Yes)
                    return;

                File.Delete(_tool.ScriptPath);

                // Remove this control from the panel immediately
                this.Parent?.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete script:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}