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
    private readonly DbService _dbService;

    public AdoDotNetService()
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
        sb.DataSource = "."; //(local) // server name
        sb.InitialCatalog = "June2026Db"; // database name
        sb.UserID = "sa";
        sb.Password = "sasa@123";
        sb.TrustServerCertificate = true;
        _dbService = new DbService(sb);
    }

    public void Read()
    {
        string query = @"SELECT *
  FROM [dbo].[Tbl_Student];";
        var dt = _dbService.Query(query);
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
        string query = @"
INSERT INTO dbo.Tbl_Student
(StudentName, FatherName, StudentNo, Email, DateOfBirth, MobileNo, IsDelete)
VALUES
(@StudentName, @FatherName, @StudentNo, @Email, @DateOfBirth, @MobileNo, @IsDelete);";

        var parameters = new List<SqlParameterDto>
    {
        new(){ Name="@StudentName", Value="Aung Kyaw Min"},
        new(){ Name="@FatherName", Value="Kyaw Soe"},
        new(){ Name="@StudentNo", Value="STU001"},
        new(){ Name="@Email", Value="aung.kyaw@example.com"},
        new(){ Name="@DateOfBirth", Value=new DateTime(2001,3,15)},
        new(){ Name="@MobileNo", Value="09123456789"},
        new(){ Name="@IsDelete", Value=false}
    };

        int result = _dbService.Execute(query, parameters);

        Console.WriteLine($"{result} row inserted.");
    }

    public void Update()
    {
        string query = @"
UPDATE dbo.Tbl_Student
SET StudentName=@StudentName,
    FatherName=@FatherName,
    Email=@Email,
    DateOfBirth=@DateOfBirth,
    MobileNo=@MobileNo
WHERE StudentNo=@StudentNo;";

        var parameters = new List<SqlParameterDto>
        {
            new(){ Name="@StudentName", Value="Updated Name"},
            new(){ Name="@FatherName", Value="Updated Father"},
            new(){ Name="@Email", Value="updated@example.com"},
            new(){ Name="@DateOfBirth", Value=new DateTime(2000,1,1)},
            new(){ Name="@MobileNo", Value="09999999999"},
            new(){ Name="@StudentNo", Value="STU001"}
        };

        int result = _dbService.Execute(query, parameters);

        Console.WriteLine($"{result} row updated.");
    }

    public void Delete()
    {
        string query = @"DELETE FROM dbo.Tbl_Student WHERE StudentNo=@StudentNo;";

        var parameters = new List<SqlParameterDto>
        {
            new(){ Name="@StudentNo", Value="STU005"}
        };

        int result = _dbService.Execute(query, parameters);

        Console.WriteLine($"{result} row deleted.");
    }
}
