using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace ToAC3
{
    public partial class MainForm : Form
    {
        private Process _transcodingProcess;
        private Process _getStreamInfoProcess;
        private readonly AudioStreams _advancedOptions;
        private readonly ILogger _logger;

        public MainForm(AudioStreams advancedOptions, ILogger<MainForm> logger)
        {
            _advancedOptions = advancedOptions;
            _logger = logger;

            InitializeComponent();
        }

        #region Commands
        private string TranscodingCommand(string inputFile, string outputFile)
        {
            return $"/C .{Path.DirectorySeparatorChar}ffmpeg{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}ffmpeg.exe -probesize 512M -i \"{inputFile}\" -c:v copy -c:a ac3 -b:a 640k -y \"{outputFile}\" 2>&1";
        }

        private string GetStreamInfoCommand(string inputFile)
        {
            return $"/C .{Path.DirectorySeparatorChar}ffmpeg{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}ffprobe.exe -i \"{inputFile}\" -v quiet -print_format json -show_streams -select_streams a";
        }
        #endregion

        #region Processes Methods
        private void GetStreamInfo()
        {
            _getStreamInfoProcess = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    FileName = "cmd.exe",
                    Arguments = GetStreamInfoCommand(inputTextBox.Text)
                }
            };
            _getStreamInfoProcess.Start();

            var streams = JsonSerializer.Deserialize<ProbeResults>(Regex.Unescape(_getStreamInfoProcess.StandardOutput.ReadToEnd()));

            _logger.LogInformation(JsonSerializer.Serialize(streams));

            _advancedOptions.dataGridView1.DataSource = streams.streams;
        }

        private void RunTranscoding()
        {
            _transcodingProcess = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    FileName = "cmd.exe",
                    Arguments = TranscodingCommand(inputTextBox.Text, outputTextBox.Text)
                }
            };

            _transcodingProcess.OutputDataReceived += delegate (object o, DataReceivedEventArgs dataReceived)
            {
                progressTextBox.BeginInvoke(new MethodInvoker(() => progressTextBox.AppendText(dataReceived.Data ?? string.Empty)));

                _logger.LogInformation(dataReceived.Data);
            };

            _transcodingProcess.Exited += delegate
            {
                if (File.Exists(outputTextBox.Text))
                {
                    if (!_transcodingProcess.ExitCode.Equals(-1))
                    {
                        progressTextBox.BeginInvoke(new MethodInvoker(() => progressTextBox.AppendText($@"{Environment.NewLine}{Environment.NewLine}PROCESS FINISHED")));
                    }
                    else if (_transcodingProcess.ExitCode.Equals(-1))
                    {
                        progressTextBox.BeginInvoke(new MethodInvoker(() => progressTextBox.AppendText($@"{Environment.NewLine}{Environment.NewLine}CANCELED BY USER")));
                    }
                }
                else
                {
                    progressTextBox.BeginInvoke(new MethodInvoker(() => progressTextBox.AppendText($@"{Environment.NewLine}{Environment.NewLine}ERROR: CAN'T FIND OUTPUT FILE")));
                }
                transcodeButton.BeginInvoke(new MethodInvoker(() => transcodeButton.Visible = true));
                cancelButton.BeginInvoke(new MethodInvoker(() => cancelButton.Visible = false));
            };
            _transcodingProcess.Start();
            _transcodingProcess.BeginOutputReadLine();
        }

        private void KillProcessTreeById(int parentId)
        {
            var processChildren = new ManagementObjectSearcher($"Select * From Win32_Process Where ParentProcessID={parentId}").Get();

            foreach (var child in processChildren)
            {
                KillProcessTreeById(Convert.ToInt32(child["ProcessID"]));
            }

            var parentProcess = Process.GetProcessById(parentId);

            if (!parentProcess.HasExited)
            {
                parentProcess.Kill();
            }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"Video files|*.mp4;*.mov;*.avi;*.flv;*.mkv;*.wmv;";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            inputTextBox.Text = openFileDialog1.FileName;
            outputTextBox.Enabled = true;
            outputButton.Enabled = true;
        }

        #region Button Click Events
        private void inputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void AdvancedOptionsButton_Click(object sender, EventArgs e)
        {
            _advancedOptions.Show();
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = $@"AC3 {Path.GetFileName(inputTextBox.Text)}";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputTextBox.Text = saveFileDialog1.FileName;
            }
        }

        private void TranscodeButton_Click(object sender, EventArgs e)
        {
            progressTextBox.Clear();
            transcodeButton.Visible = false;
            cancelButton.Visible = true;
            RunTranscoding();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            transcodeButton.Visible = false;
            cancelButton.Visible = true;
            KillProcessTreeById(_transcodingProcess.Id);
        }
        #endregion

        #region Text Changed Events
        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            outputTextBox.Text = null;
            saveFileDialog1.Filter = $@"|*{Path.GetExtension(openFileDialog1.FileName)}";
            GetStreamInfo();

            if (!audioInfoButton.Enabled)
            {
                audioInfoButton.Enabled = true;
            }
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputTextBox.Text) && !string.IsNullOrEmpty(outputTextBox.Text))
            {
                transcodeButton.Enabled = true;
            }
            else
            {
                transcodeButton.Enabled = false;
            }
        }
        #endregion
    }
}
