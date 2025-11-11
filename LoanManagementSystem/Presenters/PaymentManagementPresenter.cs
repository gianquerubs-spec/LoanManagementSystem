using LoanManagementSystem.Services.Interfaces;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Presenters
{
    public class PaymentManagementPresenter
    {
        private readonly IPaymentManagementView _view;
        private readonly IPaymentService _paymentService;

        public PaymentManagementPresenter(IPaymentManagementView view, IPaymentService paymentService)
        {
            _view = view;
            _paymentService = paymentService;

            _view.LoadPayments += OnLoadPayments;
            _view.ProcessPaymentClicked += OnProcessPaymentClicked;
            _view.ViewPaymentDetailsClicked += OnViewPaymentDetailsClicked;
            _view.SearchClicked += OnSearchClicked;
            _view.SearchTextChanged += OnSearchTextChanged;
        }

        private void OnLoadPayments(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void OnProcessPaymentClicked(object sender, EventArgs e)
        {
            ProcessPayment();
        }

        private void OnViewPaymentDetailsClicked(object sender, EventArgs e)
        {
            ViewPaymentDetails();
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void LoadPayments()
        {
            _view.ShowLoading();

            var payments = _paymentService.GetAllPayments();

            if (payments != null)
            {
                _view.DisplayPayments(payments);
            }
            else
            {
                _view.ShowMessage("Unable to load payments.", "Error", true);
            }

            _view.HideLoading();
        }

        private void ProcessPayment()
        {
            string loanNumber = _view.GetSelectedLoanNumber();

            if (string.IsNullOrEmpty(loanNumber))
            {
                _view.ShowMessage("Please select a loan to process payment for.", "No Selection", false);
                return;
            }

            var payment = _view.ShowPaymentFormDialog(loanNumber);

            if (payment != null)
            {
                _view.ShowLoading();

                bool isProcessed = _paymentService.ProcessPayment(payment);

                _view.HideLoading();

                if (isProcessed)
                {
                    _view.ShowMessage("Payment processed successfully!", "Success", false);
                    LoadPayments();
                }
                else
                {
                    _view.ShowMessage("Failed to process payment.", "Error", true);
                }
            }
        }

        private void ViewPaymentDetails()
        {
            int paymentId = _view.GetSelectedPaymentId();

            if (paymentId == -1)
            {
                _view.ShowMessage("Please select a payment to view details.", "No Selection", false);
                return;
            }

            _view.ShowLoading();

            var payment = _paymentService.GetPaymentById(paymentId);

            _view.HideLoading();

            if (payment != null)
            {
                string details = $"Payment Details:\n\n" +
                               $"Payment ID: {payment.Id}\n" +
                               $"Loan Number: {payment.LoanNumber}\n" +
                               $"Amount: {FormatCurrency(payment.Amount)}\n" +
                               $"Payment Date: {payment.PaymentDate:MMM dd, yyyy}\n" +
                               $"Payment Method: {payment.PaymentMethod}\n" +
                               $"Status: {payment.Status}\n" +
                               $"Receipt Number: {payment.ReceiptNumber ?? "N/A"}\n" +
                               $"Processed By: User {payment.ProcessedBy}";

                if (!string.IsNullOrEmpty(payment.Notes))
                {
                    details += $"\nNotes: {payment.Notes}";
                }

                _view.ShowMessage(details, "Payment Details", false);
            }
            else
            {
                _view.ShowMessage("Payment not found.", "Error", true);
            }
        }

        private void PerformSearch()
        {
            string term = _view.SearchTerm?.Trim();

            if (string.IsNullOrWhiteSpace(term))
            {
                LoadPayments();
                return;
            }

            _view.ShowLoading();

            // For now, we'll filter client-side. You can implement server-side search later.
            var allPayments = _paymentService.GetAllPayments();
            var filteredPayments = allPayments.FindAll(p =>
                p.LoanNumber.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 ||
                (p.ReceiptNumber != null && p.ReceiptNumber.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
            );

            _view.DisplayPayments(filteredPayments);
            _view.HideLoading();
        }

        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("C2").Replace("$", "₱");
        }
    }
}