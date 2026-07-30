using System.Collections.Generic;

namespace June2026.Domain.Models;

public class ProductListRequestModel
{
}

public class ProductListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public List<ProductModel> Products { get; set; } = null!;
}

public class ProductModel
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
