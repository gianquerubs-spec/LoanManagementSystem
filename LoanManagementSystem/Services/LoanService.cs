using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Models;
using LoanManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LoanManagementSystem.Services
{
    public class LoanService : ILoanService  
    {
        public List<Loan> GetAllLoans()
        {
            var loans = new List<Loan>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT l.*, c.FullName as ClientName " +
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientId = c.Id " +
                    "ORDER BY l.LoanNumber ASC", 
                    connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(new Loan
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            ClientId = (int)reader["ClientId"],
                            ClientName = reader["ClientName"].ToString(),
                            LoanAmount = (decimal)reader["LoanAmount"],
                            InterestRate = (decimal)reader["InterestRate"],
                            TermMonths = (int)reader["TermMonths"],
                            MonthlyPayment = (decimal)reader["MonthlyPayment"],
                            TotalRepayment = (decimal)reader["TotalRepayment"],
                            Status = reader["Status"].ToString(),
                            ApplicationDate = (DateTime)reader["ApplicationDate"],
                            ApprovalDate = reader["ApprovalDate"] as DateTime?,
                            DisbursementDate = reader["DisbursementDate"] as DateTime?,
                            ProcessedBy = (int)reader["ProcessedBy"],
                            Notes = reader["Notes"]?.ToString()
                        });
                    }
                }
            }

            return loans;
        }

        public List<Loan> GetLoansByStatus(string status)
        {
            var loans = new List<Loan>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT l.*, c.FullName as ClientName " +
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientId = c.Id " +
                    "WHERE l.Status = @Status " +
                    "ORDER BY l.LoanNumber ASC", 
                    connection);

                command.Parameters.AddWithValue("@Status", status);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(new Loan
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            ClientId = (int)reader["ClientId"],
                            ClientName = reader["ClientName"].ToString(),
                            LoanAmount = (decimal)reader["LoanAmount"],
                            InterestRate = (decimal)reader["InterestRate"],
                            TermMonths = (int)reader["TermMonths"],
                            MonthlyPayment = (decimal)reader["MonthlyPayment"],
                            TotalRepayment = (decimal)reader["TotalRepayment"],
                            Status = reader["Status"].ToString(),
                            ApplicationDate = (DateTime)reader["ApplicationDate"],
                            ApprovalDate = reader["ApprovalDate"] as DateTime?,
                            DisbursementDate = reader["DisbursementDate"] as DateTime?,
                            ProcessedBy = (int)reader["ProcessedBy"],
                            Notes = reader["Notes"]?.ToString()
                        });
                    }
                }
            }

            return loans;
        }

        public Loan GetLoanByNumber(string loanNumber)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT l.*, c.FullName as ClientName " +
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientId = c.Id " +
                    "WHERE l.LoanNumber = @LoanNumber",
                    connection);

                command.Parameters.AddWithValue("@LoanNumber", loanNumber);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Loan
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            ClientId = (int)reader["ClientId"],
                            ClientName = reader["ClientName"].ToString(),
                            LoanAmount = (decimal)reader["LoanAmount"],
                            InterestRate = (decimal)reader["InterestRate"],
                            TermMonths = (int)reader["TermMonths"],
                            MonthlyPayment = (decimal)reader["MonthlyPayment"],
                            TotalRepayment = (decimal)reader["TotalRepayment"],
                            Status = reader["Status"].ToString(),
                            ApplicationDate = (DateTime)reader["ApplicationDate"],
                            ApprovalDate = reader["ApprovalDate"] as DateTime?,
                            DisbursementDate = reader["DisbursementDate"] as DateTime?,
                            ProcessedBy = (int)reader["ProcessedBy"],
                            Notes = reader["Notes"]?.ToString()
                        };
                    }
                }
            }

            return null;
        }

        public Loan GetLoanById(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT l.*, c.FullName as ClientName " +
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientId = c.Id " +
                    "WHERE l.Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Loan
                        {
                            Id = (int)reader["Id"],
                            LoanNumber = reader["LoanNumber"].ToString(),
                            ClientId = (int)reader["ClientId"],
                            ClientName = reader["ClientName"].ToString(),
                            LoanAmount = (decimal)reader["LoanAmount"],
                            InterestRate = (decimal)reader["InterestRate"],
                            TermMonths = (int)reader["TermMonths"],
                            MonthlyPayment = (decimal)reader["MonthlyPayment"],
                            TotalRepayment = (decimal)reader["TotalRepayment"],
                            Status = reader["Status"].ToString(),
                            ApplicationDate = (DateTime)reader["ApplicationDate"],
                            ApprovalDate = reader["ApprovalDate"] as DateTime?,
                            DisbursementDate = reader["DisbursementDate"] as DateTime?,
                            ProcessedBy = (int)reader["ProcessedBy"],
                            Notes = reader["Notes"]?.ToString()
                        };
                    }
                }
            }

            return null;
        }

        public bool AddLoan(Loan loan, int processedByUserId = 1)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Generate the loan number first
                string loanNumber = GenerateLoanNumber();

                var command = new SqlCommand(
                    "INSERT INTO tbl_loans (LoanNumber, ClientId, LoanAmount, InterestRate, TermMonths, MonthlyPayment, TotalRepayment, Status, ApplicationDate, ProcessedBy, Notes) " +
                    "VALUES (@LoanNumber, @ClientId, @LoanAmount, @InterestRate, @TermMonths, @MonthlyPayment, @TotalRepayment, @Status, @ApplicationDate, @ProcessedBy, @Notes)",
                    connection);

                command.Parameters.AddWithValue("@LoanNumber", loanNumber); // Use generated number
                command.Parameters.AddWithValue("@ClientId", loan.ClientId);
                command.Parameters.AddWithValue("@LoanAmount", loan.LoanAmount);
                command.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
                command.Parameters.AddWithValue("@TermMonths", loan.TermMonths);
                command.Parameters.AddWithValue("@MonthlyPayment", loan.MonthlyPayment);
                command.Parameters.AddWithValue("@TotalRepayment", loan.TotalRepayment);
                command.Parameters.AddWithValue("@Status", loan.Status);
                command.Parameters.AddWithValue("@ApplicationDate", loan.ApplicationDate);
                command.Parameters.AddWithValue("@ProcessedBy", processedByUserId);
                command.Parameters.AddWithValue("@Notes", (object)loan.Notes ?? DBNull.Value);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateLoan(Loan loan)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE tbl_loans SET Status = @Status, ApprovalDate = @ApprovalDate, DisbursementDate = @DisbursementDate, Notes = @Notes WHERE Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@Status", loan.Status);
                command.Parameters.AddWithValue("@ApprovalDate", (object)loan.ApprovalDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@DisbursementDate", (object)loan.DisbursementDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Notes", (object)loan.Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@Id", loan.Id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteLoan(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM tbl_loans WHERE Id = @Id AND Status = 'Pending'", connection);
                command.Parameters.AddWithValue("@Id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        private string GenerateLoanNumber()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Get the maximum existing loan number
                var command = new SqlCommand("SELECT MAX(LoanNumber) FROM tbl_loans WHERE LoanNumber LIKE 'LN%'", connection);
                var maxLoanNumber = command.ExecuteScalar() as string;

                if (string.IsNullOrEmpty(maxLoanNumber))
                {
                    return "LN001"; // First loan
                }

                // Extract the numeric part and increment
                if (int.TryParse(maxLoanNumber.Substring(2), out int lastNumber))
                {
                    return $"LN{(lastNumber + 1).ToString().PadLeft(3, '0')}";
                }
                else
                {
                    // Fallback: count based generation
                    var countCommand = new SqlCommand("SELECT COUNT(*) FROM tbl_loans", connection);
                    var count = (int)countCommand.ExecuteScalar();
                    return $"LN{(count + 1).ToString().PadLeft(3, '0')}";
                }
            }
        }

        public decimal CalculateMonthlyPayment(decimal principal, decimal interestRate, int termMonths)
        {
            decimal monthlyRate = interestRate / 100 / 12;
            decimal factor = (decimal)Math.Pow((double)(1 + monthlyRate), termMonths);
            return principal * monthlyRate * factor / (factor - 1);
        }

        public decimal CalculateTotalRepayment(decimal monthlyPayment, int termMonths)
        {
            return monthlyPayment * termMonths;
        }
        public void UpdateLoanPaymentTracking(string loanNumber)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Get payment service to calculate totals
                var paymentService = new PaymentService();
                decimal totalPaid = paymentService.GetTotalPaid(loanNumber);

                // Get loan details
                var loanCommand = new SqlCommand(
                    "SELECT LoanAmount, TotalRepayment, MonthlyPayment, TermMonths FROM tbl_loans WHERE LoanNumber = @LoanNumber",
                    connection);
                loanCommand.Parameters.AddWithValue("@LoanNumber", loanNumber);

                using (var reader = loanCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal monthlyPayment = (decimal)reader["MonthlyPayment"];
                        int termMonths = (int)reader["TermMonths"];
                        decimal totalRepayment = (decimal)reader["TotalRepayment"];

                        reader.Close();

                        // Calculate payment tracking
                        int paymentsMade = monthlyPayment > 0 ? (int)(totalPaid / monthlyPayment) : 0;
                        int paymentsRemaining = termMonths - paymentsMade;
                        decimal remainingBalance = totalRepayment - totalPaid;

                        // Update loan
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

        public Loan GetLoanWithPaymentInfo(string loanNumber)
        {
            var loan = GetLoanByNumber(loanNumber);
            if (loan != null)
            {
                var paymentService = new PaymentService();
                decimal totalPaid = paymentService.GetTotalPaid(loanNumber);

                loan.TotalPaid = totalPaid;
                loan.RemainingBalance = loan.TotalRepayment - totalPaid;
                loan.PaymentsMade = loan.MonthlyPayment > 0 ? (int)(totalPaid / loan.MonthlyPayment) : 0;
                loan.PaymentsRemaining = loan.TermMonths - loan.PaymentsMade;
            }
            return loan;
        }
    }
}