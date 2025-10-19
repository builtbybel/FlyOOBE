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
            this.textSearch = new System.Windows.Forms.TextBox();
            this.contextDropDown = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripAddExtensionUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddExtensionLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExtensionGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExtensionSource = new System.Windows.Forms.ToolStripMenuItem();
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
            this.flowLayoutPanelTools.Location = new System.Drawing.Point(28, 64);
            this.flowLayoutPanelTools.Name = "flowLayoutPanelTools";
            this.flowLayoutPanelTools.Size = new System.Drawing.Size(804, 377);
            this.flowLayoutPanelTools.TabIndex = 0;
            // 
            // textSearch
            // 
            this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSearch.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F);
            this.textSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textSearch.Location = new System.Drawing.Point(197, 3);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(473, 25);
            this.textSearch.TabIndex = 10;
            this.textSearch.Text = "Search";
            this.textSearch.Click += new System.EventHandler(this.textSearch_Click);
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // contextDropDown
            // 
            this.contextDropDown.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextDropDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddExtensionUrl,
            this.toolStripAddExtensionLocal,
            this.toolStripExtensionGuide,
            this.toolStripExtensionSource});
            this.contextDropDown.Name = "contextDropDown";
            this.contextDropDown.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextDropDown.Size = new System.Drawing.Size(173, 92);
            // 
            // toolStripAddExtensionUrl
            // 
            this.toolStripAddExtensionUrl.Name = "toolStripAddExtensionUrl";
            this.toolStripAddExtensionUrl.Size = new System.Drawing.Size(172, 22);
            this.toolStripAddExtensionUrl.Text = "Install from Url...";
            // 
            // toolStripAddExtensionLocal
            // 
            this.toolStripAddExtensionLocal.Name = "toolStripAddExtensionLocal";
            this.toolStripAddExtensionLocal.Size = new System.Drawing.Size(172, 22);
            this.toolStripAddExtensionLocal.Text = "Import from file...";
            // 
            // toolStripExtensionGuide
            // 
            this.toolStripExtensionGuide.Name = "toolStripExtensionGuide";
            this.toolStripExtensionGuide.Size = new System.Drawing.Size(172, 22);
            this.toolStripExtensionGuide.Text = "Write an extension";
            // 
            // toolStripExtensionSource
            // 
            this.toolStripExtensionSource.Name = "toolStripExtensionSource";
            this.toolStripExtensionSource.Size = new System.Drawing.Size(172, 22);
            this.toolStripExtensionSource.Text = "Extension folder...";
            // 
            // ToolHubControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.flowLayoutPanelTools);
            this.Name = "ToolHubControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.contextDropDown.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTools;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.ContextMenuStrip contextDropDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddExtensionUrl;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddExtensionLocal;
        private System.Windows.Forms.ToolStripMenuItem toolStripExtensionGuide;
        private System.Windows.Forms.ToolStripMenuItem toolStripExtensionSource;
    }
}
