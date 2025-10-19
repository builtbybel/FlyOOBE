namespace Flyoobe
{
    partial class DefaultsControlView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBrowsers = new System.Windows.Forms.ComboBox();
            this.btnSetDefaultBrowser = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.checkNeedOtherBrowser = new System.Windows.Forms.CheckBox();
            this.comboDownload = new System.Windows.Forms.ComboBox();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.checkRunAsAdmin = new System.Windows.Forms.CheckBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBrowsers);
            this.panel1.Controls.Add(this.btnSetDefaultBrowser);
            this.panel1.Location = new System.Drawing.Point(23, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 383);
            this.panel1.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Set as default";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // comboBrowsers
            // 
            this.comboBrowsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBrowsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(222)))), ((int)(((byte)(218)))));
            this.comboBrowsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrowsers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBrowsers.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11.5F, System.Drawing.FontStyle.Bold);
            this.comboBrowsers.ForeColor = System.Drawing.Color.Black;
            this.comboBrowsers.FormattingEnabled = true;
            this.comboBrowsers.Location = new System.Drawing.Point(34, 64);
            this.comboBrowsers.Name = "comboBrowsers";
            this.comboBrowsers.Size = new System.Drawing.Size(728, 28);
            this.comboBrowsers.TabIndex = 34;
            this.comboBrowsers.TabStop = false;
            // 
            // btnSetDefaultBrowser
            // 
            this.btnSetDefaultBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDefaultBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnSetDefaultBrowser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnSetDefaultBrowser.FlatAppearance.BorderSize = 0;
            this.btnSetDefaultBrowser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnSetDefaultBrowser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnSetDefaultBrowser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetDefaultBrowser.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnSetDefaultBrowser.ForeColor = System.Drawing.Color.Black;
            this.btnSetDefaultBrowser.Location = new System.Drawing.Point(561, 333);
            this.btnSetDefaultBrowser.Name = "btnSetDefaultBrowser";
            this.btnSetDefaultBrowser.Size = new System.Drawing.Size(231, 35);
            this.btnSetDefaultBrowser.TabIndex = 31;
            this.btnSetDefaultBrowser.Text = "Set default Browser";
            this.btnSetDefaultBrowser.UseCompatibleTextRendering = true;
            this.btnSetDefaultBrowser.UseVisualStyleBackColor = false;
            this.btnSetDefaultBrowser.Click += new System.EventHandler(this.btnSetDefaultBrowser_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.75F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(835, 31);
            this.lblStatus.TabIndex = 36;
            this.lblStatus.Text = "Choose your browser";
            this.lblStatus.UseCompatibleTextRendering = true;
            // 
            // checkNeedOtherBrowser
            // 
            this.checkNeedOtherBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkNeedOtherBrowser.AutoEllipsis = true;
            this.checkNeedOtherBrowser.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.checkNeedOtherBrowser.ForeColor = System.Drawing.Color.Black;
            this.checkNeedOtherBrowser.Location = new System.Drawing.Point(23, 427);
            this.checkNeedOtherBrowser.Name = "checkNeedOtherBrowser";
            this.checkNeedOtherBrowser.Size = new System.Drawing.Size(768, 27);
            this.checkNeedOtherBrowser.TabIndex = 38;
            this.checkNeedOtherBrowser.Text = "I need a browser other than Edge";
            this.checkNeedOtherBrowser.UseCompatibleTextRendering = true;
            this.checkNeedOtherBrowser.UseVisualStyleBackColor = true;
            this.checkNeedOtherBrowser.CheckedChanged += new System.EventHandler(this.checkNeedOtherBrowser_CheckedChanged);
            // 
            // comboDownload
            // 
            this.comboDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(222)))), ((int)(((byte)(218)))));
            this.comboDownload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboDownload.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11.5F, System.Drawing.FontStyle.Bold);
            this.comboDownload.ForeColor = System.Drawing.Color.Black;
            this.comboDownload.FormattingEnabled = true;
            this.comboDownload.Location = new System.Drawing.Point(34, 64);
            this.comboDownload.Name = "comboDownload";
            this.comboDownload.Size = new System.Drawing.Size(728, 28);
            this.comboDownload.TabIndex = 36;
            this.comboDownload.TabStop = false;
            // 
            // panelDownload
            // 
            this.panelDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDownload.AutoScroll = true;
            this.panelDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.panelDownload.Controls.Add(this.checkRunAsAdmin);
            this.panelDownload.Controls.Add(this.btnInstall);
            this.panelDownload.Controls.Add(this.label2);
            this.panelDownload.Controls.Add(this.comboDownload);
            this.panelDownload.Location = new System.Drawing.Point(23, 38);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(795, 383);
            this.panelDownload.TabIndex = 39;
            this.panelDownload.Visible = false;
            // 
            // checkRunAsAdmin
            // 
            this.checkRunAsAdmin.AutoEllipsis = true;
            this.checkRunAsAdmin.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.checkRunAsAdmin.ForeColor = System.Drawing.Color.Black;
            this.checkRunAsAdmin.Location = new System.Drawing.Point(34, 95);
            this.checkRunAsAdmin.Name = "checkRunAsAdmin";
            this.checkRunAsAdmin.Size = new System.Drawing.Size(320, 27);
            this.checkRunAsAdmin.TabIndex = 39;
            this.checkRunAsAdmin.Text = "Run as Admin";
            this.checkRunAsAdmin.UseCompatibleTextRendering = true;
            this.checkRunAsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnInstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnInstall.FlatAppearance.BorderSize = 0;
            this.btnInstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnInstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInstall.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnInstall.ForeColor = System.Drawing.Color.Black;
            this.btnInstall.Location = new System.Drawing.Point(561, 333);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(231, 35);
            this.btnInstall.TabIndex = 38;
            this.btnInstall.Text = "Install Browser";
            this.btnInstall.UseCompatibleTextRendering = true;
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 37;
            this.label2.Text = "Download browser";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // DefaultsControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.checkNeedOtherBrowser);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelDownload);
            this.Controls.Add(this.panel1);
            this.Name = "DefaultsControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBrowsers;
        private System.Windows.Forms.Button btnSetDefaultBrowser;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox checkNeedOtherBrowser;
        private System.Windows.Forms.ComboBox comboDownload;
        private System.Windows.Forms.Panel panelDownload;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkRunAsAdmin;
    }
}
