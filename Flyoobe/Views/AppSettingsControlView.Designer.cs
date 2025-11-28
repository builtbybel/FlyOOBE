namespace Flyoobe.Views
{
    partial class AppSettingsControlView
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
            this.panelForm = new System.Windows.Forms.Panel();
            this.chkDonated = new System.Windows.Forms.CheckBox();
            this.btnDonate = new System.Windows.Forms.Button();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnUpdateCheck = new System.Windows.Forms.Button();
            this.btnUIBackground = new System.Windows.Forms.Button();
            this.linkCodename = new System.Windows.Forms.LinkLabel();
            this.linkAppVersion = new System.Windows.Forms.LinkLabel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForm.AutoScroll = true;
            this.panelForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.panelForm.Controls.Add(this.chkDonated);
            this.panelForm.Controls.Add(this.btnDonate);
            this.panelForm.Controls.Add(this.lblCopyright);
            this.panelForm.Location = new System.Drawing.Point(107, 150);
            this.panelForm.Margin = new System.Windows.Forms.Padding(4);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(595, 125);
            this.panelForm.TabIndex = 323;
            this.panelForm.TabStop = true;
            // 
            // chkDonated
            // 
            this.chkDonated.AutoEllipsis = true;
            this.chkDonated.BackColor = System.Drawing.Color.Transparent;
            this.chkDonated.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDonated.ForeColor = System.Drawing.Color.Black;
            this.chkDonated.Location = new System.Drawing.Point(28, 102);
            this.chkDonated.Margin = new System.Windows.Forms.Padding(4);
            this.chkDonated.Name = "chkDonated";
            this.chkDonated.Size = new System.Drawing.Size(146, 19);
            this.chkDonated.TabIndex = 1;
            this.chkDonated.Text = "I have already donated";
            this.chkDonated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDonated.UseVisualStyleBackColor = false;
            this.chkDonated.CheckedChanged += new System.EventHandler(this.chkDonated_CheckedChanged);
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonate.AutoEllipsis = true;
            this.btnDonate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(32)))));
            this.btnDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDonate.FlatAppearance.BorderSize = 2;
            this.btnDonate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDonate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDonate.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonate.ForeColor = System.Drawing.Color.White;
            this.btnDonate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonate.Location = new System.Drawing.Point(18, 60);
            this.btnDonate.Margin = new System.Windows.Forms.Padding(4);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(560, 40);
            this.btnDonate.TabIndex = 331;
            this.btnDonate.TabStop = false;
            this.btnDonate.Text = "Donate";
            this.btnDonate.UseCompatibleTextRendering = true;
            this.btnDonate.UseVisualStyleBackColor = false;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.AutoEllipsis = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.75F);
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Location = new System.Drawing.Point(130, 19);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(354, 27);
            this.lblCopyright.TabIndex = 319;
            this.lblCopyright.Text = "A Belim app creation (C) 2025";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyright.UseCompatibleTextRendering = true;
            // 
            // btnUpdateCheck
            // 
            this.btnUpdateCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCheck.AutoEllipsis = true;
            this.btnUpdateCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateCheck.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUpdateCheck.FlatAppearance.BorderSize = 2;
            this.btnUpdateCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(80)))), ((int)(((byte)(228)))));
            this.btnUpdateCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(80)))), ((int)(((byte)(228)))));
            this.btnUpdateCheck.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F);
            this.btnUpdateCheck.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateCheck.Location = new System.Drawing.Point(508, 302);
            this.btnUpdateCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateCheck.Name = "btnUpdateCheck";
            this.btnUpdateCheck.Size = new System.Drawing.Size(194, 32);
            this.btnUpdateCheck.TabIndex = 317;
            this.btnUpdateCheck.TabStop = false;
            this.btnUpdateCheck.Text = "Check for updates";
            this.btnUpdateCheck.UseCompatibleTextRendering = true;
            this.btnUpdateCheck.UseVisualStyleBackColor = false;
            this.btnUpdateCheck.Click += new System.EventHandler(this.btnUpdateCheck_Click);
            // 
            // btnUIBackground
            // 
            this.btnUIBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUIBackground.BackColor = System.Drawing.Color.Transparent;
            this.btnUIBackground.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F);
            this.btnUIBackground.ForeColor = System.Drawing.Color.Black;
            this.btnUIBackground.Location = new System.Drawing.Point(584, 354);
            this.btnUIBackground.Name = "btnUIBackground";
            this.btnUIBackground.Size = new System.Drawing.Size(118, 32);
            this.btnUIBackground.TabIndex = 510;
            this.btnUIBackground.Text = "Change";
            this.btnUIBackground.UseCompatibleTextRendering = true;
            this.btnUIBackground.UseVisualStyleBackColor = false;
            this.btnUIBackground.Click += new System.EventHandler(this.btnUIBackground_Click);
            // 
            // linkCodename
            // 
            this.linkCodename.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkCodename.AutoEllipsis = true;
            this.linkCodename.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 10F, System.Drawing.FontStyle.Bold);
            this.linkCodename.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkCodename.LinkColor = System.Drawing.Color.Black;
            this.linkCodename.Location = new System.Drawing.Point(182, 60);
            this.linkCodename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkCodename.Name = "linkCodename";
            this.linkCodename.Size = new System.Drawing.Size(446, 28);
            this.linkCodename.TabIndex = 335;
            this.linkCodename.TabStop = true;
            this.linkCodename.Text = "Your WinPilot for Setup, Tweaks && Mods";
            this.linkCodename.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkAppVersion
            // 
            this.linkAppVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkAppVersion.AutoEllipsis = true;
            this.linkAppVersion.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold);
            this.linkAppVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAppVersion.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.linkAppVersion.Location = new System.Drawing.Point(182, 96);
            this.linkAppVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkAppVersion.Name = "linkAppVersion";
            this.linkAppVersion.Size = new System.Drawing.Size(446, 50);
            this.linkAppVersion.TabIndex = 334;
            this.linkAppVersion.TabStop = true;
            this.linkAppVersion.Text = "Version";
            this.linkAppVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkAppVersion.UseCompatibleTextRendering = true;
            this.linkAppVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAppVersion_LinkClicked);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Display", 21.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(182, 10);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(446, 50);
            this.lblHeader.TabIndex = 330;
            this.lblHeader.Text = "FlyOOBE";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(107, 359);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 27);
            this.label1.TabIndex = 511;
            this.label1.Text = "Pick a background for App";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(107, 307);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 27);
            this.label2.TabIndex = 512;
            this.label2.Text = "App updates";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // AppSettingsControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUIBackground);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.btnUpdateCheck);
            this.Controls.Add(this.linkCodename);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.linkAppVersion);
            this.Name = "AppSettingsControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.Load += new System.EventHandler(this.AppSettingsControlView_Load);
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnUIBackground;
        private System.Windows.Forms.LinkLabel linkCodename;
        private System.Windows.Forms.LinkLabel linkAppVersion;
        private System.Windows.Forms.CheckBox chkDonated;
        private System.Windows.Forms.Button btnDonate;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnUpdateCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
