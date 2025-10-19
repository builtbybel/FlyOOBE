namespace Flyoobe
{
    partial class ExperienceControlView
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
            this.comboCategories = new System.Windows.Forms.ComboBox();
            this.listSettings = new System.Windows.Forms.CheckedListBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.textHelp = new System.Windows.Forms.TextBox();
            this.btnMoreInfo = new System.Windows.Forms.Button();
            this.btnToggleAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboCategories
            // 
            this.comboCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(222)))), ((int)(((byte)(218)))));
            this.comboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategories.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11.5F, System.Drawing.FontStyle.Bold);
            this.comboCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboCategories.FormattingEnabled = true;
            this.comboCategories.Location = new System.Drawing.Point(32, 27);
            this.comboCategories.Name = "comboCategories";
            this.comboCategories.Size = new System.Drawing.Size(800, 28);
            this.comboCategories.TabIndex = 0;
            this.comboCategories.SelectedIndexChanged += new System.EventHandler(this.comboCategories_SelectedIndexChanged);
            // 
            // listSettings
            // 
            this.listSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.listSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSettings.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.5F);
            this.listSettings.ForeColor = System.Drawing.Color.Black;
            this.listSettings.FormattingEnabled = true;
            this.listSettings.Location = new System.Drawing.Point(319, 73);
            this.listSettings.Name = "listSettings";
            this.listSettings.Size = new System.Drawing.Size(513, 315);
            this.listSettings.TabIndex = 1;
            this.listSettings.UseCompatibleTextRendering = true;
            this.listSettings.SelectedIndexChanged += new System.EventHandler(this.listTweaks_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.Black;
            this.btnApply.Location = new System.Drawing.Point(663, 410);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(160, 31);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseCompatibleTextRendering = true;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // textHelp
            // 
            this.textHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.textHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textHelp.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.5F);
            this.textHelp.ForeColor = System.Drawing.Color.Black;
            this.textHelp.Location = new System.Drawing.Point(32, 71);
            this.textHelp.Multiline = true;
            this.textHelp.Name = "textHelp";
            this.textHelp.Size = new System.Drawing.Size(277, 317);
            this.textHelp.TabIndex = 11;
            this.textHelp.Text = "Manage your privacy settings and customize your device to fit your preferences. C" +
    "ontrol what data you share and adjust Windows for the best experience.";
            // 
            // btnMoreInfo
            // 
            this.btnMoreInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoreInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
            this.btnMoreInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoreInfo.FlatAppearance.BorderSize = 0;
            this.btnMoreInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMoreInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMoreInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoreInfo.Font = new System.Drawing.Font("Segoe UI Variable Display Semil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoreInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMoreInfo.Location = new System.Drawing.Point(680, 0);
            this.btnMoreInfo.Name = "btnMoreInfo";
            this.btnMoreInfo.Size = new System.Drawing.Size(143, 23);
            this.btnMoreInfo.TabIndex = 14;
            this.btnMoreInfo.Text = "Powered by CrapFixer";
            this.btnMoreInfo.UseVisualStyleBackColor = false;
            this.btnMoreInfo.Click += new System.EventHandler(this.btnMoreInfo_Click);
            // 
            // btnToggleAll
            // 
            this.btnToggleAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleAll.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnToggleAll.FlatAppearance.BorderSize = 2;
            this.btnToggleAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnToggleAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnToggleAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToggleAll.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 10.25F);
            this.btnToggleAll.ForeColor = System.Drawing.Color.Black;
            this.btnToggleAll.Location = new System.Drawing.Point(486, 410);
            this.btnToggleAll.Name = "btnToggleAll";
            this.btnToggleAll.Size = new System.Drawing.Size(160, 31);
            this.btnToggleAll.TabIndex = 15;
            this.btnToggleAll.Text = "Toggle All";
            this.btnToggleAll.UseCompatibleTextRendering = true;
            this.btnToggleAll.UseVisualStyleBackColor = false;
            this.btnToggleAll.Click += new System.EventHandler(this.btnToggleAll_Click);
            // 
            // ExperienceControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.btnToggleAll);
            this.Controls.Add(this.btnMoreInfo);
            this.Controls.Add(this.textHelp);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.listSettings);
            this.Controls.Add(this.comboCategories);
            this.Name = "ExperienceControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCategories;
        private System.Windows.Forms.CheckedListBox listSettings;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox textHelp;
        private System.Windows.Forms.Button btnMoreInfo;
        private System.Windows.Forms.Button btnToggleAll;
    }
}
