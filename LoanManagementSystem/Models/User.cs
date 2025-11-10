using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
            Role = "Staff";
        }

        public bool IsAdmin()
        {
            return Role == "Admin";
        }
    }
}