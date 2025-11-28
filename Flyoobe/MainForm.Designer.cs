namespace Flyoobe
{
    partial class MainForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelHost = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnActivity = new System.Windows.Forms.Button();
            this.panelForm = new System.Windows.Forms.Panel();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.btnSettings = new NavButton();
            this.btnExtensions = new NavButton();
            this.btnOobe = new NavButton();
            this.btnHome = new NavButton();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 13.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblHeader.Location = new System.Drawing.Point(37, 52);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(214, 23);
            this.lblHeader.TabIndex = 512;
            this.lblHeader.Text = "Home";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // panelHost
            // 
            this.panelHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHost.AutoScroll = true;
            this.panelHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelHost.Location = new System.Drawing.Point(17, 92);
            this.panelHost.Name = "panelHost";
            this.panelHost.Size = new System.Drawing.Size(811, 436);
            this.panelHost.TabIndex = 333;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.25F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.Location = new System.Drawing.Point(738, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 27);
            this.btnRefresh.TabIndex = 332;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "...";
            this.toolTip.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F);
            this.btnBack.Location = new System.Drawing.Point(17, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(30, 27);
            this.btnBack.TabIndex = 511;
            this.btnBack.Text = "...";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // btnActivity
            // 
            this.btnActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivity.AutoSize = true;
            this.btnActivity.BackColor = System.Drawing.Color.Transparent;
            this.btnActivity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivity.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnActivity.FlatAppearance.BorderSize = 0;
            this.btnActivity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnActivity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivity.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F);
            this.btnActivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnActivity.Location = new System.Drawing.Point(784, 14);
            this.btnActivity.Name = "btnActivity";
            this.btnActivity.Size = new System.Drawing.Size(30, 27);
            this.btnActivity.TabIndex = 522;
            this.btnActivity.TabStop = false;
            this.btnActivity.Text = "...";
            this.toolTip.SetToolTip(this.btnActivity, "Activity");
            this.btnActivity.UseVisualStyleBackColor = false;
            this.btnActivity.Click += new System.EventHandler(this.btnActivity_Click);
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.panelForm.Controls.Add(this.lblHeader);
            this.panelForm.Controls.Add(this.panelHost);
            this.panelForm.Controls.Add(this.btnActivity);
            this.panelForm.Controls.Add(this.textSearch);
            this.panelForm.Controls.Add(this.btnBack);
            this.panelForm.Controls.Add(this.btnRefresh);
            this.panelForm.Location = new System.Drawing.Point(84, 5);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(841, 550);
            this.panelForm.TabIndex = 513;
            // 
            // textSearch
            // 
            this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSearch.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textSearch.Location = new System.Drawing.Point(267, 46);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(280, 29);
            this.textSearch.TabIndex = 517;
            this.textSearch.Text = "Search";
            this.textSearch.Click += new System.EventHandler(this.textSearch_Click);
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnSettings.IconGlyph = "";
            this.btnSettings.LabelText = "Settings";
            this.btnSettings.Location = new System.Drawing.Point(8, 492);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 61);
            this.btnSettings.TabIndex = 529;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnExtensions
            // 
            this.btnExtensions.BackColor = System.Drawing.Color.Transparent;
            this.btnExtensions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExtensions.FlatAppearance.BorderSize = 0;
            this.btnExtensions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExtensions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtensions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExtensions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnExtensions.IconGlyph = "";
            this.btnExtensions.LabelText = "Extensions";
            this.btnExtensions.Location = new System.Drawing.Point(8, 146);
            this.btnExtensions.Name = "btnExtensions";
            this.btnExtensions.Size = new System.Drawing.Size(70, 61);
            this.btnExtensions.TabIndex = 528;
            this.btnExtensions.UseVisualStyleBackColor = false;
            // 
            // btnOobe
            // 
            this.btnOobe.BackColor = System.Drawing.Color.Transparent;
            this.btnOobe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOobe.FlatAppearance.BorderSize = 0;
            this.btnOobe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOobe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOobe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOobe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOobe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnOobe.IconGlyph = "";
            this.btnOobe.LabelText = "OOBE";
            this.btnOobe.Location = new System.Drawing.Point(8, 79);
            this.btnOobe.Name = "btnOobe";
            this.btnOobe.Size = new System.Drawing.Size(70, 61);
            this.btnOobe.TabIndex = 527;
            this.btnOobe.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnHome.IconGlyph = "";
            this.btnHome.LabelText = "Home";
            this.btnHome.Location = new System.Drawing.Point(8, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(70, 61);
            this.btnHome.TabIndex = 526;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(934, 565);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnExtensions);
            this.Controls.Add(this.btnOobe);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.panelForm);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelHost;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button btnActivity;
        private NavButton btnHome;
        private NavButton btnOobe;
        private NavButton btnExtensions;
        private NavButton btnSettings;
    }
}

