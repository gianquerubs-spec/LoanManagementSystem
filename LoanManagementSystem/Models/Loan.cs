using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string LoanNumber { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermMonths { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal TotalRepayment { get; set; }
        public string Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? DisbursementDate { get; set; }
        public int ProcessedBy { get; set; }
        public string Notes { get; set; }

        // Payment Tracking Fields
        public int PaymentsMade { get; set; }
        public int PaymentsRemaining { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemainingBalance { get; set; }
        public DateTime? NextPaymentDate { get; set; }

        // Add these formatted properties
        public string FormattedLoanAmount => LoanAmount.ToString("C2").Replace("$", "₱");
        public string FormattedMonthlyPayment => MonthlyPayment.ToString("C2").Replace("$", "₱");
        public string FormattedTotalRepayment => TotalRepayment.ToString("C2").Replace("$", "₱");
        public string FormattedRemainingBalance => RemainingBalance.ToString("C2").Replace("$", "₱");
        public string FormattedTotalPaid => TotalPaid.ToString("C2").Replace("$", "₱");

        public Loan()
        {
            ApplicationDate = DateTime.Now;
            Status = "Pending";
            PaymentsMade = 0;
            PaymentsRemaining = 0;
            TotalPaid = 0;
            RemainingBalance = 0;
        }
    }
}
