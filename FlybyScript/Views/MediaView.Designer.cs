namespace Views
{
    partial class MediaView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBack = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDriveInfo = new System.Windows.Forms.Label();
            this.lblDeviceIDInfo = new System.Windows.Forms.Label();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMCT = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.checkCreateUnattend = new System.Windows.Forms.CheckBox();
            this.comboBoxDriveLetters = new System.Windows.Forms.ComboBox();
            this.linkShowDiskList = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDriveLetterInfo = new System.Windows.Forms.Label();
            this.lblPartitionSchemeInfo = new System.Windows.Forms.Label();
            this.comboBoxPartitionScheme = new System.Windows.Forms.ComboBox();
            this.btnInstallAssistant = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.linkPCHealthCheckApp = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.DarkGray;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(34, 29);
            this.btnBack.TabIndex = 231;
            this.btnBack.Text = "...";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Enabled = false;
            this.rtbLog.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rtbLog.Location = new System.Drawing.Point(59, 334);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(835, 137);
            this.rtbLog.TabIndex = 234;
            this.rtbLog.Text = "待機中";
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.Enabled = false;
            this.comboBoxDrives.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(59, 238);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(121, 25);
            this.comboBoxDrives.TabIndex = 235;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(671, 519);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(205, 37);
            this.btnStart.TabIndex = 236;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "開始";
            this.btnStart.UseCompatibleTextRendering = true;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDriveInfo
            // 
            this.lblDriveInfo.AutoEllipsis = true;
            this.lblDriveInfo.Enabled = false;
            this.lblDriveInfo.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDriveInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.lblDriveInfo.Location = new System.Drawing.Point(55, 192);
            this.lblDriveInfo.Name = "lblDriveInfo";
            this.lblDriveInfo.Size = new System.Drawing.Size(182, 30);
            this.lblDriveInfo.TabIndex = 237;
            this.lblDriveInfo.Tag = "";
            this.lblDriveInfo.Text = "ドライブのプロパティ";
            // 
            // lblDeviceIDInfo
            // 
            this.lblDeviceIDInfo.AutoEllipsis = true;
            this.lblDeviceIDInfo.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceIDInfo.Location = new System.Drawing.Point(57, 222);
            this.lblDeviceIDInfo.Name = "lblDeviceIDInfo";
            this.lblDeviceIDInfo.Size = new System.Drawing.Size(79, 14);
            this.lblDeviceIDInfo.TabIndex = 238;
            this.lblDeviceIDInfo.Tag = "";
            this.lblDeviceIDInfo.Text = "デバイス ID";
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.AutoEllipsis = true;
            this.lblStatusInfo.Enabled = false;
            this.lblStatusInfo.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatusInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.lblStatusInfo.Location = new System.Drawing.Point(55, 303);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(114, 29);
            this.lblStatusInfo.TabIndex = 241;
            this.lblStatusInfo.Tag = "";
            this.lblStatusInfo.Text = "ステータス";
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.White;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSelect.FlatAppearance.BorderSize = 2;
            this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(60, 105);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(132, 33);
            this.btnSelect.TabIndex = 242;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = "選択";
            this.tt.SetToolTip(this.btnSelect, "This built-in method prepares a USB drive for a clean install, enabling a fresh r" +
        "einstallation of your system.");
            this.btnSelect.UseCompatibleTextRendering = true;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(58, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 243;
            this.label6.Tag = "";
            this.label6.Text = "ISO ファイルを選択";
            // 
            // btnMCT
            // 
            this.btnMCT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(180)))));
            this.btnMCT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMCT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(180)))));
            this.btnMCT.FlatAppearance.BorderSize = 2;
            this.btnMCT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(160)))));
            this.btnMCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMCT.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMCT.ForeColor = System.Drawing.Color.White;
            this.btnMCT.Location = new System.Drawing.Point(463, 105);
            this.btnMCT.Name = "btnMCT";
            this.btnMCT.Size = new System.Drawing.Size(214, 33);
            this.btnMCT.TabIndex = 244;
            this.btnMCT.TabStop = false;
            this.btnMCT.Text = "メディア作成ツール (Microsoft)";
            this.tt.SetToolTip(this.btnMCT, "If you want to perform a reinstall or clean install of Windows 11 on a new or use" +
        "d PC, use this option to download the media creation tool to make a bootable USB" +
        " or DVD.");
            this.btnMCT.UseCompatibleTextRendering = true;
            this.btnMCT.UseVisualStyleBackColor = false;
            this.btnMCT.Click += new System.EventHandler(this.btnMCT_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 245;
            this.label7.Tag = "";
            this.label7.Text = "または準備をする";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(60, 476);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(834, 21);
            this.progressBar.TabIndex = 246;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(361, 479);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(226, 17);
            this.lblStatus.TabIndex = 247;
            this.lblStatus.Tag = "";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkCreateUnattend
            // 
            this.checkCreateUnattend.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkCreateUnattend.AutoEllipsis = true;
            this.checkCreateUnattend.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.checkCreateUnattend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkCreateUnattend.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCreateUnattend.Location = new System.Drawing.Point(60, 144);
            this.checkCreateUnattend.Name = "checkCreateUnattend";
            this.checkCreateUnattend.Size = new System.Drawing.Size(214, 32);
            this.checkCreateUnattend.TabIndex = 250;
            this.checkCreateUnattend.Text = "ハードウェア制限を回避してローカルにする";
            this.checkCreateUnattend.UseVisualStyleBackColor = true;
            this.checkCreateUnattend.Visible = false;
            this.checkCreateUnattend.CheckedChanged += new System.EventHandler(this.checkCreateUnattend_CheckedChanged);
            // 
            // comboBoxDriveLetters
            // 
            this.comboBoxDriveLetters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriveLetters.Enabled = false;
            this.comboBoxDriveLetters.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDriveLetters.FormattingEnabled = true;
            this.comboBoxDriveLetters.Location = new System.Drawing.Point(210, 238);
            this.comboBoxDriveLetters.Name = "comboBoxDriveLetters";
            this.comboBoxDriveLetters.Size = new System.Drawing.Size(121, 25);
            this.comboBoxDriveLetters.TabIndex = 251;
            // 
            // linkShowDiskList
            // 
            this.linkShowDiskList.Enabled = false;
            this.linkShowDiskList.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.linkShowDiskList.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.linkShowDiskList.Location = new System.Drawing.Point(56, 266);
            this.linkShowDiskList.Name = "linkShowDiskList";
            this.linkShowDiskList.Size = new System.Drawing.Size(190, 15);
            this.linkShowDiskList.TabIndex = 252;
            this.linkShowDiskList.TabStop = true;
            this.linkShowDiskList.Text = "デバイス ID の特定方法がわかりません";
            this.linkShowDiskList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowDiskList_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(55, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 30);
            this.label3.TabIndex = 253;
            this.label3.Tag = "";
            this.label3.Text = "インストールメディアの作成";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblDriveLetterInfo
            // 
            this.lblDriveLetterInfo.AutoEllipsis = true;
            this.lblDriveLetterInfo.Enabled = false;
            this.lblDriveLetterInfo.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDriveLetterInfo.Location = new System.Drawing.Point(207, 222);
            this.lblDriveLetterInfo.Name = "lblDriveLetterInfo";
            this.lblDriveLetterInfo.Size = new System.Drawing.Size(79, 14);
            this.lblDriveLetterInfo.TabIndex = 254;
            this.lblDriveLetterInfo.Tag = "";
            this.lblDriveLetterInfo.Text = "ドライブレター";
            // 
            // lblPartitionSchemeInfo
            // 
            this.lblPartitionSchemeInfo.AutoEllipsis = true;
            this.lblPartitionSchemeInfo.Enabled = false;
            this.lblPartitionSchemeInfo.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPartitionSchemeInfo.Location = new System.Drawing.Point(361, 222);
            this.lblPartitionSchemeInfo.Name = "lblPartitionSchemeInfo";
            this.lblPartitionSchemeInfo.Size = new System.Drawing.Size(109, 14);
            this.lblPartitionSchemeInfo.TabIndex = 255;
            this.lblPartitionSchemeInfo.Tag = "";
            this.lblPartitionSchemeInfo.Text = "パーティションスキーム";
            // 
            // comboBoxPartitionScheme
            // 
            this.comboBoxPartitionScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartitionScheme.Enabled = false;
            this.comboBoxPartitionScheme.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPartitionScheme.FormattingEnabled = true;
            this.comboBoxPartitionScheme.Location = new System.Drawing.Point(364, 238);
            this.comboBoxPartitionScheme.Name = "comboBoxPartitionScheme";
            this.comboBoxPartitionScheme.Size = new System.Drawing.Size(126, 25);
            this.comboBoxPartitionScheme.TabIndex = 256;
            // 
            // btnInstallAssistant
            // 
            this.btnInstallAssistant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(180)))));
            this.btnInstallAssistant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstallAssistant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(180)))));
            this.btnInstallAssistant.FlatAppearance.BorderSize = 2;
            this.btnInstallAssistant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(160)))));
            this.btnInstallAssistant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallAssistant.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnInstallAssistant.ForeColor = System.Drawing.Color.White;
            this.btnInstallAssistant.Location = new System.Drawing.Point(236, 105);
            this.btnInstallAssistant.Name = "btnInstallAssistant";
            this.btnInstallAssistant.Size = new System.Drawing.Size(214, 33);
            this.btnInstallAssistant.TabIndex = 257;
            this.btnInstallAssistant.TabStop = false;
            this.btnInstallAssistant.Text = "インストール アシスタント (Microsoft)";
            this.tt.SetToolTip(this.btnInstallAssistant, "This is the best option for installing Windows 11 on the device you’re currently " +
        "using.");
            this.btnInstallAssistant.UseCompatibleTextRendering = true;
            this.btnInstallAssistant.UseVisualStyleBackColor = false;
            this.btnInstallAssistant.Click += new System.EventHandler(this.btnInstallAssistant_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(60, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(846, 19);
            this.label1.TabIndex = 258;
            this.label1.Tag = "";
            this.label1.Text = "Windows 11 メディアをインストールまたは作成するには、以下の 3 つのオプションがあります。それぞれを確認後に最適なオプションを決定してください。";
            // 
            // linkPCHealthCheckApp
            // 
            this.linkPCHealthCheckApp.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkPCHealthCheckApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkPCHealthCheckApp.AutoEllipsis = true;
            this.linkPCHealthCheckApp.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkPCHealthCheckApp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkPCHealthCheckApp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkPCHealthCheckApp.Location = new System.Drawing.Point(44, 558);
            this.linkPCHealthCheckApp.Name = "linkPCHealthCheckApp";
            this.linkPCHealthCheckApp.Size = new System.Drawing.Size(607, 15);
            this.linkPCHealthCheckApp.TabIndex = 260;
            this.linkPCHealthCheckApp.TabStop = true;
            this.linkPCHealthCheckApp.Text = "インストールを行う前に、WhyNotWin11 アプリでデバイスが最小システム要件を満たしているか確認してください。";
            this.linkPCHealthCheckApp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPCHealthCheckApp_LinkClicked);
            // 
            // MediaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.linkPCHealthCheckApp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInstallAssistant);
            this.Controls.Add(this.comboBoxPartitionScheme);
            this.Controls.Add(this.lblPartitionSchemeInfo);
            this.Controls.Add(this.lblDriveLetterInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkShowDiskList);
            this.Controls.Add(this.comboBoxDriveLetters);
            this.Controls.Add(this.checkCreateUnattend);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnMCT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblStatusInfo);
            this.Controls.Add(this.lblDeviceIDInfo);
            this.Controls.Add(this.lblDriveInfo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.comboBoxDrives);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnBack);
            this.Name = "MediaView";
            this.Size = new System.Drawing.Size(959, 582);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDriveInfo;
        private System.Windows.Forms.Label lblDeviceIDInfo;
        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMCT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox checkCreateUnattend;
        private System.Windows.Forms.ComboBox comboBoxDriveLetters;
        private System.Windows.Forms.LinkLabel linkShowDiskList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDriveLetterInfo;
        private System.Windows.Forms.Label lblPartitionSchemeInfo;
        private System.Windows.Forms.ComboBox comboBoxPartitionScheme;
        private System.Windows.Forms.Button btnInstallAssistant;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkPCHealthCheckApp;
    }
}
