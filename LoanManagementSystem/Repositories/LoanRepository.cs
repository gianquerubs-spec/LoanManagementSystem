using LoanManagementSystem.Models;
using LoanManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        public List<Loan> GetAllLoans()
        {
            var loans = new List<Loan>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT l.*, c.FullName as ClientName " +
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientID = c.ID " +
                    "ORDER BY l.LoanNumber ASC", // Changed to sort by LoanNumber
                    connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(CreateLoanFromReader(reader));
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
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientID = c.ID " +
                    "WHERE l.Status = @Status " +
                    "ORDER BY l.LoanNumber ASC", // Changed to sort by LoanNumber
                    connection);

                command.Parameters.AddWithValue("@Status", status);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(CreateLoanFromReader(reader));
                    }
                }
            }
            return loans;
        }

        public Loan GetLoanById(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT l.*, c.FullName as ClientName " +
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientID = c.ID " +
                    "WHERE l.Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@ID", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return CreateLoanFromReader(reader);
                    }
                }
            }
            return null;
        }

        public Loan GetLoanByNumber(string loanNumber)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT l.*, c.FullName as ClientName " +
                    "FROM tbl_loans l INNER JOIN tbl_clients c ON l.ClientID = c.ID " +
                    "WHERE l.LoanNumber = @LoanNumber",
                    connection);

                command.Parameters.AddWithValue("@LoanNumber", loanNumber);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return CreateLoanFromReader(reader);
                    }
                }
            }
            return null;
        }

        public bool AddLoan(Loan loan)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Generate loan number first
                string loanNumber = GenerateLoanNumber();

                var command = new SqlCommand(
                    "INSERT INTO tbl_loans (LoanNumber, ClientID, LoanAmount, InterestRate, TermMonths, MonthlyPayment, TotalRepayment, Status, ApplicationDate, ProcessedBy, Notes) " +
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
                command.Parameters.AddWithValue("@ProcessedBy", loan.ProcessedBy);
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
                    "UPDATE tbl_loans SET Status = @Status, ApprovalDate = @ApprovalDate, DisbursementDate = @DisbursementDate, Notes = @Notes WHERE Id = @ID",
                    connection);

                command.Parameters.AddWithValue("@Status", loan.Status);
                command.Parameters.AddWithValue("@ApprovalDate", (object)loan.ApprovalDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@DisbursementDate", (object)loan.DisbursementDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Notes", (object)loan.Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@ID", loan.Id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteLoan(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM tbl_loans WHERE Id = @ID AND Status = 'Pending'", connection);
                command.Parameters.AddWithValue("@ID", id);

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

        private Loan CreateLoanFromReader(SqlDataReader reader)
        {
            return new Loan
            {
                Id = (int)reader["ID"],
                LoanNumber = reader["LoanNumber"].ToString(),
                ClientId = (int)reader["ClientID"],
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