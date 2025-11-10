using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LoanManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LoanDb"].ConnectionString;
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT ID, Username, Password, FullName, Role, CreatedAt, IsActive FROM tbl_users WHERE ID = @ID AND IsActive = 1",
                    connection);
                command.Parameters.AddWithValue("@ID", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            ID = (int)reader["ID"],
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Role = reader["Role"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }
            return null;
        }

        public User GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT ID, Username, Password, FullName, Role, CreatedAt, IsActive FROM tbl_users WHERE Username = @Username AND IsActive = 1",
                    connection);
                command.Parameters.AddWithValue("@Username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            ID = (int)reader["ID"],
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Role = reader["Role"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT ID, Username, Password, FullName, Role, CreatedAt, IsActive FROM tbl_users WHERE IsActive = 1 ORDER BY CreatedAt DESC",
                    connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            ID = (int)reader["ID"],
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Role = reader["Role"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsActive = (bool)reader["IsActive"]
                        });
                    }
                }
            }
            return users;
        }

        public bool AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO tbl_users (Username, Password, FullName, Role, CreatedAt, IsActive) VALUES (@Username, @Password, @FullName, @Role, @CreatedAt, @IsActive)",
                    connection);

                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE tbl_users SET Username = @Username, Password = @Password, FullName = @FullName, Role = @Role, IsActive = @IsActive WHERE ID = @ID",
                    connection);

                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                command.Parameters.AddWithValue("@ID", user.ID);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UserExists(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT COUNT(*) FROM tbl_users WHERE Username = @Username",
                    connection);

                command.Parameters.AddWithValue("@Username", username);

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE tbl_users SET IsActive = 0 WHERE ID = @ID",
                    connection);

                command.Parameters.AddWithValue("@ID", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool ChangePassword(int userId, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE tbl_users SET Password = @Password WHERE ID = @ID",
                    connection);

                command.Parameters.AddWithValue("@Password", newPassword);
                command.Parameters.AddWithValue("@ID", userId);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}