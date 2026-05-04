using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FitnessTracker
{
    // Login and registration form that users see when they first open the application
    public partial class frmLogin : Form
    {
        private FitnessTrackerManager tracker;

        public frmLogin()
        {
            InitializeComponent();
            tracker = new FitnessTrackerManager();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ShowLoginPanel();
        }

        private void ShowLoginPanel()
        {
            pnlLogin.Visible = true;
            pnlRegister.Visible = false;
            lblMessage.Text = "";
            txtLoginUsername.Clear();
            txtLoginPassword.Clear();
        }

        private void ShowRegisterPanel()
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
            lblMessage.Text = "";
            txtRegisterUsername.Clear();
            txtRegisterPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void txtRegisterUsername_TextChanged(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text;

            if (string.IsNullOrEmpty(username))
            {
                ShowMessage("", Color.Black);
                return;
            }

            if (!User.IsValidUsername(username))
                ShowMessage("Username can only contain letters and numbers.", Color.Red);
            else
                ShowMessage("Username looks good!", Color.Green);
        }

        private void txtRegisterPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtRegisterPassword.Text;

            if (string.IsNullOrEmpty(password))
            {
                ShowMessage("", Color.Black);
                return;
            }

            if (password.Length < 12)
                ShowMessage($"Password too short — {12 - password.Length} character(s) remaining.", Color.Red);
            else if (password.Length > 12)
                ShowMessage("Password too long — must be exactly 12 characters.", Color.Red);
            else if (!User.IsValidPassword(password))
                ShowMessage("Password needs at least 1 uppercase\nand 1 lowercase letter.", Color.Red);
            else
                ShowMessage("Password looks good!", Color.Green);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtRegisterPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(confirmPassword))
            {
                ShowMessage("", Color.Black);
                return;
            }

            if (password != confirmPassword)
                ShowMessage("Passwords do not match.", Color.Red);
            else
                ShowMessage("Passwords match!", Color.Green);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowMessage("Please enter both username and password.", Color.Red);
                return;
            }

            string result = tracker.LoginUser(username, password);

            if (result == "Login successful.")
            {
                ShowMessage(result, Color.Green);

                frmMain mainForm = new frmMain(tracker, this);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                ShowMessage(result, Color.Red);
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            ShowRegisterPanel();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text.Trim();
            string password = txtRegisterPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ShowMessage("Please fill in all fields.", Color.Red);
                return;
            }

            if (password != confirmPassword)
            {
                ShowMessage("Passwords do not match.", Color.Red);
                return;
            }

            string result = tracker.RegisterUser(username, password);

            if (result == "Registration successful. You can now log in.")
            {
                MessageBox.Show("Registration successful!\nYou can now log in.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowLoginPanel();
            }
            else
            {
                ShowMessage(result, Color.Red);
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            ShowLoginPanel();
        }

        private void ShowMessage(string message, Color colour)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = colour;
        }

        public void OnMainFormClosed()
        {
            this.Show();
            ShowLoginPanel();
        }
    }
}
