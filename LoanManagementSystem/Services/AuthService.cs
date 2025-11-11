using LoanManagementSystem.Interfaces.Services;  
using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;
using System;

namespace LoanManagementSystem.Services
{
    public class AuthService : IAuthService 
    {
        private readonly IUserRepository _userRepository;
        public User CurrentUser { get; private set; }

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && user.Password == password && user.IsActive)
            {
                CurrentUser = user;
                return true;
            }
            return false;
        }

        public bool RegisterStaff(string username, string password, string fullName)
        {
            if (_userRepository.UserExists(username))
                return false;

            var newUser = new User
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Role = "Staff",
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            return _userRepository.AddUser(newUser);
        }

        public bool RegisterAdmin(string username, string password, string fullName)
        {
            if (_userRepository.UserExists(username))
                return false;

            var newUser = new User
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Role = "Admin",
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            return _userRepository.AddUser(newUser);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool ChangePassword(string currentPassword, string newPassword)
        {
            if (CurrentUser != null && CurrentUser.Password == currentPassword)
            {
                return _userRepository.ChangePassword(CurrentUser.ID, newPassword);
            }
            return false;
        }
    }
}