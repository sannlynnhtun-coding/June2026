using System;
using System.Collections.Generic;

namespace June2026.Domain.Models;

public class SaleListRequestModel
{
}

public class SaleListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public List<SaleModel> Sales { get; set; } = null!;
}

public class SaleModel
{
    public int SaleId { get; set; }
    public string VoucherNo { get; set; } = null!;
    public DateTime SaleDateTime { get; set; }
    public decimal TotalAmount { get; set; }
    public List<SaleDetailModel> SaleDetails { get; set; } = new();
}

public class SaleDetailModel
{
    public int SaleDetailId { get; set; }
    public string SaleVoucherNo { get; set; } = null!;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
