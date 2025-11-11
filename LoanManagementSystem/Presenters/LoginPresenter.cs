using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Services;  
using LoanManagementSystem.Views.Forms;
using LoanManagementSystem.Views.Interfaces;
using System;

namespace LoanManagementSystem.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IAuthService _authService;

        public LoginPresenter(ILoginView view, IAuthService authService)
        {
            _view = view;
            _authService = authService;

            // Subscribe to view events
            _view.LoginAttempted += OnLoginAttempted;
            _view.SignupRequested += OnSignupRequested;
        }

        private void OnLoginAttempted(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.Username) || string.IsNullOrEmpty(_view.Password))
            {
                _view.ShowError("Please enter both username and password.");
                return;
            }

            bool loginSuccessful = _authService.Login(_view.Username, _view.Password);

            if (loginSuccessful)
            {
                _view.ShowSuccess("Login successful!");
                _view.NavigateToMainForm(_authService); // This will use the interface method
            }
            else
            {
                _view.ShowError("Invalid username or password.");
                _view.ClearForm();
            }
        }

        private void OnSignupRequested(object sender, EventArgs e)
        {
            var signupView = new SignupForm();
            var signupPresenter = new SignupPresenter(signupView, _authService);
            signupView.ShowDialog();
        }
    }
}