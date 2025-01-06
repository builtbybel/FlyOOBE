namespace FlybyScript
{
    partial class MainForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnTogglePatch = new System.Windows.Forms.Button();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.btnMountRun = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.treeSettings = new System.Windows.Forms.TreeView();
            this.checkInstallationMedia = new System.Windows.Forms.CheckBox();
            this.linkChangeExperience = new System.Windows.Forms.LinkLabel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.BackColor = System.Drawing.Color.White;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.Font = new System.Drawing.Font("Segoe UI Variable Small Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.ForeColor = System.Drawing.Color.Black;
            this.rtbDescription.Location = new System.Drawing.Point(34, 346);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbDescription.Size = new System.Drawing.Size(867, 123);
            this.rtbDescription.TabIndex = 199;
            this.rtbDescription.TabStop = false;
            this.rtbDescription.Text = "";
            // 
            // btnTogglePatch
            // 
            this.btnTogglePatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTogglePatch.BackColor = System.Drawing.Color.White;
            this.btnTogglePatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnTogglePatch.FlatAppearance.BorderSize = 2;
            this.btnTogglePatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnTogglePatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePatch.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTogglePatch.Location = new System.Drawing.Point(629, 484);
            this.btnTogglePatch.Name = "btnTogglePatch";
            this.btnTogglePatch.Size = new System.Drawing.Size(222, 40);
            this.btnTogglePatch.TabIndex = 201;
            this.btnTogglePatch.TabStop = false;
            this.btnTogglePatch.Text = "開始";
            this.btnTogglePatch.UseCompatibleTextRendering = true;
            this.btnTogglePatch.UseVisualStyleBackColor = false;
            this.btnTogglePatch.Click += new System.EventHandler(this.btnTogglePatch_Click);
            // 
            // linkGitHub
            // 
            this.linkGitHub.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkGitHub.AutoEllipsis = true;
            this.linkGitHub.AutoSize = true;
            this.linkGitHub.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.75F);
            this.linkGitHub.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkGitHub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(17)))));
            this.linkGitHub.Location = new System.Drawing.Point(167, 558);
            this.linkGitHub.Name = "linkGitHub";
            this.linkGitHub.Size = new System.Drawing.Size(45, 16);
            this.linkGitHub.TabIndex = 202;
            this.linkGitHub.TabStop = true;
            this.linkGitHub.Text = "GitHub";
            this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGitHub_LinkClicked);
            // 
            // btnMountRun
            // 
            this.btnMountRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMountRun.AutoEllipsis = true;
            this.btnMountRun.BackColor = System.Drawing.Color.White;
            this.btnMountRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMountRun.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMountRun.FlatAppearance.BorderSize = 2;
            this.btnMountRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnMountRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMountRun.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMountRun.Location = new System.Drawing.Point(403, 484);
            this.btnMountRun.Name = "btnMountRun";
            this.btnMountRun.Size = new System.Drawing.Size(220, 40);
            this.btnMountRun.TabIndex = 203;
            this.btnMountRun.TabStop = false;
            this.btnMountRun.Text = "ISO をマウントと実行";
            this.btnMountRun.UseVisualStyleBackColor = false;
            this.btnMountRun.Click += new System.EventHandler(this.btnMountRun_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Yu Gothic UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(115)))), ((int)(((byte)(193)))));
            this.lblHeader.Location = new System.Drawing.Point(30, 38);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(853, 82);
            this.lblHeader.TabIndex = 205;
            this.lblHeader.Text = "FlybyScript を使用し、Windows 11 の制限を回避して非対応のデバイスにインストールします。\r\n";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoEllipsis = true;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.75F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(31, 558);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(119, 16);
            this.linkLabel1.TabIndex = 206;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "A Belim app creation";
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel2.AutoEllipsis = true;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.75F);
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.linkLabel2.Location = new System.Drawing.Point(233, 558);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(51, 16);
            this.linkLabel2.TabIndex = 208;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "0.14.107";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.treeSettings);
            this.panelMain.Controls.Add(this.checkInstallationMedia);
            this.panelMain.Controls.Add(this.linkLabel2);
            this.panelMain.Controls.Add(this.linkChangeExperience);
            this.panelMain.Controls.Add(this.lblHeader);
            this.panelMain.Controls.Add(this.linkLabel1);
            this.panelMain.Controls.Add(this.rtbDescription);
            this.panelMain.Controls.Add(this.btnMountRun);
            this.panelMain.Controls.Add(this.btnTogglePatch);
            this.panelMain.Controls.Add(this.linkGitHub);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(943, 592);
            this.panelMain.TabIndex = 209;
            // 
            // treeSettings
            // 
            this.treeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeSettings.CheckBoxes = true;
            this.treeSettings.Font = new System.Drawing.Font("Segoe UI Variable Text Light", 11.25F);
            this.treeSettings.FullRowSelect = true;
            this.treeSettings.HotTracking = true;
            this.treeSettings.Location = new System.Drawing.Point(36, 168);
            this.treeSettings.Name = "treeSettings";
            this.treeSettings.ShowLines = false;
            this.treeSettings.ShowNodeToolTips = true;
            this.treeSettings.ShowPlusMinus = false;
            this.treeSettings.Size = new System.Drawing.Size(865, 172);
            this.treeSettings.TabIndex = 210;
            this.treeSettings.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeSettings_AfterCheck);
            this.treeSettings.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeSettings_NodeMouseClick);
            // 
            // checkInstallationMedia
            // 
            this.checkInstallationMedia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkInstallationMedia.AutoSize = true;
            this.checkInstallationMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkInstallationMedia.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInstallationMedia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.checkInstallationMedia.Location = new System.Drawing.Point(34, 524);
            this.checkInstallationMedia.Name = "checkInstallationMedia";
            this.checkInstallationMedia.Size = new System.Drawing.Size(264, 21);
            this.checkInstallationMedia.TabIndex = 209;
            this.checkInstallationMedia.Text = "Windows 11 のインストールメディアを作成する";
            this.checkInstallationMedia.UseVisualStyleBackColor = true;
            this.checkInstallationMedia.CheckedChanged += new System.EventHandler(this.checkInstallationMedia_CheckedChanged);
            // 
            // linkChangeExperience
            // 
            this.linkChangeExperience.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkChangeExperience.AutoEllipsis = true;
            this.linkChangeExperience.AutoSize = true;
            this.linkChangeExperience.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.linkChangeExperience.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkChangeExperience.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.linkChangeExperience.Location = new System.Drawing.Point(33, 139);
            this.linkChangeExperience.Name = "linkChangeExperience";
            this.linkChangeExperience.Size = new System.Drawing.Size(213, 17);
            this.linkChangeExperience.TabIndex = 1;
            this.linkChangeExperience.TabStop = true;
            this.linkChangeExperience.Text = "Windows のエクスペリエンスを変更する";
            this.linkChangeExperience.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChangeExperience_LinkClicked);
            this.linkChangeExperience.Paint += new System.Windows.Forms.PaintEventHandler(this.linkChangeExperience_Paint);
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.panelMain);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(943, 592);
            this.panelForm.TabIndex = 210;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 592);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flyby11 アップグレード アシスタント";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnTogglePatch;
        private System.Windows.Forms.LinkLabel linkGitHub;
        private System.Windows.Forms.Button btnMountRun;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.LinkLabel linkChangeExperience;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.CheckBox checkInstallationMedia;
        private System.Windows.Forms.TreeView treeSettings;
    }
}

