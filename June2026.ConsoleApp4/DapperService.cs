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
    internal class DapperService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".", //(local) // server name
            InitialCatalog = "June2026Db", // database name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            List<StudentDto> lst = db.Query<StudentDto>("SELECT * FROM [dbo].[Tbl_Student];").ToList();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id: {item.StudentId}, Name: {item.StudentName}");
            }
        }
        public void Create() { }
        public void Update() { }
        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();

                int result = db.Execute("Delete From Tbl_Student where StudentId = 12");
                Console.WriteLine($"Rows affected: {result}");
            }
        }
    }
}
