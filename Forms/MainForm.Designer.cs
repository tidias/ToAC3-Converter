using System.Windows.Forms;

namespace ToAC3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.transcodeButton = new System.Windows.Forms.Button();
            this.progressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cancelButton = new System.Windows.Forms.Button();
            this.audioInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 44);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ReadOnly = true;
            this.inputTextBox.Size = new System.Drawing.Size(269, 23);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // inputButton
            // 
            this.inputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputButton.Location = new System.Drawing.Point(287, 44);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(85, 23);
            this.inputButton.TabIndex = 1;
            this.inputButton.Text = "Input";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Location = new System.Drawing.Point(12, 105);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(269, 23);
            this.outputTextBox.TabIndex = 2;
            this.outputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // outputButton
            // 
            this.outputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputButton.Enabled = false;
            this.outputButton.Location = new System.Drawing.Point(287, 105);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(85, 23);
            this.outputButton.TabIndex = 3;
            this.outputButton.Text = "Output";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // transcodeButton
            // 
            this.transcodeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.transcodeButton.Enabled = false;
            this.transcodeButton.Location = new System.Drawing.Point(125, 269);
            this.transcodeButton.Name = "transcodeButton";
            this.transcodeButton.Size = new System.Drawing.Size(130, 30);
            this.transcodeButton.TabIndex = 4;
            this.transcodeButton.Text = "Start Transcoding";
            this.transcodeButton.UseVisualStyleBackColor = true;
            this.transcodeButton.Click += new System.EventHandler(this.TranscodeButton_Click);
            // 
            // progressTextBox
            // 
            this.progressTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressTextBox.Location = new System.Drawing.Point(45, 176);
            this.progressTextBox.Multiline = true;
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.ReadOnly = true;
            this.progressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progressTextBox.Size = new System.Drawing.Size(300, 85);
            this.progressTextBox.TabIndex = 6;
            this.progressTextBox.Text = "Waiting for start...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Source Video File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output Video File";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(125, 269);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(130, 30);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // audioInfoButton
            // 
            this.audioInfoButton.Enabled = false;
            this.audioInfoButton.Location = new System.Drawing.Point(242, 145);
            this.audioInfoButton.Name = "audioInfoButton";
            this.audioInfoButton.Size = new System.Drawing.Size(130, 25);
            this.audioInfoButton.TabIndex = 10;
            this.audioInfoButton.Text = "Check Audio Streams";
            this.audioInfoButton.UseVisualStyleBackColor = true;
            this.audioInfoButton.Click += new System.EventHandler(this.AdvancedOptionsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.audioInfoButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressTextBox);
            this.Controls.Add(this.transcodeButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.inputTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DTS2AC3";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button transcodeButton;
        private System.Windows.Forms.TextBox progressTextBox;
        private Label label1;
        private Label label2;
        private SaveFileDialog saveFileDialog1;
        private Button cancelButton;
        private Button audioInfoButton;
    }
}

