using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface ILoanProcessingView
    {
        // Properties
        string StatusFilter { get; }

        // Events
        event EventHandler LoadLoans;
        event EventHandler NewLoanClicked;
        event EventHandler ApproveLoanClicked;
        event EventHandler RejectLoanClicked;
        event EventHandler ViewDetailsClicked;
        event EventHandler FilterChanged;
        event EventHandler LoanSelected;

        // Methods
        void DisplayLoans(List<Loan> loans);
        void DisplayLoanDetails(Loan loan);
        void ClearLoanDetails();
        void EnableActionButtons(bool approveEnabled, bool rejectEnabled);

        // CHANGE THIS METHOD TO RETURN LOAN OBJECT
        Loan ShowNewLoanFormDialog(); // Changed from DialogResult to Loan

        void ShowMessage(string message, string caption, bool isError = false);
        bool ConfirmAction(string message, string caption);
        void ShowLoading();
        void HideLoading();
        string GetSelectedLoanNumber();
        void SetupDataGridView();
    }
}