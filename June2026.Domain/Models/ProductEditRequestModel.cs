namespace June2026.Domain.Models;

public class ProductEditRequestModel
{
    public int ProductId { get; set; }
}

public class ProductEditResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public int ProductId { get; set; }
    public string ProductCode { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
