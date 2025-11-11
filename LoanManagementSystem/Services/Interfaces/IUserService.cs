using LoanManagementSystem.Models;
using System.Collections.Generic;

namespace LoanManagementSystem.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool UserExists(string username);
        bool ChangePassword(int userId, string newPassword);
    }
}