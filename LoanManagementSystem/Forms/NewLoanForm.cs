using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoanManagementSystem.Forms
{
    public partial class NewLoanForm : Form
    {
        private readonly ClientService _clientService;
        private readonly LoanService _loanService;
        private List<Client> _clients;

        // Add this property
        public Loan CreatedLoan { get; private set; }

        public NewLoanForm()
        {
            InitializeComponent();

            _clientService = new ClientService();
            _loanService = new LoanService();

            LoadClients();
            UpdateCalculations();
        }

        private void LoadClients()
        {
            _clients = _clientService.GetAllClients();
            cmbClient.DataSource = _clients;
            cmbClient.DisplayMember = "FullName";
            cmbClient.ValueMember = "Id";
            cmbClient.SelectedIndex = -1; // no selection initially
        }

        private void TxtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateCalculations();
        }

        private void TxtTerm_TextChanged(object sender, EventArgs e)
        {
            UpdateCalculations();
        }

        private void TxtLoanAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void TxtTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateCalculations()
        {
            decimal loanAmount = 0;
            int termMonths = 0;

            if (decimal.TryParse(txtLoanAmount.Text, out decimal la))
                loanAmount = la;

            if (int.TryParse(txtTerm.Text, out int tm))
                termMonths = tm;

            // Only calculate interest rate if both fields have valid values
            if (loanAmount > 0 && termMonths > 0)
            {
                decimal interestRate = GetInterestRate(loanAmount, termMonths);
                txtInterestRate.Text = interestRate.ToString("0.##");

                decimal monthlyPayment = _loanService.CalculateMonthlyPayment(loanAmount, interestRate, termMonths);
                decimal totalRepayment = _loanService.CalculateTotalRepayment(monthlyPayment, termMonths);
                decimal totalInterest = totalRepayment - loanAmount;

                lblMonthlyPaymentValue.Text = $"₱{monthlyPayment:N2}";
                lblTotalRepaymentValue.Text = $"₱{totalRepayment:N2}";
                lblTotalInterestValue.Text = $"₱{totalInterest:N2}";
                lblInterestRateValue.Text = $"{interestRate:N2}%";
            }
            else
            {
                // Clear all fields when no valid input
                txtInterestRate.Text = "0.00";
                lblMonthlyPaymentValue.Text = "₱0.00";
                lblTotalRepaymentValue.Text = "₱0.00";
                lblTotalInterestValue.Text = "₱0.00";
                lblInterestRateValue.Text = "0.00%";
            }
        }

        private decimal GetInterestRate(decimal loanAmount, int termMonths)
        {
            if (loanAmount == 0 || termMonths == 0)
                return 0m;

            if (loanAmount <= 10000)
            {
                if (termMonths <= 12) return 5m;
                else return 6m;
            }
            else if (loanAmount > 10000 && loanAmount <= 50000)
            {
                if (termMonths <= 24) return 4.5m;
                else return 5.5m;
            }
            else if (loanAmount > 50000)
            {
                if (termMonths <= 36) return 4m;
                else return 5m;
            }

            return 0m;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a client.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtLoanAmount.Text, out decimal loanAmount) || loanAmount <= 0)
            {
                MessageBox.Show("Please enter a valid loan amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTerm.Text, out int termMonths) || termMonths <= 0)
            {
                MessageBox.Show("Please enter a valid term (months).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal interestRate = GetInterestRate(loanAmount, termMonths);
            decimal monthlyPayment = _loanService.CalculateMonthlyPayment(loanAmount, interestRate, termMonths);
            decimal totalRepayment = _loanService.CalculateTotalRepayment(monthlyPayment, termMonths);

            Loan newLoan = new Loan
            {
                ClientId = ((Client)cmbClient.SelectedItem).Id,
                ClientName = cmbClient.Text,
                LoanAmount = loanAmount,
                InterestRate = interestRate,
                TermMonths = termMonths,
                MonthlyPayment = monthlyPayment,
                TotalRepayment = totalRepayment,
                Status = "Pending",
                ApplicationDate = DateTime.Now,
                Notes = txtNotes.Text
            };

            // Store the created loan in the property
            CreatedLoan = newLoan;

            // Set dialog result to OK and close
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}