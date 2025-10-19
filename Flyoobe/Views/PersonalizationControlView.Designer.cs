namespace Flyoobe
{
    partial class PersonalizationControlView
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
            this.btnChangeAccent = new System.Windows.Forms.Button();
            this.btnChangeWallpaper = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnApplyTheme = new System.Windows.Forms.Button();
            this.checkToggleTransparency = new System.Windows.Forms.CheckBox();
            this.pictureBoxWallpaper = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTaskbarAlignment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSystemTheme = new System.Windows.Forms.ComboBox();
            this.comboAppTheme = new System.Windows.Forms.ComboBox();
            this.btnChangeDesktopIcons = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWallpaper)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangeAccent
            // 
            this.btnChangeAccent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeAccent.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeAccent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnChangeAccent.FlatAppearance.BorderSize = 2;
            this.btnChangeAccent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnChangeAccent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnChangeAccent.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeAccent.ForeColor = System.Drawing.Color.Black;
            this.btnChangeAccent.Location = new System.Drawing.Point(160, 427);
            this.btnChangeAccent.Name = "btnChangeAccent";
            this.btnChangeAccent.Size = new System.Drawing.Size(138, 27);
            this.btnChangeAccent.TabIndex = 22;
            this.btnChangeAccent.Text = "Choose accent colors";
            this.btnChangeAccent.UseCompatibleTextRendering = true;
            this.btnChangeAccent.UseVisualStyleBackColor = false;
            this.btnChangeAccent.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnChangeWallpaper
            // 
            this.btnChangeWallpaper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeWallpaper.AutoSize = true;
            this.btnChangeWallpaper.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeWallpaper.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnChangeWallpaper.FlatAppearance.BorderSize = 2;
            this.btnChangeWallpaper.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnChangeWallpaper.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnChangeWallpaper.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeWallpaper.ForeColor = System.Drawing.Color.Black;
            this.btnChangeWallpaper.Location = new System.Drawing.Point(16, 427);
            this.btnChangeWallpaper.Name = "btnChangeWallpaper";
            this.btnChangeWallpaper.Size = new System.Drawing.Size(138, 27);
            this.btnChangeWallpaper.TabIndex = 21;
            this.btnChangeWallpaper.Text = "Choose background";
            this.btnChangeWallpaper.UseCompatibleTextRendering = true;
            this.btnChangeWallpaper.UseVisualStyleBackColor = false;
            this.btnChangeWallpaper.Click += new System.EventHandler(this.btnChangeWallpaper_Click);
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
            this.lblStatus.TabIndex = 28;
            this.lblStatus.Text = "Let\'s personalize your device";
            // 
            // btnApplyTheme
            // 
            this.btnApplyTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnApplyTheme.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnApplyTheme.FlatAppearance.BorderSize = 0;
            this.btnApplyTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnApplyTheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnApplyTheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApplyTheme.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnApplyTheme.ForeColor = System.Drawing.Color.Black;
            this.btnApplyTheme.Location = new System.Drawing.Point(46, 315);
            this.btnApplyTheme.Name = "btnApplyTheme";
            this.btnApplyTheme.Size = new System.Drawing.Size(666, 35);
            this.btnApplyTheme.TabIndex = 31;
            this.btnApplyTheme.Text = "Apply theme";
            this.btnApplyTheme.UseCompatibleTextRendering = true;
            this.btnApplyTheme.UseVisualStyleBackColor = false;
            this.btnApplyTheme.Click += new System.EventHandler(this.btnApplyTheme_Click);
            // 
            // checkToggleTransparency
            // 
            this.checkToggleTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkToggleTransparency.AutoEllipsis = true;
            this.checkToggleTransparency.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkToggleTransparency.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11.25F);
            this.checkToggleTransparency.ForeColor = System.Drawing.Color.Black;
            this.checkToggleTransparency.Location = new System.Drawing.Point(41, 140);
            this.checkToggleTransparency.Name = "checkToggleTransparency";
            this.checkToggleTransparency.Size = new System.Drawing.Size(671, 27);
            this.checkToggleTransparency.TabIndex = 32;
            this.checkToggleTransparency.Text = "Toggle Transparency";
            this.checkToggleTransparency.UseVisualStyleBackColor = true;
            // 
            // pictureBoxWallpaper
            // 
            this.pictureBoxWallpaper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWallpaper.Location = new System.Drawing.Point(143, 173);
            this.pictureBoxWallpaper.Name = "pictureBoxWallpaper";
            this.pictureBoxWallpaper.Size = new System.Drawing.Size(474, 122);
            this.pictureBoxWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWallpaper.TabIndex = 33;
            this.pictureBoxWallpaper.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboTaskbarAlignment);
            this.panel1.Controls.Add(this.pictureBoxWallpaper);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboSystemTheme);
            this.panel1.Controls.Add(this.comboAppTheme);
            this.panel1.Controls.Add(this.btnApplyTheme);
            this.panel1.Controls.Add(this.checkToggleTransparency);
            this.panel1.Location = new System.Drawing.Point(30, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 369);
            this.panel1.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(41, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Taskbar Alignment";
            // 
            // comboTaskbarAlignment
            // 
            this.comboTaskbarAlignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboTaskbarAlignment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.comboTaskbarAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTaskbarAlignment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboTaskbarAlignment.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10F);
            this.comboTaskbarAlignment.ForeColor = System.Drawing.Color.Black;
            this.comboTaskbarAlignment.FormattingEnabled = true;
            this.comboTaskbarAlignment.Location = new System.Drawing.Point(179, 100);
            this.comboTaskbarAlignment.Name = "comboTaskbarAlignment";
            this.comboTaskbarAlignment.Size = new System.Drawing.Size(532, 25);
            this.comboTaskbarAlignment.TabIndex = 37;
            this.comboTaskbarAlignment.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "App mode";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Windows mode";
            // 
            // comboSystemTheme
            // 
            this.comboSystemTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSystemTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.comboSystemTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSystemTheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboSystemTheme.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10F);
            this.comboSystemTheme.ForeColor = System.Drawing.Color.Black;
            this.comboSystemTheme.FormattingEnabled = true;
            this.comboSystemTheme.Location = new System.Drawing.Point(179, 27);
            this.comboSystemTheme.Name = "comboSystemTheme";
            this.comboSystemTheme.Size = new System.Drawing.Size(532, 25);
            this.comboSystemTheme.TabIndex = 34;
            this.comboSystemTheme.TabStop = false;
            // 
            // comboAppTheme
            // 
            this.comboAppTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboAppTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.comboAppTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAppTheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboAppTheme.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10F);
            this.comboAppTheme.ForeColor = System.Drawing.Color.Black;
            this.comboAppTheme.FormattingEnabled = true;
            this.comboAppTheme.Location = new System.Drawing.Point(179, 64);
            this.comboAppTheme.Name = "comboAppTheme";
            this.comboAppTheme.Size = new System.Drawing.Size(532, 25);
            this.comboAppTheme.TabIndex = 33;
            this.comboAppTheme.TabStop = false;
            // 
            // btnChangeDesktopIcons
            // 
            this.btnChangeDesktopIcons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeDesktopIcons.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeDesktopIcons.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnChangeDesktopIcons.FlatAppearance.BorderSize = 2;
            this.btnChangeDesktopIcons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnChangeDesktopIcons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnChangeDesktopIcons.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeDesktopIcons.ForeColor = System.Drawing.Color.Black;
            this.btnChangeDesktopIcons.Location = new System.Drawing.Point(304, 427);
            this.btnChangeDesktopIcons.Name = "btnChangeDesktopIcons";
            this.btnChangeDesktopIcons.Size = new System.Drawing.Size(138, 27);
            this.btnChangeDesktopIcons.TabIndex = 39;
            this.btnChangeDesktopIcons.Text = "Choose Desktop icons";
            this.btnChangeDesktopIcons.UseCompatibleTextRendering = true;
            this.btnChangeDesktopIcons.UseVisualStyleBackColor = false;
            this.btnChangeDesktopIcons.Click += new System.EventHandler(this.btnChangeDesktopIcons_Click);
            // 
            // PersonalizationControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnChangeDesktopIcons);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnChangeWallpaper);
            this.Controls.Add(this.btnChangeAccent);
            this.Name = "PersonalizationControlView";
            this.Size = new System.Drawing.Size(835, 457);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWallpaper)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnChangeAccent;
        private System.Windows.Forms.Button btnChangeWallpaper;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnApplyTheme;
        private System.Windows.Forms.CheckBox checkToggleTransparency;
        private System.Windows.Forms.PictureBox pictureBoxWallpaper;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboAppTheme;
        private System.Windows.Forms.ComboBox comboSystemTheme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTaskbarAlignment;
        private System.Windows.Forms.Button btnChangeDesktopIcons;
    }
}
