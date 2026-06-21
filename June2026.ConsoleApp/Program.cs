// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//Console.Write("Name: ");
//string input = Console.ReadLine();

//string output = $"Your name is {input}";
//Console.WriteLine(output);

//int age = default;
//decimal amount = default;
//string name = default;
//DateTime dt = default;
//bool isTrue = default;

//age = 9; // 1 // -1, -2

// 1,2,3,0
// transfer
// othertransfer
// otherbanktransfer

// A, B, C
//string value = "D";
//if (value == "A") // car
//{

//}
//else if (value == "B") // boat
//{

//}
//else if (value == "C") // boat
//{

//}
//else // flight
//{
//    throw new Exception("Invalid case");
//}

//Student student;
//student.Name = "Mg Mg";

PaymentType paymentType = default;
if (paymentType == PaymentType.KBZPay)
{
}
else if (paymentType == PaymentType.AYAPay)
{
}
else if (paymentType == PaymentType.WavePay)
{
}
else if (paymentType == PaymentType.QRPay)
{
}
else
{
    throw new Exception("Invalid payment type");
}

switch (paymentType)
{
    case PaymentType.KBZPay:
        break;
    case PaymentType.AYAPay:
        break;
    case PaymentType.WavePay:
        break;
    case PaymentType.QRPay:
        break;
    case PaymentType.None:
    default:
        throw new Exception("tawthar invalid payment type gyi...");
}


Console.ReadLine();

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