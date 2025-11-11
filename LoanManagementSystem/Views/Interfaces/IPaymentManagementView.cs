using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface IPaymentManagementView
    {
        string SearchTerm { get; }

        event EventHandler LoadPayments;
        event EventHandler ProcessPaymentClicked;
        event EventHandler ViewPaymentDetailsClicked;
        event EventHandler SearchClicked;
        event EventHandler SearchTextChanged;

        void DisplayPayments(List<Payment> payments);
        Payment ShowPaymentFormDialog(string loanNumber);
        void ShowMessage(string message, string caption, bool isError = false);
        bool ConfirmAction(string message, string caption);
        void ShowLoading();
        void HideLoading();
        string GetSelectedLoanNumber();
        int GetSelectedPaymentId();
        void ClearSelection();
    }
}