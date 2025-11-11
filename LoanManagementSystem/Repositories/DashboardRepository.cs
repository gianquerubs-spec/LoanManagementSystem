using LoanManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repositories
{
    public class DashboardRepository
    {
        public int GetTotalClients()
        {
            const string sql = "SELECT COUNT(*) FROM tbl_clients";
            using (var con = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetTotalLoans()
        {
            const string sql = "SELECT COUNT(*) FROM tbl_loans";
            using (var con = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetActiveLoans()
        {
            const string sql = "SELECT COUNT(*) FROM tbl_loans WHERE Status = 'Active'";
            using (var con = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetPendingApprovals()
        {
            const string sql = "SELECT COUNT(*) FROM tbl_loans WHERE Status = 'Pending'";
            using (var con = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}