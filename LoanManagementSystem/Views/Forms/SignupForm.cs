using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Services;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    public partial class SignupForm : Form, ISignupView
    {
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;
        public string FullName => txtFullName.Text;

        public event EventHandler RegisterAttempted;

        public SignupForm()
        {
            InitializeComponent();
            btnRegister.Click += (s, e) => RegisterAttempted?.Invoke(this, EventArgs.Empty);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseForm()
        {
            this.Close();
        }
    }
}