using LoanManagementSystem.Models;
using LoanManagementSystem.Views.Forms;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    public partial class LoanProcessingControl : UserControl, ILoanProcessingView
    {
        public string StatusFilter => cmbFilterStatus.Text;

        public event EventHandler LoadLoans;
        public event EventHandler NewLoanClicked;
        public event EventHandler ApproveLoanClicked;
        public event EventHandler RejectLoanClicked;
        public event EventHandler ViewDetailsClicked;
        public event EventHandler FilterChanged;
        public event EventHandler LoanSelected;

        public LoanProcessingControl()
        {
            InitializeComponent();
            WireUpEvents();
            cmbFilterStatus.SelectedIndex = 0;
            ClearLoanDetails();
        }

        private void WireUpEvents()
        {
            this.Load += (s, e) => LoadLoans?.Invoke(this, EventArgs.Empty);
            btnNewLoan.Click += (s, e) => NewLoanClicked?.Invoke(this, EventArgs.Empty);
            btnApproveLoan.Click += (s, e) => ApproveLoanClicked?.Invoke(this, EventArgs.Empty);
            btnRejectLoan.Click += (s, e) => RejectLoanClicked?.Invoke(this, EventArgs.Empty);
            btnViewDetails.Click += (s, e) => ViewDetailsClicked?.Invoke(this, EventArgs.Empty);
            cmbFilterStatus.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            dataGridViewLoans.SelectionChanged += (s, e) => LoanSelected?.Invoke(this, EventArgs.Empty);
        }

        // ILoanProcessingView method implementations
        public void SetupDataGridView()
        {
            dataGridViewLoans.AutoGenerateColumns = false;
            dataGridViewLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLoans.MultiSelect = false;
            dataGridViewLoans.AllowUserToAddRows = false;
            dataGridViewLoans.ReadOnly = true;
            dataGridViewLoans.RowHeadersVisible = false;

            // Clear and setup columns
            dataGridViewLoans.Columns.Clear();
            dataGridViewLoans.Columns.Add("LoanNumber", "Loan Number");
            dataGridViewLoans.Columns.Add("ClientName", "Client Name");
            dataGridViewLoans.Columns.Add("LoanAmount", "Loan Amount");
            dataGridViewLoans.Columns.Add("InterestRate", "Interest Rate");
            dataGridViewLoans.Columns.Add("TermMonths", "Term");
            dataGridViewLoans.Columns.Add("MonthlyPayment", "Monthly Payment");
            dataGridViewLoans.Columns.Add("Status", "Status");
            dataGridViewLoans.Columns.Add("ApplicationDate", "Application Date");

            // Auto-size columns
            foreach (DataGridViewColumn col in dataGridViewLoans.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void DisplayLoans(List<Loan> loans)
        {
            dataGridViewLoans.Rows.Clear();

            foreach (var loan in loans)
            {
                dataGridViewLoans.Rows.Add(
                    loan.LoanNumber,
                    loan.ClientName,
                    FormatCurrency(loan.LoanAmount),
                    loan.InterestRate.ToString("0.00") + "%",
                    loan.TermMonths + " months",
                    FormatCurrency(loan.MonthlyPayment),
                    loan.Status,
                    loan.ApplicationDate.ToString("MMM dd, yyyy")
                );
            }
        }

        public void DisplayLoanDetails(Loan loan)
        {
            if (loan != null)
            {
                lblClientName.Text = "Client: " + loan.ClientName;
                lblLoanAmount.Text = "Loan Amount: " + FormatCurrency(loan.LoanAmount);
                lblStatus.Text = "Status: " + loan.Status;
                lblApplicationDate.Text = "Application Date: " + loan.ApplicationDate.ToString("MMM dd, yyyy");
            }
        }

        public void ClearLoanDetails()
        {
            lblClientName.Text = "Client: ";
            lblLoanAmount.Text = "Loan Amount: ";
            lblStatus.Text = "Status: ";
            lblApplicationDate.Text = "Application Date: ";
            EnableActionButtons(false, false);
        }

        public void EnableActionButtons(bool approveEnabled, bool rejectEnabled)
        {
            btnApproveLoan.Enabled = approveEnabled;
            btnRejectLoan.Enabled = rejectEnabled;
        }

        public Loan ShowNewLoanFormDialog()
        {
            using (var newLoanForm = new NewLoanForm())
            {
                var result = newLoanForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return newLoanForm.CreatedLoan; 
                }
            }
            return null;
        }

        public void ShowMessage(string message, string caption, bool isError = false)
        {
            MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Error : MessageBoxIcon.Information
            );
        }

        public bool ConfirmAction(string message, string caption)
        {
            var result = MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }

        public void ShowLoading()
        {
            Cursor = Cursors.WaitCursor;
        }

        public void HideLoading()
        {
            Cursor = Cursors.Default;
        }

        public string GetSelectedLoanNumber()
        {
            if (dataGridViewLoans.SelectedRows.Count > 0)
            {
                return dataGridViewLoans.SelectedRows[0].Cells["LoanNumber"].Value?.ToString();
            }
            return null;
        }

        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("C2").Replace("$", "₱");
        }
    }
}