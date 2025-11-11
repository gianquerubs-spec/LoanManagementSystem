using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface IUserManagementView
    {
        // Events
        event EventHandler LoadUsers;
        event EventHandler AddUserClicked;
        event EventHandler EditUserClicked;
        event EventHandler DeleteUserClicked;
        event EventHandler RefreshClicked;

        // Methods
        void DisplayUsers(List<User> users);
        DialogResult ShowUserFormDialog(User user = null);
        void ShowMessage(string message, string caption, bool isError = false);
        bool ConfirmAction(string message, string caption);
        void ShowLoading();
        void HideLoading();
        int GetSelectedUserId();
        void ClearSelection();
        bool CheckAdminAccess();
    }
}