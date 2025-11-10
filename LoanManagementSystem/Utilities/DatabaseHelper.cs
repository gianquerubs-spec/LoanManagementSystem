using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Utilities
{
    public static class DatabaseHelper
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["LoanDb"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}