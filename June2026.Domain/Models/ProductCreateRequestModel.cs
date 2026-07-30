namespace June2026.Domain.Models;

public class ProductCreateRequestModel
{
    public string ProductCode { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class ProductCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public int ProductId { get; set; }
}
