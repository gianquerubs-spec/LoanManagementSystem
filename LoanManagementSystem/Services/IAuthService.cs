using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public interface IAuthService
    {
        User CurrentUser { get; }
        bool Login(string username, string password);
        bool RegisterStaff(string username, string password, string fullName);
        bool RegisterAdmin(string username, string password, string fullName);
        bool ChangePassword(string currentPassword, string newPassword);
        void Logout();
    }
}