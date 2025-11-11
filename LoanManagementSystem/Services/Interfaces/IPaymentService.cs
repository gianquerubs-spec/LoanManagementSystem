using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        bool ProcessPayment(Payment payment);
        List<Payment> GetPaymentsByLoan(string loanNumber);
        List<Payment> GetPaymentsByClient(int clientId);
        Payment GetPaymentById(int id);
        decimal GetTotalPaid(string loanNumber);
        bool UpdatePayment(Payment payment);
        bool DeletePayment(int id);
        List<Payment> GetOverduePayments();

        // ADD THIS METHOD
        List<Payment> GetAllPayments();
    }
}