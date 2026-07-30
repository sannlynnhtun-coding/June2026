namespace June2026.Domain.Models;

public class ProductDeleteRequestModel
{
    public int ProductId { get; set; }
}

public class ProductDeleteResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
}
