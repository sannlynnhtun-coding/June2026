using System;
using System.Collections.Generic;

namespace June2026.Domain.Models;

public class SaleCreateRequestModel
{
    public string VoucherNo { get; set; } = null!;
    public DateTime SaleDateTime { get; set; }
    public List<SaleDetailRequestModel> SaleDetails { get; set; } = new();
}

public class SaleDetailRequestModel
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class SaleCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public int SaleId { get; set; }
}
