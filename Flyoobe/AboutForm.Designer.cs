namespace Flyoobe
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkCodename = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.linkAppVersion = new System.Windows.Forms.LinkLabel();
            this.chkDonated = new System.Windows.Forms.CheckBox();
            this.btnDonate = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.linkCodename);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.linkAppVersion);
            this.panel1.Controls.Add(this.chkDonated);
            this.panel1.Controls.Add(this.btnDonate);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.lblCopyright);
            this.panel1.Controls.Add(this.btnGitHub);
            this.panel1.Location = new System.Drawing.Point(14, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 404);
            this.panel1.TabIndex = 322;
            this.panel1.TabStop = true;
            // 
            // linkCodename
            // 
            this.linkCodename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkCodename.AutoEllipsis = true;
            this.linkCodename.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.linkCodename.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkCodename.LinkColor = System.Drawing.Color.PaleVioletRed;
            this.linkCodename.Location = new System.Drawing.Point(4, 74);
            this.linkCodename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkCodename.Name = "linkCodename";
            this.linkCodename.Size = new System.Drawing.Size(474, 28);
            this.linkCodename.TabIndex = 335;
            this.linkCodename.TabStop = true;
            this.linkCodename.Text = "(Winpilot)";
            this.linkCodename.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkCodename.UseCompatibleTextRendering = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(451, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 38);
            this.btnClose.TabIndex = 332;
            this.btnClose.Text = "...";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linkAppVersion
            // 
            this.linkAppVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAppVersion.AutoEllipsis = true;
            this.linkAppVersion.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold);
            this.linkAppVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAppVersion.LinkColor = System.Drawing.Color.Black;
            this.linkAppVersion.Location = new System.Drawing.Point(4, 116);
            this.linkAppVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkAppVersion.Name = "linkAppVersion";
            this.linkAppVersion.Size = new System.Drawing.Size(483, 60);
            this.linkAppVersion.TabIndex = 334;
            this.linkAppVersion.TabStop = true;
            this.linkAppVersion.Text = "Version";
            this.linkAppVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkAppVersion.UseCompatibleTextRendering = true;
            this.linkAppVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAppVersion_LinkClicked);
            // 
            // chkDonated
            // 
            this.chkDonated.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkDonated.AutoSize = true;
            this.chkDonated.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDonated.ForeColor = System.Drawing.Color.Black;
            this.chkDonated.Location = new System.Drawing.Point(22, 370);
            this.chkDonated.Margin = new System.Windows.Forms.Padding(4);
            this.chkDonated.Name = "chkDonated";
            this.chkDonated.Size = new System.Drawing.Size(141, 19);
            this.chkDonated.TabIndex = 1;
            this.chkDonated.Text = "I have already donated";
            this.chkDonated.UseVisualStyleBackColor = true;
            this.chkDonated.CheckedChanged += new System.EventHandler(this.chkDonated_CheckedChanged);
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDonate.AutoEllipsis = true;
            this.btnDonate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(32)))));
            this.btnDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDonate.FlatAppearance.BorderSize = 2;
            this.btnDonate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(80)))), ((int)(((byte)(228)))));
            this.btnDonate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(80)))), ((int)(((byte)(228)))));
            this.btnDonate.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11F, System.Drawing.FontStyle.Bold);
            this.btnDonate.ForeColor = System.Drawing.Color.White;
            this.btnDonate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonate.Location = new System.Drawing.Point(22, 297);
            this.btnDonate.Margin = new System.Windows.Forms.Padding(4);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(447, 46);
            this.btnDonate.TabIndex = 331;
            this.btnDonate.TabStop = false;
            this.btnDonate.Text = "Donate";
            this.btnDonate.UseCompatibleTextRendering = true;
            this.btnDonate.UseVisualStyleBackColor = false;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(4, 26);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(483, 50);
            this.lblHeader.TabIndex = 330;
            this.lblHeader.Text = "FlyOOBE";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.75F);
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Location = new System.Drawing.Point(68, 190);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(354, 27);
            this.lblCopyright.TabIndex = 319;
            this.lblCopyright.Text = "A Belim app creation (C) 2025";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyright.UseCompatibleTextRendering = true;
            // 
            // btnGitHub
            // 
            this.btnGitHub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGitHub.AutoEllipsis = true;
            this.btnGitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(32)))));
            this.btnGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGitHub.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGitHub.FlatAppearance.BorderSize = 2;
            this.btnGitHub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(80)))), ((int)(((byte)(228)))));
            this.btnGitHub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(80)))), ((int)(((byte)(228)))));
            this.btnGitHub.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11F, System.Drawing.FontStyle.Bold);
            this.btnGitHub.ForeColor = System.Drawing.Color.White;
            this.btnGitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGitHub.Location = new System.Drawing.Point(22, 248);
            this.btnGitHub.Margin = new System.Windows.Forms.Padding(4);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(447, 46);
            this.btnGitHub.TabIndex = 317;
            this.btnGitHub.TabStop = false;
            this.btnGitHub.Text = "GitHub";
            this.btnGitHub.UseCompatibleTextRendering = true;
            this.btnGitHub.UseVisualStyleBackColor = false;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(517, 439);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AboutForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnGitHub;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDonate;
        private System.Windows.Forms.CheckBox chkDonated;
        private System.Windows.Forms.LinkLabel linkAppVersion;
        private System.Windows.Forms.LinkLabel linkCodename;
    }
}