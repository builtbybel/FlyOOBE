namespace Flyoobe
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.panelControls = new System.Windows.Forms.Panel();
            this.border = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.richTextBoxLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLogs.Font = new System.Drawing.Font("Cascadia Code", 8.75F);
            this.richTextBoxLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(89)))), ((int)(((byte)(63)))));
            this.richTextBoxLogs.Location = new System.Drawing.Point(14, 52);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.Size = new System.Drawing.Size(428, 465);
            this.richTextBoxLogs.TabIndex = 0;
            this.richTextBoxLogs.TabStop = false;
            this.richTextBoxLogs.Text = "";
            this.richTextBoxLogs.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxLogs_LinkClicked);
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelControls.Controls.Add(this.border);
            this.panelControls.Controls.Add(this.lblHeader);
            this.panelControls.Controls.Add(this.richTextBoxLogs);
            this.panelControls.Location = new System.Drawing.Point(10, 7);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(455, 530);
            this.panelControls.TabIndex = 1;
            // 
            // border
            // 
            this.border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(79)))), ((int)(((byte)(203)))));
            this.border.ForeColor = System.Drawing.Color.Transparent;
            this.border.Location = new System.Drawing.Point(0, 40);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(453, 1);
            this.border.TabIndex = 259;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(23, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(420, 24);
            this.lblHeader.TabIndex = 258;
            this.lblHeader.Text = "Activity";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(473, 546);
            this.Controls.Add(this.panelControls);
            this.Name = "LogForm";
            this.Opacity = 0.96D;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OOBEE • Console";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LogForm_Paint);
            this.panelControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label border;
        private System.Windows.Forms.Label lblHeader;
    }
}