using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace June2026.Database.AppDbContextModels;

[Table("Tbl_Sale")]
public partial class TblSale
{
    [Key]
    public int SaleId { get; set; }

    [Required]
    [MaxLength(50)]
    public string VoucherNo { get; set; } = null!;

    public DateTime SaleDateTime { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public bool IsDelete { get; set; }
}
