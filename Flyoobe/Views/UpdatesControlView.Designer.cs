namespace Flyoobe
{
    partial class UpdatesControlView
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
            this.assetViewInfo = new System.Windows.Forms.Label();
            this.btnCheckUpdates = new System.Windows.Forms.Button();
            this.updatesListBox = new System.Windows.Forms.CheckedListBox();
            this.btnInstallUpdates = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // assetViewInfo
            // 
            this.assetViewInfo.AutoSize = true;
            this.assetViewInfo.Font = new System.Drawing.Font("Segoe MDL2 Assets", 60.75F);
            this.assetViewInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.assetViewInfo.Location = new System.Drawing.Point(9, 19);
            this.assetViewInfo.Name = "assetViewInfo";
            this.assetViewInfo.Size = new System.Drawing.Size(86, 81);
            this.assetViewInfo.TabIndex = 10;
            this.assetViewInfo.Text = "...";
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnCheckUpdates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnCheckUpdates.FlatAppearance.BorderSize = 0;
            this.btnCheckUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(205)))), ((int)(((byte)(250)))));
            this.btnCheckUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(205)))), ((int)(((byte)(250)))));
            this.btnCheckUpdates.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.25F);
            this.btnCheckUpdates.ForeColor = System.Drawing.Color.White;
            this.btnCheckUpdates.Location = new System.Drawing.Point(651, 55);
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.Size = new System.Drawing.Size(160, 35);
            this.btnCheckUpdates.TabIndex = 11;
            this.btnCheckUpdates.Text = "Check for updates";
            this.btnCheckUpdates.UseCompatibleTextRendering = true;
            this.btnCheckUpdates.UseVisualStyleBackColor = false;
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // updatesListBox
            // 
            this.updatesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.updatesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.updatesListBox.CheckOnClick = true;
            this.updatesListBox.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.5F);
            this.updatesListBox.ForeColor = System.Drawing.Color.Black;
            this.updatesListBox.FormattingEnabled = true;
            this.updatesListBox.Location = new System.Drawing.Point(23, 129);
            this.updatesListBox.Name = "updatesListBox";
            this.updatesListBox.Size = new System.Drawing.Size(788, 273);
            this.updatesListBox.TabIndex = 12;
            this.updatesListBox.UseCompatibleTextRendering = true;
            // 
            // btnInstallUpdates
            // 
            this.btnInstallUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnInstallUpdates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnInstallUpdates.FlatAppearance.BorderSize = 0;
            this.btnInstallUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnInstallUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnInstallUpdates.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.25F);
            this.btnInstallUpdates.ForeColor = System.Drawing.Color.White;
            this.btnInstallUpdates.Location = new System.Drawing.Point(651, 55);
            this.btnInstallUpdates.Name = "btnInstallUpdates";
            this.btnInstallUpdates.Size = new System.Drawing.Size(160, 35);
            this.btnInstallUpdates.TabIndex = 13;
            this.btnInstallUpdates.Text = "Install updates";
            this.btnInstallUpdates.UseCompatibleTextRendering = true;
            this.btnInstallUpdates.UseVisualStyleBackColor = false;
            this.btnInstallUpdates.Visible = false;
            this.btnInstallUpdates.Click += new System.EventHandler(this.btnInstallUpdates_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 447);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(835, 10);
            this.progressBar.TabIndex = 14;
            this.progressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(131, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(500, 76);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Update check pending.";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 10.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(766, 22);
            this.label4.TabIndex = 23;
            this.label4.Text = "Lowering CO₂ and system requirements — this app installs Windows 11 on hardware M" +
    "icrosoft forgot about.";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // UpdatesControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.updatesListBox);
            this.Controls.Add(this.assetViewInfo);
            this.Controls.Add(this.btnInstallUpdates);
            this.Controls.Add(this.btnCheckUpdates);
            this.Name = "UpdatesControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label assetViewInfo;
        private System.Windows.Forms.Button btnCheckUpdates;
        private System.Windows.Forms.CheckedListBox updatesListBox;
        private System.Windows.Forms.Button btnInstallUpdates;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
    }
}
