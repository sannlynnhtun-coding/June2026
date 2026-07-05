using System;
using System.Collections.Generic;

namespace June2026.Database.AppDbContextModels;

public partial class TblProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Qty { get; set; }
}
