using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace June2026.Database.AppDbContextModels;

[Table("Tbl_SaleDetail")]
public partial class TblSaleDetail
{
    [Key]
    public int SaleDetailId { get; set; }

    [Required]
    [MaxLength(50)]
    public string SaleVoucherNo { get; set; } = null!;

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public bool IsDelete { get; set; }
}
