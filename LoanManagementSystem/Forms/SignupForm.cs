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
    public partial class SignupForm : Form
    {
        private readonly IAuthService _authService;

        public SignupForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var fullName = txtFullName.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("All fields are required.", "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var success = _authService.RegisterStaff(username, password, fullName);

            if (success)
            {
                MessageBox.Show("Staff registered successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Username already exists.", "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}