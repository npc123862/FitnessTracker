namespace FitnessTracker
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            // Form
            this.Text = "Fitness Tracker - Login";
            this.Size = new System.Drawing.Size(420, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Shared message label
            lblMessage = new System.Windows.Forms.Label();
            lblMessage.Location = new System.Drawing.Point(20, 430);
            lblMessage.Size = new System.Drawing.Size(370, 60);
            lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblMessage.Font = new System.Drawing.Font("Segoe UI", 9f);

            // App title label
            lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = "🏋️ Fitness Tracker";
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Size = new System.Drawing.Size(370, 40);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // Login panel
            pnlLogin = new System.Windows.Forms.Panel();
            pnlLogin.Location = new System.Drawing.Point(20, 70);
            pnlLogin.Size = new System.Drawing.Size(370, 350);
            pnlLogin.Visible = true;

            // Login heading
            var lblLoginHeading = new System.Windows.Forms.Label();
            lblLoginHeading.Text = "Login to Your Account";
            lblLoginHeading.Location = new System.Drawing.Point(0, 10);
            lblLoginHeading.Size = new System.Drawing.Size(370, 30);
            lblLoginHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblLoginHeading.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            lblLoginHeading.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // Username label
            var lblLoginUsername = new System.Windows.Forms.Label();
            lblLoginUsername.Text = "Username:";
            lblLoginUsername.Location = new System.Drawing.Point(30, 60);
            lblLoginUsername.Size = new System.Drawing.Size(100, 25);
            lblLoginUsername.Font = new System.Drawing.Font("Segoe UI", 9f);

            // Username textbox
            txtLoginUsername = new System.Windows.Forms.TextBox();
            txtLoginUsername.Location = new System.Drawing.Point(30, 85);
            txtLoginUsername.Size = new System.Drawing.Size(310, 25);
            txtLoginUsername.Font = new System.Drawing.Font("Segoe UI", 10f);

            // Password label
            var lblLoginPassword = new System.Windows.Forms.Label();
            lblLoginPassword.Text = "Password:";
            lblLoginPassword.Location = new System.Drawing.Point(30, 125);
            lblLoginPassword.Size = new System.Drawing.Size(100, 25);
            lblLoginPassword.Font = new System.Drawing.Font("Segoe UI", 9f);

            // Password textbox
            txtLoginPassword = new System.Windows.Forms.TextBox();
            txtLoginPassword.Location = new System.Drawing.Point(30, 150);
            txtLoginPassword.Size = new System.Drawing.Size(310, 25);
            txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 10f);
            txtLoginPassword.PasswordChar = '*';

            // Login button
            btnLogin = new System.Windows.Forms.Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new System.Drawing.Point(30, 200);
            btnLogin.Size = new System.Drawing.Size(310, 40);
            btnLogin.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnLogin.BackColor = System.Drawing.Color.DarkSlateBlue;
            btnLogin.ForeColor = System.Drawing.Color.White;
            btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Go to register button
            btnGoToRegister = new System.Windows.Forms.Button();
            btnGoToRegister.Text = "Don't have an account? Register";
            btnGoToRegister.Location = new System.Drawing.Point(30, 260);
            btnGoToRegister.Size = new System.Drawing.Size(310, 35);
            btnGoToRegister.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnGoToRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGoToRegister.Click += new System.EventHandler(this.btnGoToRegister_Click);

            // Add controls to login panel
            pnlLogin.Controls.Add(lblLoginHeading);
            pnlLogin.Controls.Add(lblLoginUsername);
            pnlLogin.Controls.Add(txtLoginUsername);
            pnlLogin.Controls.Add(lblLoginPassword);
            pnlLogin.Controls.Add(txtLoginPassword);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(btnGoToRegister);

            // Register panel
            pnlRegister = new System.Windows.Forms.Panel();
            pnlRegister.Location = new System.Drawing.Point(20, 70);
            pnlRegister.Size = new System.Drawing.Size(370, 350);
            pnlRegister.Visible = false;

            // Register heading
            var lblRegisterHeading = new System.Windows.Forms.Label();
            lblRegisterHeading.Text = "Create an Account";
            lblRegisterHeading.Location = new System.Drawing.Point(0, 10);
            lblRegisterHeading.Size = new System.Drawing.Size(370, 30);
            lblRegisterHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblRegisterHeading.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            lblRegisterHeading.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // Register username label
            var lblRegisterUsername = new System.Windows.Forms.Label();
            lblRegisterUsername.Text = "Username (letters & numbers only):";
            lblRegisterUsername.Location = new System.Drawing.Point(30, 55);
            lblRegisterUsername.Size = new System.Drawing.Size(310, 25);
            lblRegisterUsername.Font = new System.Drawing.Font("Segoe UI", 9f);

            // Register username textbox
            txtRegisterUsername = new System.Windows.Forms.TextBox();
            txtRegisterUsername.Location = new System.Drawing.Point(30, 80);
            txtRegisterUsername.Size = new System.Drawing.Size(310, 25);
            txtRegisterUsername.Font = new System.Drawing.Font("Segoe UI", 10f);
            txtRegisterUsername.TextChanged += new System.EventHandler(this.txtRegisterUsername_TextChanged);

            // Register password label
            var lblRegisterPassword = new System.Windows.Forms.Label();
            lblRegisterPassword.Text = "Password (12 chars, 1 upper & 1 lower):";
            lblRegisterPassword.Location = new System.Drawing.Point(30, 115);
            lblRegisterPassword.Size = new System.Drawing.Size(310, 25);
            lblRegisterPassword.Font = new System.Drawing.Font("Segoe UI", 9f);

            // Register password textbox
            txtRegisterPassword = new System.Windows.Forms.TextBox();
            txtRegisterPassword.Location = new System.Drawing.Point(30, 140);
            txtRegisterPassword.Size = new System.Drawing.Size(310, 25);
            txtRegisterPassword.Font = new System.Drawing.Font("Segoe UI", 10f);
            txtRegisterPassword.PasswordChar = '*';
            txtRegisterPassword.TextChanged += new System.EventHandler(this.txtRegisterPassword_TextChanged);

            // Confirm password label
            var lblConfirmPassword = new System.Windows.Forms.Label();
            lblConfirmPassword.Text = "Confirm Password:";
            lblConfirmPassword.Location = new System.Drawing.Point(30, 175);
            lblConfirmPassword.Size = new System.Drawing.Size(310, 25);
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9f);

            // Confirm password textbox
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            txtConfirmPassword.Location = new System.Drawing.Point(30, 200);
            txtConfirmPassword.Size = new System.Drawing.Size(310, 25);
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10f);
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);

            // Register submit button
            btnRegister = new System.Windows.Forms.Button();
            btnRegister.Text = "Create Account";
            btnRegister.Location = new System.Drawing.Point(30, 245);
            btnRegister.Size = new System.Drawing.Size(310, 40);
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnRegister.BackColor = System.Drawing.Color.DarkSlateBlue;
            btnRegister.ForeColor = System.Drawing.Color.White;
            btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Back to login button
            btnBackToLogin = new System.Windows.Forms.Button();
            btnBackToLogin.Text = "Already have an account? Login";
            btnBackToLogin.Location = new System.Drawing.Point(30, 300);
            btnBackToLogin.Size = new System.Drawing.Size(310, 35);
            btnBackToLogin.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnBackToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);

            // Add controls to register panel
            pnlRegister.Controls.Add(lblRegisterHeading);
            pnlRegister.Controls.Add(lblRegisterUsername);
            pnlRegister.Controls.Add(txtRegisterUsername);
            pnlRegister.Controls.Add(lblRegisterPassword);
            pnlRegister.Controls.Add(txtRegisterPassword);
            pnlRegister.Controls.Add(lblConfirmPassword);
            pnlRegister.Controls.Add(txtConfirmPassword);
            pnlRegister.Controls.Add(btnRegister);
            pnlRegister.Controls.Add(btnBackToLogin);

            // Add all controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(pnlLogin);
            this.Controls.Add(pnlRegister);
            this.Controls.Add(lblMessage);

            // Wire up form load event
            this.Load += new System.EventHandler(this.frmLogin_Load);
        }

        // Control declarations
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlRegister;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGoToRegister;
        private System.Windows.Forms.TextBox txtRegisterUsername;
        private System.Windows.Forms.TextBox txtRegisterPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBackToLogin;
    }
}
