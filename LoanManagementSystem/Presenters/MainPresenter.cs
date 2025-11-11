using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IAuthService _authService;

        public MainPresenter(IMainView view, IAuthService authService)
        {
            _view = view;
            _authService = authService;

            _view.CurrentUser = _authService.CurrentUser;

            // Subscribe to events
            _view.DashboardClicked += OnDashboardClicked;
            _view.ClientsClicked += OnClientsClicked;
            _view.LoansClicked += OnLoansClicked;
            _view.UsersClicked += OnUsersClicked;
            _view.ProfileClicked += OnProfileClicked;
            _view.LogoutClicked += OnLogoutClicked;

            // Initial setup
            SetupRoleBasedAccess();
            _view.HighlightNavigation("Dashboard");
            _view.ShowDashboard();
        }

        private void SetupRoleBasedAccess()
        {
            if (_view.CurrentUser?.Role == "Staff")
            {
                _view.DisableUserManagement();
            }
        }

        private void OnDashboardClicked(object sender, EventArgs e)
        {
            _view.ShowDashboard();
            _view.HighlightNavigation("Dashboard");
        }

        private void OnClientsClicked(object sender, EventArgs e)
        {
            _view.ShowClientManagement();
            _view.HighlightNavigation("Clients");
        }

        private void OnLoansClicked(object sender, EventArgs e)
        {
            _view.ShowLoanProcessing();
            _view.HighlightNavigation("Loans");
        }

        private void OnUsersClicked(object sender, EventArgs e)
        {
            _view.ShowUserManagement();
            _view.HighlightNavigation("Users");
        }

        private void OnProfileClicked(object sender, EventArgs e)
        {
            _view.ShowProfile();
            _view.HighlightNavigation("Profile");
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            _authService.Logout();
            _view.NavigateToLogin();
        }
    }
}