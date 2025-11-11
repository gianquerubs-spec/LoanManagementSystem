using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string LoanNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Cash, Bank Transfer, etc.
        public string Status { get; set; } // Completed, Pending, Failed
        public string ReceiptNumber { get; set; }
        public int ProcessedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }

        public Payment()
        {
            PaymentDate = DateTime.Now;
            CreatedAt = DateTime.Now;
            Status = "Completed";
            PaymentMethod = "Cash";
        }
    }
}