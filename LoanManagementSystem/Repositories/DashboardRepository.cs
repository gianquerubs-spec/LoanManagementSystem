using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace LoanManagementSystem.Repositories
{
    public class DashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository()
        {
           
            _connectionString = ConfigurationManager.ConnectionStrings["LoanDb"].ConnectionString;
        }

        public int GetTotalClients()
        {
            const string sql = "SELECT COUNT(*) FROM dbo.tbl_clients";
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetTotalLoans()
        {
            const string sql = "SELECT COUNT(*) FROM dbo.tbl_loans";
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetActiveLoans()
        {
           
            const string sql = "SELECT COUNT(*) FROM dbo.tbl_loans WHERE Status = 'Active'";
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetPendingApprovals()
        {
           
            const string sql = "SELECT COUNT(*) FROM dbo.tbl_loans WHERE Status = 'Pending'";
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}