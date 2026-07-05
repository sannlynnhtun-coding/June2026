using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp5
{
    public class June2026AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
                {
                    DataSource = ".", //(local) // server name
                    InitialCatalog = "June2026Db", // database name
                    UserID = "sa",
                    Password = "sasa@123",
                    TrustServerCertificate = true
                };
                optionsBuilder.UseSqlServer(sb.ConnectionString);
            }
        }

        public DbSet<StaffEntity> Staffs { get; set; }
    }
}
