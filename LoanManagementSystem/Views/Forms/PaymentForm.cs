using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    public partial class PaymentForm : Form
    {
        public Payment Payment { get; private set; }

        // Constructor for new payment
        public PaymentForm(string loanNumber)
        {
            InitializeComponent();
            SetupForm(loanNumber);
        }

        private void SetupForm(string loanNumber)
        {
            txtLoanNumber.Text = loanNumber;
            dtpPaymentDate.Value = DateTime.Now;

            // Wire up events
            btnSubmit.Click += BtnSubmit_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SavePayment();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLoanNumber.Text))
            {
                MessageBox.Show("Loan number is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid payment amount.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbPaymentMethod.Text))
            {
                MessageBox.Show("Please select a payment method.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMethod.Focus();
                return false;
            }

            return true;
        }

        private void SavePayment()
        {
            Payment = new Payment
            {
                LoanNumber = txtLoanNumber.Text.Trim(),
                PaymentDate = dtpPaymentDate.Value,
                Amount = decimal.Parse(txtAmount.Text),
                PaymentMethod = cmbPaymentMethod.Text,
                Status = "Completed",
                ReceiptNumber = string.IsNullOrWhiteSpace(txtReceiptNumber.Text) ? null : txtReceiptNumber.Text.Trim(),
                ProcessedBy = 1, // Default user ID
                Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim()
            };
        }
    }
}