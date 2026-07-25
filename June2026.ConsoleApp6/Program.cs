// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using June2026.ConsoleApp6;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

Start:
Console.WriteLine("User List: ");
Console.WriteLine("1. View Users");
Console.WriteLine("2. Add User");
Console.WriteLine("3. Update User");
Console.WriteLine("4. Delete User");
Console.WriteLine("5. Exit");
int number = 0;

Console.Write("Choose an option: ");
string strNumber = Console.ReadLine()!;
number = Convert.ToInt32(strNumber);

if (number == 1)
{
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync("https://localhost:7253/api/user");
    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();
        //Console.WriteLine(content);

        var users = JsonConvert.DeserializeObject<List<UserModel>>(content); // json to object
        int count = 0;
        foreach (var user in users)
        {
            Console.WriteLine($"{++count}: UserId {user.UserId}, Username: {user.Username}");
        }
    }
}
else if (number == 2)
{
    // Add User

    Console.Write("Enter Username: ");
    string username = Console.ReadLine()!;
    Console.Write("Enter Password: ");
    string password = Console.ReadLine()!;

    UserCreateRequestModel requestModel = new UserCreateRequestModel
    {
        Username = username,
        Password = password
    };

    string json = JsonConvert.SerializeObject(requestModel); // object to json  

    HttpClient client = new HttpClient();
    //var content = new StringContent(json, Encoding.UTF8, "application/json");
    var stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
    HttpResponseMessage response = await client.PostAsync("https://localhost:7253/api/user", stringContent);

    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();

        var responseModel = JsonConvert.DeserializeObject<UserCreateResponseModel>(content); // json to object
        Console.WriteLine(responseModel.Message);
    }
}
else if (number == 3)
{
    // Update User

    Console.Write("Enter UserId: ");
    string userId = Console.ReadLine()!;
    Console.Write("Enter Username: ");
    string username = Console.ReadLine()!;
    Console.Write("Enter Password: ");
    string password = Console.ReadLine()!;

    UserPatchRequestModel requestModel = new UserPatchRequestModel
    {
        Username = username,
        Password = password
    };

    string json = JsonConvert.SerializeObject(requestModel); // object to json

    HttpClient client = new HttpClient();
    //var content = new StringContent(json, Encoding.UTF8, "application/json");
    var stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
    HttpResponseMessage response = await client.PatchAsync($"https://localhost:7253/api/user/{userId}", stringContent);

    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();

        var responseModel = JsonConvert.DeserializeObject<UserPatchResponseModel>(content); // json to object
        Console.WriteLine(responseModel.Message);
    }
}
else if (number == 4)
{
    // Delete User
}
else
{
    goto Exit;
}

goto Start;

Exit:
Console.WriteLine("Exiting...");
Console.WriteLine("Press any key to continue...");
Console.ReadKey();