using LoanManagementSystem.Models;
using LoanManagementSystem.Services.Interfaces;
using LoanManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public class PaymentService : IPaymentService
    {
        public List<Payment> GetAllPayments()
        {
            var payments = new List<Payment>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM tbl_payments ORDER BY PaymentDate DESC",
                    connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            PaymentDate = (DateTime)reader["PaymentDate"],
                            Amount = (decimal)reader["Amount"],
                            PaymentMethod = reader["PaymentMethod"].ToString(),
                            Status = reader["Status"].ToString(),
                            ReceiptNumber = reader["ReceiptNumber"]?.ToString(),
                            ProcessedBy = (int)reader["ProcessedBy"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            Notes = reader["Notes"]?.ToString()
                        });
                    }
                }
            }

            return payments;
        }

        public bool ProcessPayment(Payment payment)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO tbl_payments (LoanNumber, PaymentDate, Amount, PaymentMethod, Status, ReceiptNumber, ProcessedBy, Notes) " +
                    "VALUES (@LoanNumber, @PaymentDate, @Amount, @PaymentMethod, @Status, @ReceiptNumber, @ProcessedBy, @Notes)",
                    connection);

                command.Parameters.AddWithValue("@LoanNumber", payment.LoanNumber);
                command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                command.Parameters.AddWithValue("@Amount", payment.Amount);
                command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                command.Parameters.AddWithValue("@Status", payment.Status);
                command.Parameters.AddWithValue("@ReceiptNumber", (object)payment.ReceiptNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@ProcessedBy", payment.ProcessedBy);
                command.Parameters.AddWithValue("@Notes", (object)payment.Notes ?? DBNull.Value);

                bool paymentSaved = command.ExecuteNonQuery() > 0;

                if (paymentSaved)
                {
                    // Update loan payment tracking
                    UpdateLoanPaymentTracking(payment.LoanNumber, payment.Amount);
                }

                return paymentSaved;
            }
        }

        public List<Payment> GetPaymentsByLoan(string loanNumber)
        {
            var payments = new List<Payment>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM tbl_payments WHERE LoanNumber = @LoanNumber ORDER BY PaymentDate DESC",
                    connection);

                command.Parameters.AddWithValue("@LoanNumber", loanNumber);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            PaymentDate = (DateTime)reader["PaymentDate"],
                            Amount = (decimal)reader["Amount"],
                            PaymentMethod = reader["PaymentMethod"].ToString(),
                            Status = reader["Status"].ToString(),
                            ReceiptNumber = reader["ReceiptNumber"]?.ToString(),
                            ProcessedBy = (int)reader["ProcessedBy"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            Notes = reader["Notes"]?.ToString()
                        });
                    }
                }
            }

            return payments;
        }

        public List<Payment> GetPaymentsByClient(int clientId)
        {
            var payments = new List<Payment>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT p.* FROM tbl_payments p " +
                    "INNER JOIN tbl_loans l ON p.LoanNumber = l.LoanNumber " +
                    "WHERE l.ClientId = @ClientId ORDER BY p.PaymentDate DESC",
                    connection);

                command.Parameters.AddWithValue("@ClientId", clientId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            PaymentDate = (DateTime)reader["PaymentDate"],
                            Amount = (decimal)reader["Amount"],
                            PaymentMethod = reader["PaymentMethod"].ToString(),
                            Status = reader["Status"].ToString(),
                            ReceiptNumber = reader["ReceiptNumber"]?.ToString(),
                            ProcessedBy = (int)reader["ProcessedBy"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            Notes = reader["Notes"]?.ToString()
                        });
                    }
                }
            }

            return payments;
        }

        public Payment GetPaymentById(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM tbl_payments WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Payment
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            PaymentDate = (DateTime)reader["PaymentDate"],
                            Amount = (decimal)reader["Amount"],
                            PaymentMethod = reader["PaymentMethod"].ToString(),
                            Status = reader["Status"].ToString(),
                            ReceiptNumber = reader["ReceiptNumber"]?.ToString(),
                            ProcessedBy = (int)reader["ProcessedBy"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            Notes = reader["Notes"]?.ToString()
                        };
                    }
                }
            }

            return null;
        }

        public decimal GetTotalPaid(string loanNumber)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT SUM(Amount) FROM tbl_payments WHERE LoanNumber = @LoanNumber AND Status = 'Completed'",
                    connection);

                command.Parameters.AddWithValue("@LoanNumber", loanNumber);

                var result = command.ExecuteScalar();
                return result == DBNull.Value ? 0 : (decimal)result;
            }
        }

        public bool UpdatePayment(Payment payment)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE tbl_payments SET Amount = @Amount, PaymentMethod = @PaymentMethod, Status = @Status, " +
                    "ReceiptNumber = @ReceiptNumber, Notes = @Notes WHERE Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@Amount", payment.Amount);
                command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                command.Parameters.AddWithValue("@Status", payment.Status);
                command.Parameters.AddWithValue("@ReceiptNumber", (object)payment.ReceiptNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@Notes", (object)payment.Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@Id", payment.Id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeletePayment(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM tbl_payments WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Payment> GetOverduePayments()
        {
            var payments = new List<Payment>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT p.* FROM tbl_payments p " +
                    "INNER JOIN tbl_loans l ON p.LoanNumber = l.LoanNumber " +
                    "WHERE p.Status = 'Pending' AND p.PaymentDate < @Today",
                    connection);

                command.Parameters.AddWithValue("@Today", DateTime.Today);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            PaymentDate = (DateTime)reader["PaymentDate"],
                            Amount = (decimal)reader["Amount"],
                            PaymentMethod = reader["PaymentMethod"].ToString(),
                            Status = reader["Status"].ToString(),
                            ReceiptNumber = reader["ReceiptNumber"]?.ToString(),
                            ProcessedBy = (int)reader["ProcessedBy"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            Notes = reader["Notes"]?.ToString()
                        });
                    }
                }
            }

            return payments;
        }

        private void UpdateLoanPaymentTracking(string loanNumber, decimal paymentAmount)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Get current loan details
                var loanCommand = new SqlCommand(
                    "SELECT LoanAmount, TotalRepayment, MonthlyPayment, TermMonths FROM tbl_loans WHERE LoanNumber = @LoanNumber",
                    connection);
                loanCommand.Parameters.AddWithValue("@LoanNumber", loanNumber);

                using (var reader = loanCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal loanAmount = (decimal)reader["LoanAmount"];
                        decimal totalRepayment = (decimal)reader["TotalRepayment"];
                        decimal monthlyPayment = (decimal)reader["MonthlyPayment"];
                        int termMonths = (int)reader["TermMonths"];

                        reader.Close();

                        // Calculate payment tracking
                        decimal totalPaid = GetTotalPaid(loanNumber);
                        int paymentsMade = (int)(totalPaid / monthlyPayment);
                        int paymentsRemaining = termMonths - paymentsMade;
                        decimal remainingBalance = totalRepayment - totalPaid;

                        // Update loan with payment tracking info
                        var updateCommand = new SqlCommand(
                            "UPDATE tbl_loans SET PaymentsMade = @PaymentsMade, PaymentsRemaining = @PaymentsRemaining, " +
                            "TotalPaid = @TotalPaid, RemainingBalance = @RemainingBalance, " +
                            "NextPaymentDate = @NextPaymentDate WHERE LoanNumber = @LoanNumber",
                            connection);

                        updateCommand.Parameters.AddWithValue("@PaymentsMade", paymentsMade);
                        updateCommand.Parameters.AddWithValue("@PaymentsRemaining", paymentsRemaining);
                        updateCommand.Parameters.AddWithValue("@TotalPaid", totalPaid);
                        updateCommand.Parameters.AddWithValue("@RemainingBalance", remainingBalance);
                        updateCommand.Parameters.AddWithValue("@NextPaymentDate", DateTime.Now.AddMonths(1));
                        updateCommand.Parameters.AddWithValue("@LoanNumber", loanNumber);

                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}