namespace Flyoobe.ToolHub
{
    partial class ToolHubControlView
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
            this.flowLayoutPanelTools = new System.Windows.Forms.FlowLayoutPanel();
            this.contextDropDown = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuInstallUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuInstallLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuWriteExtension = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuExtensionDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.contextDropDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelTools
            // 
            this.flowLayoutPanelTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelTools.AutoScroll = true;
            this.flowLayoutPanelTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.flowLayoutPanelTools.Location = new System.Drawing.Point(28, 94);
            this.flowLayoutPanelTools.Name = "flowLayoutPanelTools";
            this.flowLayoutPanelTools.Size = new System.Drawing.Size(804, 343);
            this.flowLayoutPanelTools.TabIndex = 0;
            // 
            // contextDropDown
            // 
            this.contextDropDown.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextDropDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuInstallUrl,
            this.toolStripMenuInstallLocal,
            this.toolStripMenuWriteExtension,
            this.toolStripMenuExtensionDirectory});
            this.contextDropDown.Name = "contextMenuStripAdd";
            this.contextDropDown.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextDropDown.Size = new System.Drawing.Size(172, 112);
            // 
            // toolStripMenuInstallUrl
            // 
            this.toolStripMenuInstallUrl.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuInstallUrl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripMenuInstallUrl.Name = "toolStripMenuInstallUrl";
            this.toolStripMenuInstallUrl.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuInstallUrl.Text = "Install from Url...";
            this.toolStripMenuInstallUrl.Click += new System.EventHandler(this.toolStripMenuInstallUrl_Click);
            // 
            // toolStripMenuInstallLocal
            // 
            this.toolStripMenuInstallLocal.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuInstallLocal.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripMenuInstallLocal.Name = "toolStripMenuInstallLocal";
            this.toolStripMenuInstallLocal.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuInstallLocal.Text = "Install from file...";
            this.toolStripMenuInstallLocal.Click += new System.EventHandler(this.toolStripMenuInstallLocal_Click);
            // 
            // toolStripMenuWriteExtension
            // 
            this.toolStripMenuWriteExtension.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuWriteExtension.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripMenuWriteExtension.Name = "toolStripMenuWriteExtension";
            this.toolStripMenuWriteExtension.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuWriteExtension.Text = "Write an extension";
            this.toolStripMenuWriteExtension.Click += new System.EventHandler(this.toolStripMenuWriteExtension_Click);
            // 
            // toolStripMenuExtensionDirectory
            // 
            this.toolStripMenuExtensionDirectory.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuExtensionDirectory.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripMenuExtensionDirectory.Name = "toolStripMenuExtensionDirectory";
            this.toolStripMenuExtensionDirectory.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuExtensionDirectory.Text = "Extension folder...";
            this.toolStripMenuExtensionDirectory.Click += new System.EventHandler(this.toolStripMenuExtensionDirectory_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.AutoEllipsis = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(83)))), ((int)(((byte)(167)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(83)))), ((int)(((byte)(167)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(342, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 32);
            this.btnAdd.TabIndex = 350;
            this.btnAdd.Text = "Browse for Extensions";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 57);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(829, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Loading...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.UseCompatibleTextRendering = true;
            this.lblStatus.Visible = false;
            // 
            // comboFilter
            // 
            this.comboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboFilter.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10F);
            this.comboFilter.ForeColor = System.Drawing.Color.Black;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(730, 63);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(71, 25);
            this.comboFilter.TabIndex = 351;
            this.comboFilter.TabStop = false;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // ToolHubControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.comboFilter);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.flowLayoutPanelTools);
            this.Name = "ToolHubControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.contextDropDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTools;
        private System.Windows.Forms.ContextMenuStrip contextDropDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuInstallUrl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuInstallLocal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuWriteExtension;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExtensionDirectory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox comboFilter;
    }
}
