using System;
using June2026.Domain.Features.User;
using June2026.Domain.Models;

var userService = new UserService();

Start:
Console.WriteLine("\nUser List: ");
Console.WriteLine("1. View Users");
Console.WriteLine("2. Add User");
Console.WriteLine("3. Update User");
Console.WriteLine("4. Delete User");
Console.WriteLine("5. Exit");

Console.Write("Choose an option: ");
string strNumber = Console.ReadLine()!;
if (!int.TryParse(strNumber, out int number))
{
    Console.WriteLine("Invalid option.");
    goto Start;
}

if (number == 1)
{
    // View Users
    var response = userService.GetUsers(new UserListRequestModel());
    if (response.IsSuccess)
    {
        int count = 0;
        foreach (var user in response.Users)
        {
            Console.WriteLine($"{++count}: UserId {user.UserId}, Username: {user.Username}");
        }
    }
    else
    {
        Console.WriteLine($"Error: {response.Message}");
    }
}
else if (number == 2)
{
    // Add User
    Console.Write("Enter Username: ");
    string username = Console.ReadLine()!;
    Console.Write("Enter Password: ");
    string password = Console.ReadLine()!;

    var requestModel = new UserCreateRequestModel
    {
        Username = username,
        Password = password
    };

    var response = userService.CreateUser(requestModel);
    Console.WriteLine(response.Message);
    if (response.IsSuccess)
    {
        Console.WriteLine($"Created User ID: {response.UserId}");
    }
}
else if (number == 3)
{
    // Update User
    Console.Write("Enter UserId: ");
    if (!int.TryParse(Console.ReadLine()!, out int userId))
    {
        Console.WriteLine("Invalid UserId.");
        goto Start;
    }
    Console.Write("Enter Username: ");
    string username = Console.ReadLine()!;
    Console.Write("Enter Password: ");
    string password = Console.ReadLine()!;

    var requestModel = new UserPatchRequestModel
    {
        UserId = userId,
        Username = username,
        Password = password
    };

    var response = userService.PatchUser(requestModel);
    Console.WriteLine(response.Message);
}
else if (number == 4)
{
    // Delete User
    Console.Write("Enter UserId: ");
    if (!int.TryParse(Console.ReadLine()!, out int userId))
    {
        Console.WriteLine("Invalid UserId.");
        goto Start;
    }

    var requestModel = new UserDeleteRequestModel
    {
        UserId = userId
    };

    var response = userService.DeleteUser(requestModel);
    Console.WriteLine(response.Message);
}
else if (number == 5)
{
    goto Exit;
}
else
{
    Console.WriteLine("Invalid option.");
    goto Start;
}

goto Start;

Exit:
Console.WriteLine("Exiting...");
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
