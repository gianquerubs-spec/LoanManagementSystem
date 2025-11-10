using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Forms
{
    public partial class LoanProcessingControl : UserControl
    {
        private LoanService _loanService;
        private Loan _selectedLoan;

        public LoanProcessingControl()
        {
            InitializeComponent();
            _loanService = new LoanService();
            SetupDataGridView();
            LoadLoans();
            cmbFilterStatus.SelectedIndex = 0;
            ClearDetails();
        }

        private void SetupDataGridView()
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

        private void LoadLoans(string statusFilter = "All")
        {
            dataGridViewLoans.Rows.Clear();

            var loans = statusFilter == "All"
                ? _loanService.GetAllLoans()
                : _loanService.GetLoansByStatus(statusFilter);

            // Sort loans by LoanNumber in ascending order
            var sortedLoans = SortLoansByLoanNumber(loans);

            foreach (var loan in sortedLoans)
            {
                dataGridViewLoans.Rows.Add(
                    loan.LoanNumber,
                    loan.ClientName,
                    FormatCurrency(loan.LoanAmount),  // Changed this line
                    loan.InterestRate.ToString("0.00") + "%",
                    loan.TermMonths + " months",
                    FormatCurrency(loan.MonthlyPayment),  // Changed this line
                    loan.Status,
                    loan.ApplicationDate.ToString("MMM dd, yyyy")
                );
            }
        }

        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("C2").Replace("$", "₱");
        }

        private List<Loan> SortLoansByLoanNumber(List<Loan> loans)
        {
            // Sort by LoanNumber in ascending order
            return loans.OrderBy(l => l.LoanNumber).ToList();
        }

        private void DataGridViewLoans_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLoans.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewLoans.SelectedRows[0];
                string loanNumber = selectedRow.Cells["LoanNumber"].Value.ToString();
                _selectedLoan = _loanService.GetLoanByNumber(loanNumber);
                DisplayLoanDetails();
            }
            else
            {
                ClearDetails();
            }
        }

        private void DisplayLoanDetails()
        {
            if (_selectedLoan != null)
            {
                lblClientName.Text = "Client: " + _selectedLoan.ClientName;
                lblLoanAmount.Text = "Loan Amount: " + FormatCurrency(_selectedLoan.LoanAmount);  // Changed this line
                lblStatus.Text = "Status: " + _selectedLoan.Status;
                lblApplicationDate.Text = "Application Date: " + _selectedLoan.ApplicationDate.ToString("MMM dd, yyyy");

                // Enable/disable buttons based on status
                btnApproveLoan.Enabled = _selectedLoan.Status == "Pending";
                btnRejectLoan.Enabled = _selectedLoan.Status == "Pending";
            }
        }

        private void ClearDetails()
        {
            lblClientName.Text = "Client: ";
            lblLoanAmount.Text = "Loan Amount: ";
            lblStatus.Text = "Status: ";
            lblApplicationDate.Text = "Application Date: ";
            _selectedLoan = null;
            btnApproveLoan.Enabled = false;
            btnRejectLoan.Enabled = false;
        }

        private void BtnNewLoan_Click(object sender, EventArgs e)
        {
            using (var newLoanForm = new NewLoanForm())
            {
                if (newLoanForm.ShowDialog() == DialogResult.OK && newLoanForm.CreatedLoan != null)
                {
                    int processedByUserId = 1;

                    bool success = _loanService.AddLoan(newLoanForm.CreatedLoan, processedByUserId);

                    if (success)
                    {
                        LoadLoans(cmbFilterStatus.Text);
                        MessageBox.Show("Loan application submitted successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to submit loan application. Please try again.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnApproveLoan_Click(object sender, EventArgs e)
        {
            if (_selectedLoan != null && _selectedLoan.Status == "Pending")
            {
                var result = MessageBox.Show($"Approve loan {_selectedLoan.LoanNumber} for {_selectedLoan.ClientName}?",
                                          "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _selectedLoan.Status = "Approved";
                    _selectedLoan.ApprovalDate = DateTime.Now;
                    var updateResult = _loanService.UpdateLoan(_selectedLoan);
                    if (updateResult)
                    {
                        LoadLoans(cmbFilterStatus.Text);
                        ClearDetails();
                        MessageBox.Show("Loan approved successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update loan status.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRejectLoan_Click(object sender, EventArgs e)
        {
            if (_selectedLoan != null && _selectedLoan.Status == "Pending")
            {
                var result = MessageBox.Show($"Reject loan {_selectedLoan.LoanNumber} for {_selectedLoan.ClientName}?",
                                          "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _selectedLoan.Status = "Rejected";
                    var updateResult = _loanService.UpdateLoan(_selectedLoan);
                    if (updateResult)
                    {
                        LoadLoans(cmbFilterStatus.Text);
                        ClearDetails();
                        MessageBox.Show("Loan rejected.", "Completed",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update loan status.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (_selectedLoan != null)
            {
                string details = $"Loan Details:\n\n" +
                               $"Loan Number: {_selectedLoan.LoanNumber}\n" +
                               $"Client: {_selectedLoan.ClientName}\n" +
                               $"Amount: {FormatCurrency(_selectedLoan.LoanAmount)}\n" +  // Changed this line
                               $"Interest Rate: {_selectedLoan.InterestRate}%\n" +
                               $"Term: {_selectedLoan.TermMonths} months\n" +
                               $"Monthly Payment: {FormatCurrency(_selectedLoan.MonthlyPayment)}\n" +  // Changed this line
                               $"Total Repayment: {FormatCurrency(_selectedLoan.TotalRepayment)}\n" +  // Changed this line
                               $"Status: {_selectedLoan.Status}\n" +
                               $"Application Date: {_selectedLoan.ApplicationDate:MMM dd, yyyy}";

                if (!string.IsNullOrEmpty(_selectedLoan.Notes))
                {
                    details += $"\nNotes: {_selectedLoan.Notes}";
                }

                MessageBox.Show(details, "Loan Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a loan to view details", "No Selection",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLoans(cmbFilterStatus.Text);
            ClearDetails();
        }
    }
}