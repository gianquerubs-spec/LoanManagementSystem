using LoanManagementSystem.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }

        event EventHandler LoginAttempted;
        event EventHandler SignupRequested;

        void ShowError(string message);
        void ShowSuccess(string message);
        void NavigateToMainForm(IAuthService authService);
        void ClearForm();
        void HideForm();
    }
}