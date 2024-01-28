using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class BranchTables:BaseEntity
    {
        [NotMapped]
        public new int Id { get; set; }
        [Key]
        public int TableId { get; set; }
        public int BranchId { get; set; } 
        public string? TableName { get; set; } = null!;
        public string? TableQrPath { get; set; }
        public string? TableQrUrl { get; set; }
        public int? Capacity { get; set; } = null!;
/*        public int? Price { get; set; } = null!;
*/        public bool ? IsActive { get; set; } = null!;
        public bool? IsTakeAway { get; set; } = null!;
        public int? CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public int? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; } = null!;
        public string? Ipaddress { get; set; } = null!;
        public string? Browser { get; set; } = null!;
        public virtual Branch? Branch { get; set; } = null!;

    }
}
