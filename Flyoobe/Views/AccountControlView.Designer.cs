namespace Flyoobe
{
    partial class AccountControlView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateAccountWizard = new System.Windows.Forms.Button();
            this.linkOnlineAccount = new System.Windows.Forms.LinkLabel();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(219)))), ((int)(((byte)(229)))));
            this.panel1.Controls.Add(this.btnCreateAccountWizard);
            this.panel1.Controls.Add(this.linkOnlineAccount);
            this.panel1.Controls.Add(this.btnCreateAccount);
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.textUsername);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(43, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 404);
            this.panel1.TabIndex = 10;
            // 
            // btnCreateAccountWizard
            // 
            this.btnCreateAccountWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAccountWizard.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateAccountWizard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(83)))), ((int)(((byte)(167)))));
            this.btnCreateAccountWizard.FlatAppearance.BorderSize = 2;
            this.btnCreateAccountWizard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnCreateAccountWizard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnCreateAccountWizard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccountWizard.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnCreateAccountWizard.ForeColor = System.Drawing.Color.Black;
            this.btnCreateAccountWizard.Location = new System.Drawing.Point(356, 354);
            this.btnCreateAccountWizard.Name = "btnCreateAccountWizard";
            this.btnCreateAccountWizard.Size = new System.Drawing.Size(227, 31);
            this.btnCreateAccountWizard.TabIndex = 8;
            this.btnCreateAccountWizard.Text = "Windows Local Account Wizard";
            this.btnCreateAccountWizard.UseCompatibleTextRendering = true;
            this.btnCreateAccountWizard.UseVisualStyleBackColor = false;
            this.btnCreateAccountWizard.Click += new System.EventHandler(this.btnCreateAccountWizard_Click);
            // 
            // linkOnlineAccount
            // 
            this.linkOnlineAccount.ActiveLinkColor = System.Drawing.Color.Fuchsia;
            this.linkOnlineAccount.AutoSize = true;
            this.linkOnlineAccount.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.linkOnlineAccount.LinkColor = System.Drawing.Color.Black;
            this.linkOnlineAccount.Location = new System.Drawing.Point(148, 23);
            this.linkOnlineAccount.Name = "linkOnlineAccount";
            this.linkOnlineAccount.Size = new System.Drawing.Size(146, 27);
            this.linkOnlineAccount.TabIndex = 7;
            this.linkOnlineAccount.TabStop = true;
            this.linkOnlineAccount.Text = "Microsoft Account";
            this.linkOnlineAccount.UseCompatibleTextRendering = true;
            this.linkOnlineAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOnlineAccount_LinkClicked);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(194)))));
            this.btnCreateAccount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(83)))), ((int)(((byte)(167)))));
            this.btnCreateAccount.FlatAppearance.BorderSize = 2;
            this.btnCreateAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnCreateAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnCreateAccount.ForeColor = System.Drawing.Color.White;
            this.btnCreateAccount.Location = new System.Drawing.Point(602, 354);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(130, 31);
            this.btnCreateAccount.TabIndex = 6;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseCompatibleTextRendering = true;
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // textPassword
            // 
            this.textPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPassword.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.textPassword.Location = new System.Drawing.Point(19, 164);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(713, 25);
            this.textPassword.TabIndex = 4;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // textUsername
            // 
            this.textUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUsername.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.textUsername.Location = new System.Drawing.Point(19, 97);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(713, 25);
            this.textUsername.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display Semil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display Semil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Account";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // AccountControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.panel1);
            this.Name = "AccountControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.LinkLabel linkOnlineAccount;
        private System.Windows.Forms.Button btnCreateAccountWizard;
    }
}
