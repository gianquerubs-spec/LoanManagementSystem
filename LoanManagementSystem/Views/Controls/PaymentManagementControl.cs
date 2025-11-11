using LoanManagementSystem.Models;
using LoanManagementSystem.Views.Forms;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Controls
{
    public partial class PaymentManagementControl : UserControl, IPaymentManagementView
    {
        private bool _isPlaceholderActive = true;

        public string SearchTerm
        {
            get
            {
                return _isPlaceholderActive ? string.Empty : txtSearch.Text;
            }
        }

        public event EventHandler LoadPayments;
        public event EventHandler ProcessPaymentClicked;
        public event EventHandler ViewPaymentDetailsClicked;
        public event EventHandler SearchClicked;
        public event EventHandler SearchTextChanged;

        public PaymentManagementControl()
        {
            InitializeComponent();
            SetupPlaceholderText();
            WireUpEvents();
        }

        private void SetupPlaceholderText()
        {
            txtSearch.Text = "Search by loan number...";
            txtSearch.ForeColor = Color.Gray;
            _isPlaceholderActive = true;
        }

        private void WireUpEvents()
        {
            this.Load += (s, e) => LoadPayments?.Invoke(this, EventArgs.Empty);
            btnProcessPayment.Click += (s, e) => ProcessPaymentClicked?.Invoke(this, EventArgs.Empty);
            btnViewDetails.Click += (s, e) => ViewPaymentDetailsClicked?.Invoke(this, EventArgs.Empty);
            btnSearch.Click += (s, e) => SearchClicked?.Invoke(this, EventArgs.Empty);
            txtSearch.TextChanged += (s, e) => SearchTextChanged?.Invoke(this, EventArgs.Empty);

            // Add events for placeholder text handling
            txtSearch.GotFocus += RemovePlaceholderText;
            txtSearch.LostFocus += AddPlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (_isPlaceholderActive)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
                _isPlaceholderActive = false;
            }
        }

        private void AddPlaceholderText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search by loan number...";
                txtSearch.ForeColor = Color.Gray;
                _isPlaceholderActive = true;
            }
        }

        public void DisplayPayments(List<Payment> payments)
        {
            dataGridViewPayments.Rows.Clear();

            foreach (var payment in payments)
            {
                dataGridViewPayments.Rows.Add(
                    payment.Id,
                    payment.LoanNumber,
                    payment.PaymentDate.ToString("MM/dd/yyyy"),
                    FormatCurrency(payment.Amount),
                    payment.PaymentMethod,
                    payment.Status,
                    payment.ReceiptNumber ?? "N/A",
                    payment.Notes ?? "N/A"
                );
            }
        }

        public Payment ShowPaymentFormDialog(string loanNumber)
        {
            using (var paymentForm = new PaymentForm(loanNumber))
            {
                var result = paymentForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return paymentForm.Payment;
                }
            }
            return null;
        }

        public void ShowMessage(string message, string caption, bool isError = false)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public bool ConfirmAction(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ShowLoading()
        {
            Cursor = Cursors.WaitCursor;
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
        }

        public void HideLoading()
        {
            Cursor = Cursors.Default;
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }
        }

        public string GetSelectedLoanNumber()
        {
            if (dataGridViewPayments.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewPayments.SelectedRows[0];
                return selectedRow.Cells["colLoanNumber"].Value?.ToString();
            }
            return null;
        }

        public int GetSelectedPaymentId()
        {
            if (dataGridViewPayments.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewPayments.SelectedRows[0];
                if (selectedRow.Cells["colId"].Value != null)
                {
                    return (int)selectedRow.Cells["colId"].Value;
                }
            }
            return -1;
        }

        public void ClearSelection()
        {
            dataGridViewPayments.ClearSelection();
        }

        private string FormatCurrency(decimal amount)
        {
            return "₱" + amount.ToString("N2");
        }
    }
}