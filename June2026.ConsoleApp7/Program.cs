using System;
using System.Collections.Generic;
using June2026.Domain.Features.User;
using June2026.Domain.Features.Product;
using June2026.Domain.Features.Sale;
using June2026.Domain.Models;

var userService = new UserService();
var productService = new ProductService();
var saleService = new SaleService();

MainMenu:
Console.WriteLine("\n=== Main Menu ===");
Console.WriteLine("1. User Management");
Console.WriteLine("2. Product Management");
Console.WriteLine("3. Sale Management");
Console.WriteLine("4. Exit");
Console.Write("Choose an option: ");

string strNumber = Console.ReadLine()!;
if (!int.TryParse(strNumber, out int number))
{
    Console.WriteLine("Invalid option.");
    goto MainMenu;
}

if (number == 1)
{
    goto UserMenu;
}
else if (number == 2)
{
    goto ProductMenu;
}
else if (number == 3)
{
    goto SaleMenu;
}
else if (number == 4)
{
    goto Exit;
}
else
{
    Console.WriteLine("Invalid option.");
    goto MainMenu;
}

#region User Management
UserMenu:
Console.WriteLine("\n--- User Management ---");
Console.WriteLine("1. View Users");
Console.WriteLine("2. Add User");
Console.WriteLine("3. Update User");
Console.WriteLine("4. Delete User");
Console.WriteLine("5. Back to Main Menu");
Console.Write("Choose an option: ");

if (!int.TryParse(Console.ReadLine()!, out int userOpt))
{
    Console.WriteLine("Invalid option.");
    goto UserMenu;
}

if (userOpt == 1)
{
    var response = userService.GetUsers(new UserListRequestModel());
    if (response.IsSuccess)
    {
        int count = 0;
        foreach (var user in response.Users)
        {
            Console.WriteLine($"{++count}: UserId: {user.UserId}, Username: {user.Username}");
        }
    }
    else
    {
        Console.WriteLine($"Error: {response.Message}");
    }
    goto UserMenu;
}
else if (userOpt == 2)
{
    Console.Write("Enter Username: ");
    string username = Console.ReadLine()!;
    Console.Write("Enter Password: ");
    string password = Console.ReadLine()!;

    var response = userService.CreateUser(new UserCreateRequestModel { Username = username, Password = password });
    Console.WriteLine(response.Message);
    if (response.IsSuccess)
    {
        Console.WriteLine($"Created User ID: {response.UserId}");
    }
    goto UserMenu;
}
else if (userOpt == 3)
{
    Console.Write("Enter UserId: ");
    if (!int.TryParse(Console.ReadLine()!, out int userId))
    {
        Console.WriteLine("Invalid UserId.");
        goto UserMenu;
    }
    Console.Write("Enter Username: ");
    string username = Console.ReadLine()!;
    Console.Write("Enter Password: ");
    string password = Console.ReadLine()!;

    var response = userService.PatchUser(new UserPatchRequestModel { UserId = userId, Username = username, Password = password });
    Console.WriteLine(response.Message);
    goto UserMenu;
}
else if (userOpt == 4)
{
    Console.Write("Enter UserId: ");
    if (!int.TryParse(Console.ReadLine()!, out int userId))
    {
        Console.WriteLine("Invalid UserId.");
        goto UserMenu;
    }

    var response = userService.DeleteUser(new UserDeleteRequestModel { UserId = userId });
    Console.WriteLine(response.Message);
    goto UserMenu;
}
else if (userOpt == 5)
{
    goto MainMenu;
}
else
{
    Console.WriteLine("Invalid option.");
    goto UserMenu;
}
#endregion

#region Product Management
ProductMenu:
Console.WriteLine("\n--- Product Management ---");
Console.WriteLine("1. View Products");
Console.WriteLine("2. Add Product");
Console.WriteLine("3. Update Product");
Console.WriteLine("4. Delete Product");
Console.WriteLine("5. Back to Main Menu");
Console.Write("Choose an option: ");

if (!int.TryParse(Console.ReadLine()!, out int prodOpt))
{
    Console.WriteLine("Invalid option.");
    goto ProductMenu;
}

