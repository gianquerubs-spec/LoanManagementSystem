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
    public class ClientService
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

        //Add new client
        public bool AddClient(Client client, int createdByUserId = 1)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                string clientCode = GenerateClientCode();

                var command = new SqlCommand(
                    "INSERT INTO tbl_clients (ClientCode, FullName, Email, Phone, Address, CreatedBy, CreatedAt) " +
                    "VALUES (@ClientCode, @FullName, @Email, @Phone, @Address, @CreatedBy, @CreatedAt)",
                    connection);

                command.Parameters.AddWithValue("@ClientCode", clientCode);
                command.Parameters.AddWithValue("@FullName", client.FullName);
                command.Parameters.AddWithValue("@Email", (object)client.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)client.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)client.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", createdByUserId);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        //Update client info
        public bool UpdateClient(Client client)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "UPDATE tbl_clients SET FullName = @FullName, Email = @Email, Phone = @Phone, Address = @Address " +
                    "WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@FullName", client.FullName);
                command.Parameters.AddWithValue("@Email", (object)client.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)client.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)client.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@Id", client.Id);

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

        // Generate unique, readable ClientCode (CL001, CL002, etc.)
        public string GenerateClientCode()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT ISNULL(MAX(CAST(SUBSTRING(ClientCode, 3, LEN(ClientCode)) AS INT)), 0) " +
                    "FROM tbl_clients WHERE ClientCode LIKE 'CL%'",
                    connection);
                var maxNumber = (int)command.ExecuteScalar();
                return $"CL{(maxNumber + 1).ToString().PadLeft(3, '0')}";
            }
        }

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
    }
}