using LoanManagementSystem.Models;
using System.Collections.Generic;

namespace LoanManagementSystem.Interfaces.Services
{
    public interface ILoanService
    {
        List<Loan> GetAllLoans();
        List<Loan> GetLoansByStatus(string status);
        Loan GetLoanByNumber(string loanNumber);
        Loan GetLoanById(int id);

        
        bool AddLoan(Loan loan, int processedByUserId = 1);

        bool UpdateLoan(Loan loan);
        bool DeleteLoan(int id);
        decimal CalculateMonthlyPayment(decimal principal, decimal interestRate, int termMonths);
        decimal CalculateTotalRepayment(decimal monthlyPayment, int termMonths);
    }
}