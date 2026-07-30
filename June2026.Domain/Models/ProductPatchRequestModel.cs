namespace June2026.Domain.Models;

public class ProductPatchRequestModel
{
    public int ProductId { get; set; }
    public string? ProductCode { get; set; }
    public string? ProductName { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
}

public class ProductPatchResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
}
