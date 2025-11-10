using LoanManagementSystem.Models;
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
    public partial class UserManagementControl : UserControl
    {
        private UserRepository _userRepository;
        private IAuthService _authService;

        public UserManagementControl(IAuthService authService)
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            _authService = authService;
            SetupDataGridView();
            LoadUsers();
        }

        private void SetupDataGridView()
        {
            dataGridViewUsers.AutoGenerateColumns = false;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersVisible = false;

            dataGridViewUsers.Columns.Clear();
            dataGridViewUsers.Columns.Add("ID", "ID");
            dataGridViewUsers.Columns.Add("Username", "Username");
            dataGridViewUsers.Columns.Add("FullName", "Full Name");
            dataGridViewUsers.Columns.Add("Role", "Role");
            dataGridViewUsers.Columns.Add("IsActive", "Active");
            dataGridViewUsers.Columns.Add("CreatedAt", "Created Date");

            foreach (DataGridViewColumn col in dataGridViewUsers.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadUsers()
        {
            dataGridViewUsers.Rows.Clear();

            var users = _userRepository.GetAllUsers();

            foreach (var user in users)
            {
                dataGridViewUsers.Rows.Add(
                    user.ID,
                    user.Username,
                    user.FullName,
                    user.Role,
                    user.IsActive ? "Yes" : "No",
                    user.CreatedAt.ToString("MMM dd, yyyy")
                );
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!_authService.CurrentUser.IsAdmin())
            {
                MessageBox.Show("Only administrators can add new users.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var userForm = new UserForm())
            {
                if (userForm.ShowDialog() == DialogResult.OK && userForm.User != null)
                {
                    bool success = _userRepository.AddUser(userForm.User);

                    if (success)
                    {
                        LoadUsers();
                        MessageBox.Show("User added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add user. Username might already exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewUsers.SelectedRows[0];
            int userId = (int)selectedRow.Cells["ID"].Value;

            var user = _userRepository.GetUserById(userId);
            if (user != null)
            {
                using (var userForm = new UserForm(user))
                {
                    if (userForm.ShowDialog() == DialogResult.OK && userForm.User != null)
                    {
                        bool success = _userRepository.UpdateUser(userForm.User);

                        if (success)
                        {
                            LoadUsers();
                            MessageBox.Show("User updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update user.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewUsers.SelectedRows[0];
            int userId = (int)selectedRow.Cells["ID"].Value;
            string username = selectedRow.Cells["Username"].Value.ToString();

            if (userId == _authService.CurrentUser.ID)
            {
                MessageBox.Show("You cannot delete your own account.", "Invalid Operation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete user '{username}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = _userRepository.DeleteUser(userId);

                if (success)
                {
                    LoadUsers();
                    MessageBox.Show("User deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete user.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}