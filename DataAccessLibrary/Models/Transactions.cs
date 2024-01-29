using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Transaction : BaseEntity
    {
        [NotMapped]
        public new int Id { get; set; }
        [Key]
        public int TransactionId { get; set; }
        public string? TransactionNo { get; set; }
        public int? CartId { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("Branch")]
        public int? BranchId { get; set; }
        public decimal? Amount { get; set; }
        public string? Mode { get; set;}
        public string? Method { get; set; }
        public string? Status { get; set; }
        public string? TransactionResponse { get; set; }
        public bool? IsActive { get; set; } = null!;
        public int? CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public int? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; } = null!;
        public string? Ipaddress { get; set; } = null!;
        public string? Browser { get; set; } = null!;
        public virtual Cart? Cart { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual Customer? Customer { get; set; }

    }
}
