using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoanManagementSystem.Presenters
{
    public class LoanProcessingPresenter
    {
        private readonly ILoanProcessingView _view;
        private readonly ILoanService _loanService;
        private Loan _selectedLoan;

        public LoanProcessingPresenter(ILoanProcessingView view, ILoanService loanService)
        {
            _view = view;
            _loanService = loanService;

            // Subscribe to view events
            _view.LoadLoans += OnLoadLoans;
            _view.NewLoanClicked += OnNewLoanClicked;
            _view.ApproveLoanClicked += OnApproveLoanClicked;
            _view.RejectLoanClicked += OnRejectLoanClicked;
            _view.ViewDetailsClicked += OnViewDetailsClicked;
            _view.FilterChanged += OnFilterChanged;
            _view.LoanSelected += OnLoanSelected;

            // Initial setup
            _view.SetupDataGridView();
        }

        private void OnLoadLoans(object sender, EventArgs e)
        {
            LoadLoans();
        }

        private void OnNewLoanClicked(object sender, EventArgs e)
        {
            CreateNewLoan();
        }

        private void OnApproveLoanClicked(object sender, EventArgs e)
        {
            ApproveLoan();
        }

        private void OnRejectLoanClicked(object sender, EventArgs e)
        {
            RejectLoan();
        }

        private void OnViewDetailsClicked(object sender, EventArgs e)
        {
            ViewLoanDetails();
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            LoadLoans();
            _view.ClearLoanDetails();
        }

        private void OnLoanSelected(object sender, EventArgs e)
        {
            string loanNumber = _view.GetSelectedLoanNumber();
            if (!string.IsNullOrEmpty(loanNumber))
            {
                _selectedLoan = _loanService.GetLoanByNumber(loanNumber);
                if (_selectedLoan != null)
                {
                    _view.DisplayLoanDetails(_selectedLoan);
                    _view.EnableActionButtons(_selectedLoan.Status == "Pending", _selectedLoan.Status == "Pending");
                }
            }
            else
            {
                _selectedLoan = null;
                _view.ClearLoanDetails();
            }
        }

        private void LoadLoans()
        {
            _view.ShowLoading();

            List<Loan> loans;
            if (_view.StatusFilter == "All")
            {
                loans = _loanService.GetAllLoans();
            }
            else
            {
                loans = _loanService.GetLoansByStatus(_view.StatusFilter);
            }

            if (loans != null)
            {
                // Sort loans by LoanNumber in ascending order (preserving your existing logic)
                var sortedLoans = SortLoansByLoanNumber(loans);
                _view.DisplayLoans(sortedLoans);
            }
            else
            {
                _view.ShowMessage("Unable to load loans.", "Error", true);
            }

            _view.HideLoading();
        }

        private List<Loan> SortLoansByLoanNumber(List<Loan> loans)
        {
            return loans.OrderBy(l => l.LoanNumber).ToList();
        }

        private void CreateNewLoan()
        {
            var newLoan = _view.ShowNewLoanFormDialog();

            if (newLoan != null)
            {
                _view.ShowLoading();

                // Save the loan to database
                bool isSaved = _loanService.AddLoan(newLoan, 1); // Use actual user ID

                _view.HideLoading();

                if (isSaved)
                {
                    _view.ShowMessage("Loan application submitted successfully!", "Success", false);
                    LoadLoans(); // Refresh DataGrid
                }
                else
                {
                    _view.ShowMessage("Failed to submit loan application.", "Error", true);
                }
            }
        }

        private void ApproveLoan()
        {
            if (_selectedLoan == null || _selectedLoan.Status != "Pending")
            {
                _view.ShowMessage("Please select a pending loan to approve.", "Warning", false);
                return;
            }

            bool confirm = _view.ConfirmAction(
                $"Approve loan {_selectedLoan.LoanNumber} for {_selectedLoan.ClientName}?",
                "Confirm Approval"
            );

            if (confirm)
            {
                _view.ShowLoading();

                _selectedLoan.Status = "Approved";
                _selectedLoan.ApprovalDate = DateTime.Now;

                bool updated = _loanService.UpdateLoan(_selectedLoan);

                _view.HideLoading();

                if (updated)
                {
                    _view.ShowMessage("Loan approved successfully!", "Success", false);
                    LoadLoans();
                    _view.ClearLoanDetails();
                }
                else
                {
                    _view.ShowMessage("Failed to update loan status.", "Error", true);
                }
            }
        }

        private void RejectLoan()
        {
            if (_selectedLoan == null || _selectedLoan.Status != "Pending")
            {
                _view.ShowMessage("Please select a pending loan to reject.", "Warning", false);
                return;
            }

            bool confirm = _view.ConfirmAction(
                $"Reject loan {_selectedLoan.LoanNumber} for {_selectedLoan.ClientName}?",
                "Confirm Rejection"
            );

            if (confirm)
            {
                _view.ShowLoading();

                _selectedLoan.Status = "Rejected";

                bool updated = _loanService.UpdateLoan(_selectedLoan);

                _view.HideLoading();

                if (updated)
                {
                    _view.ShowMessage("Loan rejected.", "Completed", false);
                    LoadLoans();
                    _view.ClearLoanDetails();
                }
                else
                {
                    _view.ShowMessage("Failed to update loan status.", "Error", true);
                }
            }
        }

        private void ViewLoanDetails()
        {
            if (_selectedLoan == null)
            {
                _view.ShowMessage("Please select a loan to view details.", "Warning", false);
                return;
            }

            string details = $"Loan Details:\n\n" +
                           $"Loan Number: {_selectedLoan.LoanNumber}\n" +
                           $"Client: {_selectedLoan.ClientName}\n" +
                           $"Amount: {FormatCurrency(_selectedLoan.LoanAmount)}\n" +
                           $"Interest Rate: {_selectedLoan.InterestRate}%\n" +
                           $"Term: {_selectedLoan.TermMonths} months\n" +
                           $"Monthly Payment: {FormatCurrency(_selectedLoan.MonthlyPayment)}\n" +
                           $"Total Repayment: {FormatCurrency(_selectedLoan.TotalRepayment)}\n" +
                           $"Status: {_selectedLoan.Status}\n" +
                           $"Application Date: {_selectedLoan.ApplicationDate:MMM dd, yyyy}";

            if (!string.IsNullOrEmpty(_selectedLoan.Notes))
            {
                details += $"\nNotes: {_selectedLoan.Notes}";
            }

            _view.ShowMessage(details, "Loan Details", false);
        }

        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("C2").Replace("$", "₱");
        }
    }
}