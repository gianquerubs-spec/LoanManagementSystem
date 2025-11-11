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
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Personal Information
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }

        // Employment & Financial
        public string Occupation { get; set; }
        public string Employer { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string EmploymentStatus { get; set; } // Employed, Self-Employed, Unemployed

        // Identification
        public string GovernmentIdType { get; set; } // SSS, TIN, Driver's License, etc.
        public string GovernmentIdNumber { get; set; }

        // Credit Information
        public decimal CreditScore { get; set; }
        public string CreditRating { get; set; } // Excellent, Good, Fair, Poor

        public Client()
        {
            CreatedAt = DateTime.Now;
            CreditScore = 0;
            MonthlyIncome = 0;
            CreditRating = "Fair";
            EmploymentStatus = "Employed";
        }
    }
}