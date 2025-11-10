using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public Client()
        {
            CreatedAt = System.DateTime.Now;
        }
    }
}