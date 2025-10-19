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
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnMore = new System.Windows.Forms.Button();
            this.panelHost = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureApp = new System.Windows.Forms.PictureBox();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.manageExtensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installFromUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeAnExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navTree = new System.Windows.Forms.TreeView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureApp)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.AutoScroll = true;
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.panelControls.Controls.Add(this.btnMore);
            this.panelControls.Controls.Add(this.panelHost);
            this.panelControls.Controls.Add(this.btnRefresh);
            this.panelControls.Controls.Add(this.btnSettings);
            this.panelControls.Location = new System.Drawing.Point(97, 29);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(502, 511);
            this.panelControls.TabIndex = 3;
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMore.AutoSize = true;
            this.btnMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnMore.FlatAppearance.BorderSize = 0;
            this.btnMore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMore.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.5F);
            this.btnMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMore.Location = new System.Drawing.Point(470, 3);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(29, 25);
            this.btnMore.TabIndex = 344;
            this.btnMore.Text = "...";
            this.btnMore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnMore, "See Flyoobe working live");
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // panelHost
            // 
            this.panelHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelHost.Location = new System.Drawing.Point(3, 31);
            this.panelHost.Name = "panelHost";
            this.panelHost.Size = new System.Drawing.Size(496, 459);
            this.panelHost.TabIndex = 333;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(13, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 25);
            this.btnRefresh.TabIndex = 332;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "...";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.5F);
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(435, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(29, 25);
            this.btnSettings.TabIndex = 345;
            this.btnSettings.Text = "...";
            this.toolTip.SetToolTip(this.btnSettings, "App-Settings");
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe MDL2 Assets", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToggle.Location = new System.Drawing.Point(3, 3);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(40, 39);
            this.btnToggle.TabIndex = 341;
            this.btnToggle.Text = "...";
            this.toolTip.SetToolTip(this.btnToggle, "Toggle sidebar");
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.splitContainer.Location = new System.Drawing.Point(10, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.splitContainer.Panel1.Controls.Add(this.pictureApp);
            this.splitContainer.Panel1.Controls.Add(this.toolStripMenu);
            this.splitContainer.Panel1.Controls.Add(this.navTree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.splitContainer.Panel2.Controls.Add(this.panelControls);
            this.splitContainer.Panel2.Controls.Add(this.btnToggle);
            this.splitContainer.Size = new System.Drawing.Size(925, 552);
            this.splitContainer.SplitterDistance = 223;
            this.splitContainer.TabIndex = 344;
            // 
            // pictureApp
            // 
            this.pictureApp.Location = new System.Drawing.Point(5, 5);
            this.pictureApp.Name = "pictureApp";
            this.pictureApp.Size = new System.Drawing.Size(28, 28);
            this.pictureApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureApp.TabIndex = 348;
            this.pictureApp.TabStop = false;
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripMenu.AutoSize = false;
            this.toolStripMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.toolStripMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNext,
            this.toolStripSeparator2,
            this.toolStripDropDownButton});
            this.toolStripMenu.Location = new System.Drawing.Point(34, 1);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMenu.Size = new System.Drawing.Size(185, 35);
            this.toolStripMenu.TabIndex = 347;
            this.toolStripMenu.Text = "Winpilot";
            // 
            // toolStripButtonNext
            // 
            this.toolStripButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNext.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.75F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonNext.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNext.Name = "toolStripButtonNext";
            this.toolStripButtonNext.Size = new System.Drawing.Size(47, 32);
            this.toolStripButtonNext.Text = "Next";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripDropDownButton
            // 
            this.toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageExtensionsToolStripMenuItem,
            this.installFromUrlToolStripMenuItem,
            this.installFromFileToolStripMenuItem,
            this.writeAnExtensionToolStripMenuItem,
            this.extensionFolderToolStripMenuItem});
            this.toolStripDropDownButton.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton.Name = "toolStripDropDownButton";
            this.toolStripDropDownButton.Size = new System.Drawing.Size(42, 32);
            this.toolStripDropDownButton.Text = "Add";
            // 
            // manageExtensionsToolStripMenuItem
            // 
            this.manageExtensionsToolStripMenuItem.Name = "manageExtensionsToolStripMenuItem";
            this.manageExtensionsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.manageExtensionsToolStripMenuItem.Text = "Manage Extensions";
            this.manageExtensionsToolStripMenuItem.Click += new System.EventHandler(this.manageExtensionsToolStripMenuItem_Click);
            // 
            // installFromUrlToolStripMenuItem
            // 
            this.installFromUrlToolStripMenuItem.Name = "installFromUrlToolStripMenuItem";
            this.installFromUrlToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.installFromUrlToolStripMenuItem.Text = "Install from Url...";
            this.installFromUrlToolStripMenuItem.Click += new System.EventHandler(this.installFromUrlToolStripMenuItem_Click);
            // 
            // installFromFileToolStripMenuItem
            // 
            this.installFromFileToolStripMenuItem.Name = "installFromFileToolStripMenuItem";
            this.installFromFileToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.installFromFileToolStripMenuItem.Text = "Install from file...";
            this.installFromFileToolStripMenuItem.Click += new System.EventHandler(this.installFromFileToolStripMenuItem_Click);
            // 
            // writeAnExtensionToolStripMenuItem
            // 
            this.writeAnExtensionToolStripMenuItem.Name = "writeAnExtensionToolStripMenuItem";
            this.writeAnExtensionToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.writeAnExtensionToolStripMenuItem.Text = "Write an extension";
            this.writeAnExtensionToolStripMenuItem.Click += new System.EventHandler(this.writeAnExtensionToolStripMenuItem_Click);
            // 
            // extensionFolderToolStripMenuItem
            // 
            this.extensionFolderToolStripMenuItem.Name = "extensionFolderToolStripMenuItem";
            this.extensionFolderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.extensionFolderToolStripMenuItem.Text = "Extension folder...";
            this.extensionFolderToolStripMenuItem.Click += new System.EventHandler(this.extensionFolderToolStripMenuItem_Click);
            // 
            // navTree
            // 
            this.navTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.navTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.navTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navTree.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.5F);
            this.navTree.HotTracking = true;
            this.navTree.LineColor = System.Drawing.Color.HotPink;
            this.navTree.Location = new System.Drawing.Point(13, 49);
            this.navTree.Name = "navTree";
            this.navTree.ShowLines = false;
            this.navTree.ShowNodeToolTips = true;
            this.navTree.ShowRootLines = false;
            this.navTree.Size = new System.Drawing.Size(200, 498);
            this.navTree.TabIndex = 0;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(945, 565);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlyOOBE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureApp)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelHost;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView navTree;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem manageExtensionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installFromUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeAnExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extensionFolderToolStripMenuItem;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureApp;
    }
}

