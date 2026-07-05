// See https://aka.ms/new-console-template for more information
using June2026.ConsoleApp5;
using June2026.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

Console.WriteLine("Hello, World!");

June2026AppDbContext db = new June2026AppDbContext();
// CRUD
// Read

// LINQ
List<StaffEntity> lst = db.Staffs.ToList();

foreach (var item in lst)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Name);
    Console.WriteLine("----------------");
}


//var staff2 = db.Staffs.Where(x => x.Id == 1000).FirstOrDefault();

//StaffEntity staffEntity = new StaffEntity()
//{
//    Name =  "Soe Bala Win"
//};

//db.Staffs.Add(staffEntity);


//var staff = db.Staffs.Where(x => x.Id == 1).FirstOrDefault();
//if (staff is null)
//{
//    Console.WriteLine("Staff not found.");

//}
//else
//{
//    staff.Name = "Khin Shwe";
//    int result = db.SaveChanges();
//}

StaffEntity? staff3 = db.Staffs.Where(x => x.Id == 1).FirstOrDefault();
if (staff3 is null)
{
    Console.WriteLine("Staff not found.");
    return;

}
db.Staffs.Remove(staff3);
db.SaveChanges();


AppDbContext db2 = new AppDbContext();
var lst2 = db2.TblStaffs.ToList();
var lst3 = db2.TblStudents.ToList();

db2.TblStaffs
    .OrderBy(x => x.StaffName);

db2.TblStudents
    .Where(x => x.IsDelete == false)
    .OrderBy(x => x.StudentName);

Console.ReadLine();