using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using LoanManagementSystem.Views.Forms;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    public partial class UserManagementControl : UserControl, IUserManagementView
    {
        private IAuthService _authService;

        public event EventHandler LoadUsers;
        public event EventHandler AddUserClicked;
        public event EventHandler EditUserClicked;
        public event EventHandler DeleteUserClicked;
        public event EventHandler RefreshClicked;

        public UserManagementControl(IAuthService authService)
        {
            _authService = authService;
            InitializeComponent();
            WireUpEvents();
            SetupDataGridView();
        }

        private void WireUpEvents()
        {
            this.Load += (s, e) => LoadUsers?.Invoke(this, EventArgs.Empty);
            btnAddUser.Click += (s, e) => AddUserClicked?.Invoke(this, EventArgs.Empty);
            btnEditUser.Click += (s, e) => EditUserClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteUser.Click += (s, e) => DeleteUserClicked?.Invoke(this, EventArgs.Empty);
            btnRefresh.Click += (s, e) => RefreshClicked?.Invoke(this, EventArgs.Empty);
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

        // IUserManagementView method implementations
        public void DisplayUsers(List<User> users)
        {
            dataGridViewUsers.Rows.Clear();

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

        public DialogResult ShowUserFormDialog()
        {
            using (var userForm = new UserForm())
            {
                return userForm.ShowDialog();
            }
        }

        public DialogResult ShowUserFormDialog(User user)
        {
            using (var userForm = new UserForm(user))
            {
                return userForm.ShowDialog();
            }
        }

        public void ShowMessage(string message, string caption, bool isError = false)
        {
            MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Error : MessageBoxIcon.Information
            );
        }

        public bool ConfirmAction(string message, string caption)
        {
            var result = MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }

        public void ShowLoading()
        {
            Cursor = Cursors.WaitCursor;
        }

        public void HideLoading()
        {
            Cursor = Cursors.Default;
        }

        public int GetSelectedUserId()
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["ID"].Value);
            }
            return -1;
        }

        public void ClearSelection()
        {
            dataGridViewUsers.ClearSelection();
        }

        public bool CheckAdminAccess()
        {
            return _authService.CurrentUser?.IsAdmin() ?? false;
        }
    }
}