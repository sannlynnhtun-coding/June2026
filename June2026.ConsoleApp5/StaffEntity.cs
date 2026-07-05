using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp5
{
    [Table("Tbl_Staff")]
    public class StaffEntity
    {
        [Key]
        [Column("StaffId")]
        public int Id { get; set; }

        [Column("StaffName")]
        public string Name { get; set; }
    }
}
