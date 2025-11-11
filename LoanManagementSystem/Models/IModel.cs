using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    public interface IModel
    {
        List<Loan> GetLoans();
        void AddLoan(Loan loan);
        decimal CalculateMonthlyPayment(Loan loan);
        // Add other methods, e.g., for borrowers
    }
}