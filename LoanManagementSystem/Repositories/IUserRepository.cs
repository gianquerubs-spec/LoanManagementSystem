using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        List<User> GetAllUsers();
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool UserExists(string username);
        bool DeleteUser(int id);
        bool ChangePassword(int userId, string newPassword);
    }
}