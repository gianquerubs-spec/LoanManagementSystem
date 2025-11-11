using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoanManagementSystem.Presenters
{
    public class UserManagementPresenter
    {
        private readonly IUserManagementView _view;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserManagementPresenter(IUserManagementView view, IUserService userService, IAuthService authService)
        {
            _view = view;
            _userService = userService;
            _authService = authService;

            // Subscribe to view events
            _view.LoadUsers += OnLoadUsers;
            _view.AddUserClicked += OnAddUserClicked;
            _view.EditUserClicked += OnEditUserClicked;
            _view.DeleteUserClicked += OnDeleteUserClicked;
            _view.RefreshClicked += OnRefreshClicked;
        }

        private void OnLoadUsers(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void OnAddUserClicked(object sender, EventArgs e)
        {
            AddUser();
        }

        private void OnEditUserClicked(object sender, EventArgs e)
        {
            EditUser();
        }

        private void OnDeleteUserClicked(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            _view.ShowLoading();

            var users = _userService.GetAllUsers();

            if (users != null)
            {
                _view.DisplayUsers(users);
            }
            else
            {
                _view.ShowMessage("Unable to load users.", "Error", true);
            }

            _view.HideLoading();
        }

        private void AddUser()
        {
            if (!_view.CheckAdminAccess())
            {
                _view.ShowMessage("Only administrators can add new users.", "Access Denied", false);
                return;
            }

            var result = _view.ShowUserFormDialog();

            if (result == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void EditUser()
        {
            int userId = _view.GetSelectedUserId();

            if (userId <= 0)
            {
                _view.ShowMessage("Please select a user to edit.", "No Selection", false);
                return;
            }

            var user = _userService.GetUserById(userId);
            if (user != null)
            {
                var result = _view.ShowUserFormDialog(user);

                if (result == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
            else
            {
                _view.ShowMessage("User not found.", "Error", true);
            }
        }

        private void DeleteUser()
        {
            int userId = _view.GetSelectedUserId();

            if (userId <= 0)
            {
                _view.ShowMessage("Please select a user to delete.", "No Selection", false);
                return;
            }

            string username = _userService.GetUserById(userId)?.Username ?? "this user";

            // Prevent users from deleting their own account
            if (userId == _authService.CurrentUser.ID)
            {
                _view.ShowMessage("You cannot delete your own account.", "Invalid Operation", false);
                return;
            }

            bool confirm = _view.ConfirmAction(
                $"Are you sure you want to delete user '{username}'?",
                "Confirm Delete"
            );

            if (confirm)
            {
                _view.ShowLoading();

                bool success = _userService.DeleteUser(userId);

                _view.HideLoading();

                if (success)
                {
                    _view.ShowMessage("User deleted successfully!", "Success", false);
                    LoadUsers();
                    _view.ClearSelection();
                }
                else
                {
                    _view.ShowMessage("Failed to delete user.", "Error", true);
                }
            }
        }
    }
}