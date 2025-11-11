using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Models;
using LoanManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public class ClientService : IClientService
    {
        //Get all clients 
        public List<Client> GetAllClients()
        {
            var clients = new List<Client>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT Id, ClientCode, FullName, Email, Phone, Address, CreatedAt, CreatedBy " +
                    "FROM tbl_clients ORDER BY Id ASC", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = (int)reader["Id"],
                            ClientCode = reader["ClientCode"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Address = reader["Address"]?.ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            CreatedBy = (int)reader["CreatedBy"]
                        });
                    }
                }
            }

            return clients;
        }

        public bool AddClient(Client client, int createdByUserId = 1)
        {
            if (ClientCodeExists(client.ClientCode))
            {
                return false;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO tbl_clients (ClientCode, FullName, Email, Phone, Address, CreatedBy, CreatedAt, " +
                    "DateOfBirth, Gender, CivilStatus, Occupation, Employer, MonthlyIncome, EmploymentStatus, " +
                    "GovernmentIdType, GovernmentIdNumber, CreditScore, CreditRating) " +
                    "VALUES (@ClientCode, @FullName, @Email, @Phone, @Address, @CreatedBy, @CreatedAt, " +
                    "@DateOfBirth, @Gender, @CivilStatus, @Occupation, @Employer, @MonthlyIncome, @EmploymentStatus, " +
                    "@GovernmentIdType, @GovernmentIdNumber, @CreditScore, @CreditRating)",
                    connection);

                // Original parameters
                command.Parameters.AddWithValue("@ClientCode", client.ClientCode);
                command.Parameters.AddWithValue("@FullName", client.FullName);
                command.Parameters.AddWithValue("@Email", (object)client.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)client.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)client.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", createdByUserId);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                // New parameters
                command.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", (object)client.Gender ?? DBNull.Value);
                command.Parameters.AddWithValue("@CivilStatus", (object)client.CivilStatus ?? DBNull.Value);
                command.Parameters.AddWithValue("@Occupation", (object)client.Occupation ?? DBNull.Value);
                command.Parameters.AddWithValue("@Employer", (object)client.Employer ?? DBNull.Value);
                command.Parameters.AddWithValue("@MonthlyIncome", client.MonthlyIncome);
                command.Parameters.AddWithValue("@EmploymentStatus", (object)client.EmploymentStatus ?? DBNull.Value);
                command.Parameters.AddWithValue("@GovernmentIdType", (object)client.GovernmentIdType ?? DBNull.Value);
                command.Parameters.AddWithValue("@GovernmentIdNumber", (object)client.GovernmentIdNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreditScore", client.CreditScore);
                command.Parameters.AddWithValue("@CreditRating", (object)client.CreditRating ?? DBNull.Value);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool UpdateClient(Client client)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "UPDATE tbl_clients SET FullName = @FullName, Email = @Email, Phone = @Phone, Address = @Address, " +
                    "DateOfBirth = @DateOfBirth, Gender = @Gender, CivilStatus = @CivilStatus, Occupation = @Occupation, " +
                    "Employer = @Employer, MonthlyIncome = @MonthlyIncome, EmploymentStatus = @EmploymentStatus, " +
                    "GovernmentIdType = @GovernmentIdType, GovernmentIdNumber = @GovernmentIdNumber, " +
                    "CreditScore = @CreditScore, CreditRating = @CreditRating " +
                    "WHERE Id = @Id", connection);

                // Original parameters
                command.Parameters.AddWithValue("@FullName", client.FullName);
                command.Parameters.AddWithValue("@Email", (object)client.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)client.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)client.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@Id", client.Id);

                // New parameters
                command.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", (object)client.Gender ?? DBNull.Value);
                command.Parameters.AddWithValue("@CivilStatus", (object)client.CivilStatus ?? DBNull.Value);
                command.Parameters.AddWithValue("@Occupation", (object)client.Occupation ?? DBNull.Value);
                command.Parameters.AddWithValue("@Employer", (object)client.Employer ?? DBNull.Value);
                command.Parameters.AddWithValue("@MonthlyIncome", client.MonthlyIncome);
                command.Parameters.AddWithValue("@EmploymentStatus", (object)client.EmploymentStatus ?? DBNull.Value);
                command.Parameters.AddWithValue("@GovernmentIdType", (object)client.GovernmentIdType ?? DBNull.Value);
                command.Parameters.AddWithValue("@GovernmentIdNumber", (object)client.GovernmentIdNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreditScore", client.CreditScore);
                command.Parameters.AddWithValue("@CreditRating", (object)client.CreditRating ?? DBNull.Value);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Delete client by code (with loan check)
        public bool DeleteClientByCode(string clientCode)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Find client Id
                var checkCommand = new SqlCommand("SELECT Id FROM tbl_clients WHERE ClientCode = @ClientCode", connection);
                checkCommand.Parameters.AddWithValue("@ClientCode", clientCode);

                var id = checkCommand.ExecuteScalar();
                if (id == null) return false;

                int clientId = Convert.ToInt32(id);

                // Prevent deleting client with existing loans
                var loanCheck = new SqlCommand("SELECT COUNT(*) FROM tbl_loans WHERE ClientID = @ClientID", connection);
                loanCheck.Parameters.AddWithValue("@ClientID", clientId);
                int loanCount = (int)loanCheck.ExecuteScalar();

                if (loanCount > 0)
                    return false;

                var deleteCommand = new SqlCommand("DELETE FROM tbl_clients WHERE Id = @Id", connection);
                deleteCommand.Parameters.AddWithValue("@Id", clientId);

                return deleteCommand.ExecuteNonQuery() > 0;
            }
        }

        // Get client by code
        public Client GetClientByCode(string clientCode)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT Id, ClientCode, FullName, Email, Phone, Address, CreatedAt, CreatedBy " +
                    "FROM tbl_clients WHERE ClientCode = @ClientCode", connection);
                command.Parameters.AddWithValue("@ClientCode", clientCode);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client
                        {
                            Id = (int)reader["Id"],
                            ClientCode = reader["ClientCode"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Address = reader["Address"]?.ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            CreatedBy = (int)reader["CreatedBy"]
                        };
                    }
                }
            }

            return null;
        }

        //Search clients by term
        public List<Client> SearchClients(string term)
        {
            var clients = new List<Client>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT Id, ClientCode, FullName, Email, Phone, Address, CreatedAt, CreatedBy " +
                    "FROM tbl_clients WHERE FullName LIKE @term OR Email LIKE @term OR Phone LIKE @term OR ClientCode LIKE @term " +
                    "ORDER BY Id ASC", connection);

                command.Parameters.AddWithValue("@term", $"%{term}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = (int)reader["Id"],
                            ClientCode = reader["ClientCode"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Address = reader["Address"]?.ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            CreatedBy = (int)reader["CreatedBy"]
                        });
                    }
                }
            }

            return clients;
        }

        // REMOVE THIS METHOD COMPLETELY:
        // Generate unique, readable ClientCode (CL001, CL002, etc.)
        // public string GenerateClientCode() { ... }

        // Alternative method: Get client by ID
        public Client GetClientById(int clientId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT Id, ClientCode, FullName, Email, Phone, Address, CreatedAt, CreatedBy " +
                    "FROM tbl_clients WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", clientId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client
                        {
                            Id = (int)reader["Id"],
                            ClientCode = reader["ClientCode"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Address = reader["Address"]?.ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            CreatedBy = (int)reader["CreatedBy"]
                        };
                    }
                }
            }

            return null;
        }

        // Delete client by ID
        public bool DeleteClient(int clientId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Prevent deleting client with existing loans
                var loanCheck = new SqlCommand("SELECT COUNT(*) FROM tbl_loans WHERE ClientID = @ClientID", connection);
                loanCheck.Parameters.AddWithValue("@ClientID", clientId);
                int loanCount = (int)loanCheck.ExecuteScalar();

                if (loanCount > 0)
                    return false;

                var deleteCommand = new SqlCommand("DELETE FROM tbl_clients WHERE Id = @Id", connection);
                deleteCommand.Parameters.AddWithValue("@Id", clientId);

                return deleteCommand.ExecuteNonQuery() > 0;
            }
        }

        // NEW METHOD: Check if ClientCode already exists
        private bool ClientCodeExists(string clientCode)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM tbl_clients WHERE ClientCode = @ClientCode", connection);
                command.Parameters.AddWithValue("@ClientCode", clientCode);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}