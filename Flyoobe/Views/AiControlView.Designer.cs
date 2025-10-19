namespace Flyoobe
{
    partial class AiControlView
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.listResults = new System.Windows.Forms.ListView();
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDisable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(835, 31);
            this.lblHeader.TabIndex = 31;
            this.lblHeader.Text = "AI is built into different parts of Windows 11";
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(131)))), ((int)(((byte)(135)))));
            this.lblStatus.Location = new System.Drawing.Point(42, 390);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(767, 20);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.Text = "Ready";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnCheck.FlatAppearance.BorderSize = 2;
            this.btnCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 10.25F);
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(470, 423);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(160, 31);
            this.btnCheck.TabIndex = 25;
            this.btnCheck.TabStop = false;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseCompatibleTextRendering = true;
            this.btnCheck.UseVisualStyleBackColor = false;
            // 
            // listResults
            // 
            this.listResults.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.listResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listResults.CheckBoxes = true;
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item,
            this.Status});
            this.listResults.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.5F);
            this.listResults.FullRowSelect = true;
            this.listResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listResults.HideSelection = false;
            this.listResults.HotTracking = true;
            this.listResults.HoverSelection = true;
            this.listResults.Location = new System.Drawing.Point(46, 119);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(763, 249);
            this.listResults.TabIndex = 32;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            // 
            // Item
            // 
            this.Item.Text = "Feature";
            this.Item.Width = 180;
            // 
            // Status
            // 
            this.Status.Text = "Current status";
            this.Status.Width = 80;
            // 
            // btnDisable
            // 
            this.btnDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(206)))), ((int)(((byte)(249)))));
            this.btnDisable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnDisable.FlatAppearance.BorderSize = 2;
            this.btnDisable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnDisable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnDisable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDisable.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnDisable.ForeColor = System.Drawing.Color.Black;
            this.btnDisable.Location = new System.Drawing.Point(649, 423);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(160, 31);
            this.btnDisable.TabIndex = 33;
            this.btnDisable.Text = "Turn off selected";
            this.btnDisable.UseCompatibleTextRendering = true;
            this.btnDisable.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(42, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(739, 29);
            this.label1.TabIndex = 34;
            this.label1.Text = "Review which AI features are enabled, and choose which ones you want to turn off";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // AiControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.listResults);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCheck);
            this.Name = "AiControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ListView listResults;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Label label1;
    }
}
