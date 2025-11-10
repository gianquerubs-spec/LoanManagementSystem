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
    public class ClientRepository : IClientRepository
    {
        public List<Client> GetAllClients()
        {
            var clients = new List<Client>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT ID, ClientCode, FullName, Email, Phone, Address, CreatedAt, CreatedBy " +
                    "FROM tbl_clients ORDER BY CreatedAt DESC",
                    connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = (int)reader["ID"],
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

        public Client GetClientById(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT ID, ClientCode, FullName, Email, Phone, Address, CreatedAt, CreatedBy " +
                    "FROM tbl_clients WHERE Id = @ID",
                    connection);

                command.Parameters.AddWithValue("@ID", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client
                        {
                            Id = (int)reader["ID"],
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

        public bool AddClient(Client client)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO tbl_clients (ClientCode, FullName, Email, Phone, Address, CreatedBy) " +
                    "VALUES (@ClientCode, @FullName, @Email, @Phone, @Address, @CreatedBy)",
                    connection);

                command.Parameters.AddWithValue("@ClientCode", GenerateClientCode());
                command.Parameters.AddWithValue("@FullName", client.FullName);
                command.Parameters.AddWithValue("@Email", (object)client.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)client.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)client.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", client.CreatedBy);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateClient(Client client)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE tbl_clients SET FullName = @FullName, Email = @Email, Phone = @Phone, Address = @Address WHERE Id = @ID",
                    connection);

                command.Parameters.AddWithValue("@FullName", client.FullName);
                command.Parameters.AddWithValue("@Email", (object)client.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)client.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)client.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@ID", client.Id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteClient(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Check if client has loans
                var checkCommand = new SqlCommand("SELECT COUNT(*) FROM tbl_loans WHERE ClientId = @ClientID", connection);
                checkCommand.Parameters.AddWithValue("@ClientID", id);
                var loanCount = (int)checkCommand.ExecuteScalar();

                if (loanCount > 0) return false; // Can't delete client with existing loans

                var deleteCommand = new SqlCommand("DELETE FROM tbl_clients WHERE Id = @ID", connection);
                deleteCommand.Parameters.AddWithValue("@ID", id);

                return deleteCommand.ExecuteNonQuery() > 0;
            }
        }

        public List<Client> SearchClients(string searchTerm)
        {
            var clients = new List<Client>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT Id, ClientCode, FullName, Email, Phone, Address, CreatedAt, CreatedBy " +
                    "FROM tbl_clients WHERE FullName LIKE @SearchTerm OR Email LIKE @SearchTerm OR Phone LIKE @SearchTerm OR ClientCode LIKE @SearchTerm " +
                    "ORDER BY CreatedAt DESC",
                    connection);

                command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = (int)reader["ID"],
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

        private string GenerateClientCode()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM tbl_clients", connection);
                var count = (int)command.ExecuteScalar();
                return $"CL{(count + 1).ToString().PadLeft(3, '0')}";
            }
        }
    }
}