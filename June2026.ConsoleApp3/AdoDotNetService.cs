using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp3;

internal class AdoDotNetService
{
    public void Read()
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
        sb.DataSource = "."; //(local) // server name
        sb.InitialCatalog = "June2026Db"; // database name
        sb.UserID = "sa";
        sb.Password = "sasa@123";
        sb.TrustServerCertificate = true;

        Console.WriteLine($"connection stirng: {sb.ConnectionString}");

        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        Console.WriteLine("Connection opening...");
        connection.Open();
        Console.WriteLine("Connection opened.");

        string query = @"SELECT *
  FROM [dbo].[Tbl_Student];";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        //DataSet ds = new DataSet();
        //adapter.Fill(ds);

        Console.WriteLine("Connection closing...");
        connection.Close();
        Console.WriteLine("Connection closed.");

        // DataSet
        // DataTable
        // DataRow
        // DataColumn

        // 12-11-2025
        // 2025-11-12

        foreach (DataRow item in dt.Rows)
        {
            Console.WriteLine(item["StudentId"]);
            Console.WriteLine(item["StudentName"]);
            Console.WriteLine(item["FatherName"]);
            DateTime dtDob = Convert.ToDateTime(item["DateOfBirth"]);
            Console.WriteLine(dtDob.ToString("dd-MMM-yyyy"));
        }
    }

    public void Create()
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
        sb.DataSource = "."; //(local) // server name
        sb.InitialCatalog = "June2026Db"; // database name
        sb.UserID = "sa";
        sb.Password = "sasa@123";
        sb.TrustServerCertificate = true;

        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();

        string query = @"INSERT INTO [dbo].[Tbl_Student]
           ([StudentName]
           ,[FatherName]
           ,[StudentNo]
           ,[Email]
           ,[DateOfBirth]
           ,[MobileNo]
           ,[IsDelete])
VALUES
('Aung Kyaw Min', 'Kyaw Soe', 'STU001', 'aung.kyaw@example.com', '2001-03-15', '09123456789', 0),
('Su Su Hlaing', 'Win Naing', 'STU002', 'susu.hlaing@example.com', '2002-07-22', '09234567890', 0),
('Zaw Lin Htet', 'Than Tun', 'STU003', 'zaw.lin@example.com', '2000-11-08', '09345678901', 0),
('Ei Ei Mon', 'Aung Myint', 'STU004', 'eiei.mon@example.com', '2001-01-30', '09456789012', 0),
('Htet Naing Oo', 'Tin Maung', 'STU005', 'htet.naing@example.com', '2003-09-12', '09567890123', 0);";
        SqlCommand cmd = new SqlCommand(query, connection);
        int result = cmd.ExecuteNonQuery();

        connection.Close();
    }

    public void Update()
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
        sb.DataSource = "."; //(local) // server name
        sb.InitialCatalog = "June2026Db"; // database name
        sb.UserID = "sa";
        sb.Password = "sasa@123";
        sb.TrustServerCertificate = true;

        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();

        string query = @"UPDATE [dbo].[Tbl_Student]
SET
    StudentName = 'Aung Aung',
    FatherName = 'U Kyaw Win',
    Email = 'aungaung@example.com',
    DateOfBirth = '2001-05-20',
    MobileNo = '09987654321'
WHERE StudentNo = 'STU001';";
        SqlCommand cmd = new SqlCommand(query, connection);
        int result = cmd.ExecuteNonQuery();

        connection.Close();
    }

    public void Delete()
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
        sb.DataSource = "."; //(local) // server name
        sb.InitialCatalog = "June2026Db"; // database name
        sb.UserID = "sa";
        sb.Password = "sasa@123";
        sb.TrustServerCertificate = true;

        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();

        string query = @"DELETE FROM [dbo].[Tbl_Student]
WHERE StudentNo = 'STU005';";
        SqlCommand cmd = new SqlCommand(query, connection);
        int result = cmd.ExecuteNonQuery();

        connection.Close();
    }
}
