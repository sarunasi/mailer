namespace Mailer
{
    partial class LogInForm
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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(85, 144);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(205, 20);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.Text = "@gmail.com";
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(85, 196);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(152, 20);
            this.textBoxServer.TabIndex = 1;
            this.textBoxServer.Text = "pop.gmail.com";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(85, 170);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(205, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(148, 222);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(75, 23);
            this.buttonLogIn.TabIndex = 3;
            this.buttonLogIn.Text = "Log in";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(243, 196);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(47, 20);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Text = "995";
            this.textBoxPort.TextChanged += new System.EventHandler(this.textBoxPort_TextChanged);
            // 
            // textBoxError
            // 
            this.textBoxError.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxError.ForeColor = System.Drawing.Color.Red;
            this.textBoxError.Location = new System.Drawing.Point(85, 263);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(205, 20);
            this.textBoxError.TabIndex = 5;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 383);
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.textBoxUsername);
            this.Name = "LogInForm";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.TextBox textBoxError;
	}
}

