using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp4
{
    internal class LoginService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".", //(local) // server name
            InitialCatalog = "June2026Db", // database name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Login(string username, string password)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                string query = $"select * from Tbl_User where UserName = @UsernameVar and Password = @PasswordVar";
                var user = db.Query(query, new
                {
                    UsernameVar = username,
                    PasswordVar = password
                }).FirstOrDefault();
                if (user != null)
                {
                    Console.WriteLine("Login successful.");
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
        }
    }
}
