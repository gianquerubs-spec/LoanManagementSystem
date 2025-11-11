using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Presenters;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.Utilities;
using LoanManagementSystem.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup dependencies
            var authService = DependencyConfig.CreateAuthService();

            // Start application with login
            StartApplication(authService);
        }

        static void StartApplication(IAuthService authService)
        {
            var loginView = new LoginForm();
            var loginPresenter = new LoginPresenter(loginView, authService);

            Application.Run(loginView);
        }
    }
}