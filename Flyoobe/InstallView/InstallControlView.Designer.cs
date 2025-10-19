namespace Flyoobe
{
    partial class InstallControlView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textProviderSearch = new System.Windows.Forms.TextBox();
            this.btnQuickRepair = new System.Windows.Forms.Button();
            this.btnCreateUsb = new System.Windows.Forms.Button();
            this.lblOneClick = new System.Windows.Forms.Label();
            this.panelInstall = new System.Windows.Forms.Panel();
            this.lblBadgeDl = new System.Windows.Forms.Label();
            this.lblBadgeIso = new System.Windows.Forms.Label();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.lblBadgeExternal = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblBadgeNative = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panelInstall.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.textProviderSearch);
            this.panel1.Controls.Add(this.btnQuickRepair);
            this.panel1.Controls.Add(this.btnCreateUsb);
            this.panel1.Controls.Add(this.lblOneClick);
            this.panel1.Controls.Add(this.panelInstall);
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 457);
            this.panel1.TabIndex = 11;
            // 
            // textProviderSearch
            // 
            this.textProviderSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.textProviderSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textProviderSearch.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F);
            this.textProviderSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textProviderSearch.Location = new System.Drawing.Point(196, 18);
            this.textProviderSearch.Name = "textProviderSearch";
            this.textProviderSearch.Size = new System.Drawing.Size(473, 25);
            this.textProviderSearch.TabIndex = 339;
            this.textProviderSearch.Text = "Search";
            this.textProviderSearch.Click += new System.EventHandler(this.textProviderSearch_Click);
            // 
            // btnQuickRepair
            // 
            this.btnQuickRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickRepair.BackColor = System.Drawing.Color.Transparent;
            this.btnQuickRepair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.btnQuickRepair.FlatAppearance.BorderSize = 2;
            this.btnQuickRepair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnQuickRepair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnQuickRepair.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F);
            this.btnQuickRepair.ForeColor = System.Drawing.Color.Black;
            this.btnQuickRepair.Location = new System.Drawing.Point(512, 427);
            this.btnQuickRepair.Name = "btnQuickRepair";
            this.btnQuickRepair.Size = new System.Drawing.Size(138, 27);
            this.btnQuickRepair.TabIndex = 337;
            this.btnQuickRepair.Text = "🪟 Quick Repair";
            this.btnQuickRepair.UseVisualStyleBackColor = false;
            // 
            // btnCreateUsb
            // 
            this.btnCreateUsb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateUsb.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateUsb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.btnCreateUsb.FlatAppearance.BorderSize = 2;
            this.btnCreateUsb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnCreateUsb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCreateUsb.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F);
            this.btnCreateUsb.ForeColor = System.Drawing.Color.Black;
            this.btnCreateUsb.Location = new System.Drawing.Point(656, 427);
            this.btnCreateUsb.Name = "btnCreateUsb";
            this.btnCreateUsb.Size = new System.Drawing.Size(138, 27);
            this.btnCreateUsb.TabIndex = 338;
            this.btnCreateUsb.Text = " 💿 Create Install USB";
            this.btnCreateUsb.UseVisualStyleBackColor = false;
            // 
            // lblOneClick
            // 
            this.lblOneClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOneClick.AutoEllipsis = true;
            this.lblOneClick.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.lblOneClick.ForeColor = System.Drawing.Color.Black;
            this.lblOneClick.Location = new System.Drawing.Point(418, 430);
            this.lblOneClick.Name = "lblOneClick";
            this.lblOneClick.Size = new System.Drawing.Size(89, 27);
            this.lblOneClick.TabIndex = 336;
            this.lblOneClick.Text = "One-click:";
            this.lblOneClick.UseCompatibleTextRendering = true;
            // 
            // panelInstall
            // 
            this.panelInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInstall.AutoScroll = true;
            this.panelInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.panelInstall.Controls.Add(this.lblBadgeDl);
            this.panelInstall.Controls.Add(this.lblBadgeIso);
            this.panelInstall.Controls.Add(this.cboSource);
            this.panelInstall.Controls.Add(this.btnHomepage);
            this.panelInstall.Controls.Add(this.lblBadgeExternal);
            this.panelInstall.Controls.Add(this.btnDownload);
            this.panelInstall.Controls.Add(this.btnRun);
            this.panelInstall.Controls.Add(this.lblBadgeNative);
            this.panelInstall.Location = new System.Drawing.Point(42, 169);
            this.panelInstall.Name = "panelInstall";
            this.panelInstall.Size = new System.Drawing.Size(752, 214);
            this.panelInstall.TabIndex = 335;
            // 
            // lblBadgeDl
            // 
            this.lblBadgeDl.AutoEllipsis = true;
            this.lblBadgeDl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.lblBadgeDl.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.25F);
            this.lblBadgeDl.ForeColor = System.Drawing.Color.Black;
            this.lblBadgeDl.Location = new System.Drawing.Point(306, 13);
            this.lblBadgeDl.Name = "lblBadgeDl";
            this.lblBadgeDl.Size = new System.Drawing.Size(130, 26);
            this.lblBadgeDl.TabIndex = 338;
            this.lblBadgeDl.Text = "⬇️ Direct download";
            this.lblBadgeDl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBadgeIso
            // 
            this.lblBadgeIso.AutoEllipsis = true;
            this.lblBadgeIso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.lblBadgeIso.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.25F);
            this.lblBadgeIso.ForeColor = System.Drawing.Color.Black;
            this.lblBadgeIso.Location = new System.Drawing.Point(194, 13);
            this.lblBadgeIso.Name = "lblBadgeIso";
            this.lblBadgeIso.Size = new System.Drawing.Size(106, 26);
            this.lblBadgeIso.TabIndex = 337;
            this.lblBadgeIso.Text = "💿 Needs ISO";
            this.lblBadgeIso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSource
            // 
            this.cboSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboSource.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 11.25F);
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(11, 61);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(733, 28);
            this.cboSource.TabIndex = 334;
            // 
            // btnHomepage
            // 
            this.btnHomepage.BackColor = System.Drawing.Color.Transparent;
            this.btnHomepage.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnHomepage.FlatAppearance.BorderSize = 2;
            this.btnHomepage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnHomepage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnHomepage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHomepage.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 10.25F);
            this.btnHomepage.ForeColor = System.Drawing.Color.Black;
            this.btnHomepage.Location = new System.Drawing.Point(111, 95);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(94, 31);
            this.btnHomepage.TabIndex = 6;
            this.btnHomepage.Text = "Web";
            this.btnHomepage.UseCompatibleTextRendering = true;
            this.btnHomepage.UseVisualStyleBackColor = false;
            // 
            // lblBadgeExternal
            // 
            this.lblBadgeExternal.AutoEllipsis = true;
            this.lblBadgeExternal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.lblBadgeExternal.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.25F);
            this.lblBadgeExternal.ForeColor = System.Drawing.Color.Black;
            this.lblBadgeExternal.Location = new System.Drawing.Point(97, 13);
            this.lblBadgeExternal.Name = "lblBadgeExternal";
            this.lblBadgeExternal.Size = new System.Drawing.Size(91, 26);
            this.lblBadgeExternal.TabIndex = 336;
            this.lblBadgeExternal.Text = "🧰 External";
            this.lblBadgeExternal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.Transparent;
            this.btnDownload.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDownload.FlatAppearance.BorderSize = 2;
            this.btnDownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 10.25F);
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.Location = new System.Drawing.Point(11, 95);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 31);
            this.btnDownload.TabIndex = 11;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseCompatibleTextRendering = true;
            this.btnDownload.UseVisualStyleBackColor = false;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnRun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnRun.FlatAppearance.BorderSize = 2;
            this.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.Black;
            this.btnRun.Location = new System.Drawing.Point(582, 95);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(162, 31);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "Run";
            this.btnRun.UseCompatibleTextRendering = true;
            this.btnRun.UseVisualStyleBackColor = false;
            // 
            // lblBadgeNative
            // 
            this.lblBadgeNative.AutoEllipsis = true;
            this.lblBadgeNative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.lblBadgeNative.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.25F);
            this.lblBadgeNative.ForeColor = System.Drawing.Color.Black;
            this.lblBadgeNative.Location = new System.Drawing.Point(10, 13);
            this.lblBadgeNative.Name = "lblBadgeNative";
            this.lblBadgeNative.Size = new System.Drawing.Size(81, 26);
            this.lblBadgeNative.TabIndex = 335;
            this.lblBadgeNative.Text = "🪟 Native";
            this.lblBadgeNative.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHint
            // 
            this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHint.AutoEllipsis = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.lblHint.ForeColor = System.Drawing.Color.Black;
            this.lblHint.Location = new System.Drawing.Point(42, 66);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(744, 87);
            this.lblHint.TabIndex = 9;
            this.lblHint.Text = "Info";
            this.lblHint.UseCompatibleTextRendering = true;
            // 
            // InstallControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.panel1);
            this.Name = "InstallControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelInstall.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Panel panelInstall;
        private System.Windows.Forms.Label lblBadgeNative;
        private System.Windows.Forms.Label lblBadgeDl;
        private System.Windows.Forms.Label lblBadgeIso;
        private System.Windows.Forms.Label lblBadgeExternal;
        private System.Windows.Forms.TextBox textProviderSearch;
        private System.Windows.Forms.Button btnQuickRepair;
        private System.Windows.Forms.Button btnCreateUsb;
        private System.Windows.Forms.Label lblOneClick;
    }
}
