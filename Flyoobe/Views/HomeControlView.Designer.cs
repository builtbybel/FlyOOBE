namespace Flyoobe.Views
{
    partial class HomeControlView
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
            this.flowRoot = new System.Windows.Forms.FlowLayoutPanel();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // flowRoot
            // 
            this.flowRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowRoot.AutoScroll = true;
            this.flowRoot.Location = new System.Drawing.Point(37, 57);
            this.flowRoot.Name = "flowRoot";
            this.flowRoot.Size = new System.Drawing.Size(841, 340);
            this.flowRoot.TabIndex = 0;
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
            this.comboFilter.Location = new System.Drawing.Point(793, 15);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(71, 25);
            this.comboFilter.TabIndex = 38;
            this.comboFilter.TabStop = false;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // HomeControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.comboFilter);
            this.Controls.Add(this.flowRoot);
            this.Name = "HomeControlView";
            this.Size = new System.Drawing.Size(881, 400);
            this.Load += new System.EventHandler(this.HomeControlView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowRoot;
        private System.Windows.Forms.ComboBox comboFilter;
    }
}
