
using LoanManagementSystem.Repositories;
using LoanManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            var userRepository = new UserRepository();
            _authService = new AuthService(userRepository);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin(txtUsername.Text, txtPassword.Text);
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            ShowSignupForm();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                AttemptLogin(txtUsername.Text, txtPassword.Text);
        }

        private void AttemptLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_authService.Login(username, password))
            {
                var mainForm = new MainForm(_authService);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSignupForm()
        {
            var signupForm = new SignupForm(_authService);
            signupForm.ShowDialog();
        }
    }
}