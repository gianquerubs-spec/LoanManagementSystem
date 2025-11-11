using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface IMainView
    {
        User CurrentUser { get; set; }

        event EventHandler DashboardClicked;
        event EventHandler ClientsClicked;
        event EventHandler LoansClicked;
        event EventHandler UsersClicked;
        event EventHandler ProfileClicked;
        event EventHandler LogoutClicked;

        void ShowDashboard();
        void ShowClientManagement();
        void ShowLoanProcessing();
        void ShowUserManagement();
        void ShowProfile();
        void NavigateToLogin();
        void HighlightNavigation(string section);
        void DisableUserManagement();
    }
}