using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface ISignupView
    {
        string Username { get; }
        string Password { get; }
        string FullName { get; }

        event EventHandler RegisterAttempted;

        void ShowError(string message);
        void ShowSuccess(string message);
        void CloseForm();
    }
}