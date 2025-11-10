using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public interface ILoanService
    {
        List<Loan> GetAllLoans();
        List<Loan> GetLoansByStatus(string status);
        Loan GetLoanById(int id);
        Loan GetLoanByNumber(string loanNumber);
        bool AddLoan(Loan loan, int processedByUserId);
        bool UpdateLoan(Loan loan);
        bool DeleteLoan(int id);
        decimal CalculateMonthlyPayment(decimal principal, decimal interestRate, int termMonths);
        decimal CalculateTotalRepayment(decimal monthlyPayment, int termMonths);
    }
}