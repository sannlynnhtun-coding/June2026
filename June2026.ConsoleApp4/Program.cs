using Dapper;
using June2026.ConsoleApp4;
using June2026.ConsoleApp4.Student;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("--Login--");
Console.Write("Please enter your username: ");  
string username = Console.ReadLine();   
Console.Write("Please enter your password: ");  
string password = Console.ReadLine();

LoginService loginService = new LoginService();
loginService.Login(username, password);


Console.ReadLine();

// dto
// entity
// model

public class StudentDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string FatherName { get; set; }
    public string StudentNo { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string MobileNo { get; set; }
    public bool IsDelete { get; set; }
    public string MotherName { get; set; }
}