if (prodOpt == 1)
{
    var response = productService.GetProducts();
    if (response.IsSuccess)
    {
        int count = 0;
        foreach (var prod in response.Products)
        {
            Console.WriteLine($"{++count}: ID: {prod.ProductId} | Code: {prod.ProductCode} | Name: {prod.ProductName} | Price: {prod.Price:C} | Qty: {prod.Quantity}");
        }
    }
    else
    {
        Console.WriteLine($"Error: {response.Message}");
    }
    goto ProductMenu;
}
else if (prodOpt == 2)
{
    Console.Write("Enter Product Code: ");
    string code = Console.ReadLine()!;
    Console.Write("Enter Product Name: ");
    string name = Console.ReadLine()!;
    Console.Write("Enter Price: ");
    if (!decimal.TryParse(Console.ReadLine()!, out decimal price))
    {
        Console.WriteLine("Invalid Price.");
        goto ProductMenu;
    }
    Console.Write("Enter Quantity: ");
    if (!int.TryParse(Console.ReadLine()!, out int qty))
    {
        Console.WriteLine("Invalid Quantity.");
        goto ProductMenu;
    }

    var response = productService.CreateProduct(new ProductCreateRequestModel
    {
        ProductCode = code,
        ProductName = name,
        Price = price,
        Quantity = qty
    });
    Console.WriteLine(response.Message);
    goto ProductMenu;
}
else if (prodOpt == 3)
{
    Console.Write("Enter Product ID to Update: ");
    if (!int.TryParse(Console.ReadLine()!, out int prodId))
    {
        Console.WriteLine("Invalid ID.");
        goto ProductMenu;
    }
    Console.Write("Enter New Product Code (leave empty to skip): ");
    string code = Console.ReadLine()!;
    Console.Write("Enter New Product Name (leave empty to skip): ");
    string name = Console.ReadLine()!;
    Console.Write("Enter New Price (leave empty to skip): ");
    string priceInput = Console.ReadLine()!;
    decimal? price = string.IsNullOrEmpty(priceInput) ? null : decimal.Parse(priceInput);
    Console.Write("Enter New Quantity (leave empty to skip): ");
    string qtyInput = Console.ReadLine()!;
    int? qty = string.IsNullOrEmpty(qtyInput) ? null : int.Parse(qtyInput);

    var response = productService.PatchProduct(new ProductPatchRequestModel
    {
        ProductId = prodId,
        ProductCode = code,
        ProductName = name,
        Price = price,
        Quantity = qty
    });
    Console.WriteLine(response.Message);
    goto ProductMenu;
}
else if (prodOpt == 4)
{
    Console.Write("Enter Product ID to Delete: ");
    if (!int.TryParse(Console.ReadLine()!, out int prodId))
    {
        Console.WriteLine("Invalid ID.");
        goto ProductMenu;
    }

    var response = productService.DeleteProduct(new ProductDeleteRequestModel { ProductId = prodId });
    Console.WriteLine(response.Message);
    goto ProductMenu;
}
else if (prodOpt == 5)
{
    goto MainMenu;
}
else
{
    Console.WriteLine("Invalid option.");
    goto ProductMenu;
}
#endregion

#region Sale Management
SaleMenu:
Console.WriteLine("\n--- Sale Management ---");
Console.WriteLine("1. View Sales");
Console.WriteLine("2. Create Sale");
Console.WriteLine("3. Back to Main Menu");
Console.Write("Choose an option: ");

if (!int.TryParse(Console.ReadLine()!, out int saleOpt))
{
    Console.WriteLine("Invalid option.");
    goto SaleMenu;
}

if (saleOpt == 1)
{
    var response = saleService.GetSales();
    if (response.IsSuccess)
    {
        foreach (var sale in response.Sales)
        {
            Console.WriteLine($"Voucher: {sale.VoucherNo} | Date: {sale.SaleDateTime} | Total: {sale.TotalAmount:C}");
            foreach (var detail in sale.SaleDetails)
            {
                Console.WriteLine($"  -> {detail.ProductName} (Qty: {detail.Quantity} x Price: {detail.Price:C})");
            }
        }
    }
    else
    {
        Console.WriteLine($"Error: {response.Message}");
    }
    goto SaleMenu;
}
else if (saleOpt == 2)
{
    Console.Write("Enter Voucher Number: ");
    string voucherNo = Console.ReadLine()!;
    
    var saleDetails = new List<SaleDetailRequestModel>();

    while (true)
    {
        Console.Write("Enter Product ID (or 'done' to complete sale): ");
        string input = Console.ReadLine()!;
        if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
            break;

        if (!int.TryParse(input, out int prodId))
        {
            Console.WriteLine("Invalid ID.");
            continue;
        }

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine()!, out int qty))
        {
            Console.WriteLine("Invalid Quantity.");
            continue;
        }

        saleDetails.Add(new SaleDetailRequestModel { ProductId = prodId, Quantity = qty });
    }

    if (saleDetails.Count == 0)
    {
        Console.WriteLine("No items added to the sale.");
        goto SaleMenu;
    }

    var response = saleService.CreateSale(new SaleCreateRequestModel
    {
        VoucherNo = voucherNo,
        SaleDateTime = DateTime.Now,
        SaleDetails = saleDetails
    });

    Console.WriteLine(response.Message);
    goto SaleMenu;
}
else if (saleOpt == 3)
{
    goto MainMenu;
}
else
{
    Console.WriteLine("Invalid option.");
    goto SaleMenu;
}
#endregion

Exit:
Console.WriteLine("Exiting...");
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
