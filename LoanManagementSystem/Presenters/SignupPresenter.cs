using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Presenters
{
    public class SignupPresenter
    {
        private readonly ISignupView _view;
        private readonly IAuthService _authService;

        public SignupPresenter(ISignupView view, IAuthService authService)
        {
            _view = view;
            _authService = authService;
            _view.RegisterAttempted += OnRegisterAttempted;
        }

        private void OnRegisterAttempted(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.Username) ||
                string.IsNullOrWhiteSpace(_view.Password) ||
                string.IsNullOrWhiteSpace(_view.FullName))
            {
                _view.ShowError("All fields are required.");
                return;
            }

            bool success = _authService.RegisterStaff(_view.Username, _view.Password, _view.FullName);

            if (success)
            {
                _view.ShowSuccess("Staff registered successfully!");
                _view.CloseForm();
            }
            else
            {
                _view.ShowError("Username already exists.");
            }
        }
    }
}