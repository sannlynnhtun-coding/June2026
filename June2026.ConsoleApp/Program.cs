// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

try
{
    //int[] myNumbers = { 1, 2, 3 };
    //Console.WriteLine(myNumbers[10]);

    string writeText = "Hello World!";  // Create a text string
    File.WriteAllText("filename.txt", writeText);  // Create a file and write the content of writeText to it

    string readText = File.ReadAllText("filename.txt");  // Read the contents of the file
    Console.WriteLine(readText);  // Output the content

    string plm = "Mg Mg";


    TransferService service = new TransferService();
    string message = service.WalletTransfer("09777777777", "09888888888", 1000);
    Console.WriteLine(message);
    message = service.WalletTransfer("09888888888", "09777777777", 2000);
    Console.WriteLine(message);
    message = service.WalletTransfer("09888888888", "09777777777", 3000);
    Console.WriteLine(message);
    message = service.WalletTransfer("09888888888", "09777777777", 4000);
    Console.WriteLine(message);
    message = service.WalletTransfer("09888888888", "09777777777", 500);
    message = service.WalletTransfer(fromMobileNo: "09888888888", amount: 5000, toMobileNo: "09777777777");
    Console.WriteLine(message);

    Account account = new Account("09777777777");
    account.MobileNo = "09777777777";
    account.Balance = 0;

    Console.WriteLine(account.ToString());

    Account account2 = new Account("09888888888", 10000);
    //account2.MobileNo = "09888888888";
    //account2.Balance = 10000;

    EnumMonth months = EnumMonth.May;
    switch (months)
    {
        case EnumMonth.January:
        case EnumMonth.February:
        case EnumMonth.March:
            Console.WriteLine("First Case");
            break;

        case EnumMonth.April:
        case EnumMonth.May:
        case EnumMonth.June:
            Console.WriteLine("Second Case");
            break;
        case EnumMonth.July:
            Console.WriteLine("3rd Case");
            break;
        case EnumMonth.None:
        default:
            Console.WriteLine("Invalid Case");
            break;
    }

    for (int i = 1; i <= 100; i++)
    {
        Data.Number++;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ToString());
    Console.WriteLine(ex.StackTrace);
}

Console.ReadLine();

static int MyMethod(int x, int y)
{
    return x + y;
}

public static class Data
{
    public static int Number = 0;
}

public class Student
{
    public string Name { get; set; } = default!;
    public int Age { get; set; } = default;
    public decimal Amount { get; set; } = default;
    public DateTime DateOfBirth { get; set; } = default;
}

public enum PaymentType
{
    None,
    KBZPay,
    AYAPay,
    WavePay,
    QRPay,
}

public class TransferService
{
    private static string _fromMobileNo = "09777777777";
    private static string _toMobileNo = "09888888888";
    private static decimal _fromBalance = 10000;
    private static decimal _toBalance = 10000;

    private string message;

    //public string WalletTransfer(string fromMobileNo, string toMobileNo, decimal amount = 1000, string message = "")
    //{

    //}

    /// <summary>
    /// Mobile to Mobile Transfer
    /// </summary>
    /// <param name="fromMobileNo"></param>
    /// <param name="toMobileNo"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public string WalletTransfer(string fromMobileNo, string toMobileNo, decimal amount = 1000)
    {
        Console.WriteLine($"From Mobile No: {fromMobileNo}");
        Console.WriteLine($"To Mobile No: {toMobileNo}");
        Console.WriteLine($"Amount: {amount}");

        //if (fromMobileNo == _fromMobileNo && toMobileNo == _toMobileNo)
        //{
        //    _fromBalance -= amount;
        //    _toBalance += amount;
        //}
        //else if (fromMobileNo == _toMobileNo && toMobileNo == _fromMobileNo)
        //{
        //    _toBalance -= amount;
        //    _fromBalance += amount;
        //}

        Account fromAccount = Database.Accounts.Where(x => x.MobileNo == fromMobileNo).FirstOrDefault();
        Account toAccount = Database.Accounts.Where(x => x.MobileNo == toMobileNo).FirstOrDefault();

        fromAccount.Balance -= amount;
        toAccount.Balance += amount;

        Console.WriteLine($"From Current Balance: {fromAccount.Balance}");
        Console.WriteLine($"To Current Balance: {toAccount.Balance}");
        Console.WriteLine("===============================================");


        return "Wallet transfer successful";
    }
}

public class WalletTransferService : TransferService
{
    public string WallTransferV2(string fromMobileNo, string toMobileNo, decimal amount)
    {
        return WalletTransfer(fromMobileNo, toMobileNo, amount);
    }
}

public class Account
{
    public Account()
    {
        //Balance = 10000;
    }
    public Account(string mobileNo)
    {
        MobileNo = mobileNo;
    }

    public Account(string mobileNo, decimal balance = 10000)
    {
        MobileNo = mobileNo;
        Balance = balance;
    }
    public string Name;

    /// <summary>
    /// Account's Mobile No
    /// </summary>
    public string MobileNo { get; set; }
    //public decimal Balance { get; private set; }

    private decimal balance; // field
    public decimal Balance   // property
    {
        get
        {
            return balance;
        }
        set
        {
            Console.WriteLine(MobileNo + " Old Value: " + balance);
            balance = value;
            Console.WriteLine(MobileNo + " New Value: " + balance);
        }
    }

    //public decimal Balance;

    public override string ToString()
    {
        return "PLM - " + MobileNo;
    }

    //public override string ToString()
    //{
    //    return base.ToString();
    //}
}

public class Database
{
    public static Account[] Accounts = new Account[2]
    {
        new Account()
        {
            Balance = 10000,
            MobileNo = "09777777777"
        },
         new Account()
         {
             Balance = 10000,
             MobileNo = "09888888888"
         }
    };
}

// Abstract class
abstract class Animal
{
    // Abstract method (does not have a body)
    public abstract void animalSound();
    public abstract void Tranfer();
    // Regular method
    public void sleep()
    {
        Console.WriteLine("Zzz");
    }
}

class Pig : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("heehee");
        //throw new NotImplementedException();
    }

    public override void Tranfer()
    {
        throw new NotImplementedException();
    }
}

public interface ICRUDService
{
    void Create();
    void Update();
    void Delete();
    void List(); // Read
    void Edit(); // Get By Id
}

public class OrderService : ICRUDService
{
    public void Create()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }

    public void List()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}

enum EnumMonth
{
    None,
    January,    // 0
    February,   // 1
    March = 6,    // 6
    April,      // 7
    May,        // 8
    June,       // 9
    July        // 10
}