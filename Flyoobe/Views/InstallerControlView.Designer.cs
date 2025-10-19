namespace Flyoobe
{
    partial class InstallerControlView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.linkInstallById = new System.Windows.Forms.LinkLabel();
            this.dgvApps = new System.Windows.Forms.DataGridView();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApps)).BeginInit();
            this.SuspendLayout();
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
            this.textSearch.TabIndex = 13;
            this.textSearch.Text = "Search apps";
            this.textSearch.Click += new System.EventHandler(this.textSearch_Click);
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
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
            this.btnInstall.Location = new System.Drawing.Point(658, 388);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(160, 31);
            this.btnInstall.TabIndex = 17;
            this.btnInstall.Text = "Install apps";
            this.btnInstall.UseCompatibleTextRendering = true;
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.AutoEllipsis = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.25F);
            this.lblCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCategory.Location = new System.Drawing.Point(42, 66);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(756, 45);
            this.lblCategory.TabIndex = 20;
            this.lblCategory.Text = "Select the apps you want to install to enhance your productivity and keep your sy" +
    "stem up to date";
            this.lblCategory.UseCompatibleTextRendering = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(131)))), ((int)(((byte)(135)))));
            this.lblStatus.Location = new System.Drawing.Point(0, 427);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(835, 20);
            this.lblStatus.TabIndex = 22;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 447);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(835, 10);
            this.progressBar.TabIndex = 21;
            this.progressBar.Visible = false;
            // 
            // linkInstallById
            // 
            this.linkInstallById.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.linkInstallById.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkInstallById.AutoEllipsis = true;
            this.linkInstallById.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.linkInstallById.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkInstallById.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkInstallById.Location = new System.Drawing.Point(42, 388);
            this.linkInstallById.Name = "linkInstallById";
            this.linkInstallById.Size = new System.Drawing.Size(594, 23);
            this.linkInstallById.TabIndex = 24;
            this.linkInstallById.TabStop = true;
            this.linkInstallById.Text = "+ Install custom Winget package";
            this.linkInstallById.UseCompatibleTextRendering = true;
            this.linkInstallById.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInstallById_LinkClicked);
            // 
            // dgvApps
            // 
            this.dgvApps.AllowUserToAddRows = false;
            this.dgvApps.AllowUserToDeleteRows = false;
            this.dgvApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApps.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvApps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnabledColumn,
            this.NameColumn,
            this.IdColumn,
            this.UpdateColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApps.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvApps.EnableHeadersVisualStyles = false;
            this.dgvApps.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvApps.Location = new System.Drawing.Point(42, 114);
            this.dgvApps.Name = "dgvApps";
            this.dgvApps.RowHeadersVisible = false;
            this.dgvApps.Size = new System.Drawing.Size(776, 267);
            this.dgvApps.TabIndex = 25;
            this.dgvApps.TabStop = false;
            this.dgvApps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApps_CellContentClick);
            // 
            // EnabledColumn
            // 
            this.EnabledColumn.FillWeight = 41.63078F;
            this.EnabledColumn.HeaderText = "";
            this.EnabledColumn.Name = "EnabledColumn";
            this.EnabledColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EnabledColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NameColumn
            // 
            this.NameColumn.FillWeight = 147.3089F;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            // 
            // IdColumn
            // 
            this.IdColumn.FillWeight = 178.7961F;
            this.IdColumn.HeaderText = "Winget ID";
            this.IdColumn.Name = "IdColumn";
            // 
            // UpdateColumn
            // 
            this.UpdateColumn.FillWeight = 72.54963F;
            this.UpdateColumn.HeaderText = "Update";
            this.UpdateColumn.Name = "UpdateColumn";
            this.UpdateColumn.Text = "Update";
            this.UpdateColumn.UseColumnTextForButtonValue = true;
            // 
            // InstallerControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.dgvApps);
            this.Controls.Add(this.linkInstallById);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.textSearch);
            this.Name = "InstallerControlView";
            this.Size = new System.Drawing.Size(835, 457);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.LinkLabel linkInstallById;
        private System.Windows.Forms.DataGridView dgvApps;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewButtonColumn UpdateColumn;
    }
}
