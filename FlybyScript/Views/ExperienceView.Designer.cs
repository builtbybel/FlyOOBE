namespace Views
{
    partial class ExperienceView
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
            this.btnBack = new System.Windows.Forms.Button();
            this.featurePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRevert = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.featurePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.DarkGray;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(34, 29);
            this.btnBack.TabIndex = 231;
            this.btnBack.Text = "...";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // featurePanel
            // 
            this.featurePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.featurePanel.AutoScroll = true;
            this.featurePanel.Controls.Add(this.rtbDescription);
            this.featurePanel.Location = new System.Drawing.Point(69, 170);
            this.featurePanel.Name = "featurePanel";
            this.featurePanel.Size = new System.Drawing.Size(852, 365);
            this.featurePanel.TabIndex = 232;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.BackColor = System.Drawing.Color.Silver;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.Location = new System.Drawing.Point(3, 3);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(345, 55);
            this.rtbDescription.TabIndex = 233;
            this.rtbDescription.Text = "";
            this.rtbDescription.Visible = false;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Yu Gothic UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.lblHeader.Location = new System.Drawing.Point(69, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(771, 84);
            this.lblHeader.TabIndex = 234;
            this.lblHeader.Text = "デバイスのプライバシー設定を選択";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(73, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(837, 66);
            this.label1.TabIndex = 235;
            this.label1.Text = "良いニュースです！\r\nこれらのプライバシー設定で、Microsoft 内で共有および表示される内容を制御できます。\r\n\r\n同意するには、「同意して適用」を選択しま" +
    "す。既定の設定を希望する場合は「拒否」を選択します。";
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.AutoEllipsis = true;
            this.btnRevert.BackColor = System.Drawing.Color.White;
            this.btnRevert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevert.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRevert.FlatAppearance.BorderSize = 2;
            this.btnRevert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnRevert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevert.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevert.Location = new System.Drawing.Point(473, 565);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(220, 40);
            this.btnRevert.TabIndex = 238;
            this.btnRevert.TabStop = false;
            this.btnRevert.Text = "拒否";
            this.btnRevert.UseVisualStyleBackColor = false;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.White;
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnApply.FlatAppearance.BorderSize = 2;
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(699, 565);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(222, 40);
            this.btnApply.TabIndex = 237;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "同意して適用";
            this.btnApply.UseCompatibleTextRendering = true;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(84, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 17);
            this.label2.TabIndex = 239;
            this.label2.Text = "最終更新日 2024 年 10 月";
            // 
            // ExperienceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.featurePanel);
            this.Controls.Add(this.btnBack);
            this.Name = "ExperienceView";
            this.Size = new System.Drawing.Size(959, 631);
            this.featurePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FlowLayoutPanel featurePanel;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
    }
}
