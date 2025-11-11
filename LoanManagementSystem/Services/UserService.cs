using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;
using System.Collections.Generic;

namespace LoanManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public bool AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public bool UserExists(string username)
        {
            return _userRepository.UserExists(username);
        }

        public bool ChangePassword(int userId, string newPassword)
        {
            return _userRepository.ChangePassword(userId, newPassword);
        }
    }
}