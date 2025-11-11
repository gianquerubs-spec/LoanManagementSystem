using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Presenters;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    public partial class LoginForm : Form, ILoginView
    {
        // Implement ILoginView properties
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;

        // Implement ILoginView events
        public event EventHandler LoginAttempted;
        public event EventHandler SignupRequested;

        public LoginForm()
        {
            InitializeComponent();

            // Wire up events to interface events
            btnLogin.Click += OnLoginButtonClick;
            btnSignup.Click += OnSignupButtonClick;
            txtPassword.KeyPress += OnPasswordKeyPress;
        }

        private void OnLoginButtonClick(object sender, EventArgs e)
        {
            LoginAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void OnSignupButtonClick(object sender, EventArgs e)
        {
            SignupRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnPasswordKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginAttempted?.Invoke(this, EventArgs.Empty);
            }
        }

        // Implement ILoginView methods
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void NavigateToMainForm(IAuthService authService)
        {
            // Use the correct MainForm constructor with authService parameter
            var mainForm = new MainForm(authService);
            var mainPresenter = new MainPresenter(mainForm, authService);
            this.Hide();
            mainForm.Show();
        }

        public void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        public void HideForm()
        {
            this.Hide();
        }
    }
}