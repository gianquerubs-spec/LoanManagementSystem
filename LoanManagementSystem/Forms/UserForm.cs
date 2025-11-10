using LoanManagementSystem.Models;
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
    public partial class UserForm : Form
    {
        public User User { get; private set; }
        private readonly bool _isEdit;

        public UserForm() : this(null) { }

        public UserForm(User user)
        {
            InitializeComponent();
            if (user == null)
            {
                _isEdit = false;
                User = new User();
                this.Text = "Add User";
                cmbRole.SelectedIndex = 0;
            }
            else
            {
                _isEdit = true;
                User = user;
                this.Text = "Edit User";
                PopulateFields();
            }
        }

        private void PopulateFields()
        {
            txtUsername.Text = User.Username;
            txtUsername.Enabled = false;
            txtFullName.Text = User.FullName;
            cmbRole.Text = User.Role;
            chkActive.Checked = User.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            User.Username = txtUsername.Text.Trim();
            User.FullName = txtFullName.Text.Trim();
            User.Role = cmbRole.Text;
            User.IsActive = chkActive.Checked;

            if (!_isEdit)
            {
                User.Password = "password123";
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}