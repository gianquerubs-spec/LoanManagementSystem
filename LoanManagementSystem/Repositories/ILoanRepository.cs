using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repositories
{
    public interface ILoanRepository
    {
        List<Loan> GetAllLoans();
        List<Loan> GetLoansByStatus(string status);
        Loan GetLoanById(int id);
        Loan GetLoanByNumber(string loanNumber);
        bool AddLoan(Loan loan);
        bool UpdateLoan(Loan loan);
        bool DeleteLoan(int id);
    }
}