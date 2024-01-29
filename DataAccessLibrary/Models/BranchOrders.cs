using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class BranchOrders : BaseEntity
    {
        [NotMapped]
        public new int Id { get; set; }
        [Key]
        public int OrderId { get; set; }
        public int TransactionId { get; set; }
        public int? CartId { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public string? OrderStatus { get; set; }
        public int StatusId { get; set; }
        public bool? IsActive { get; set; } = null!;
        public int? CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public int? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; } = null!;
        public string? Ipaddress { get; set; } = null!;
        public string? Browser { get; set; } = null!;
        public virtual Cart? Cart { get; set; } = null!;
        public virtual Branch? Branch { get; set; } = null!;
        public virtual Customer? Customer { get; set; }
        public virtual Transaction? Transaction { get; set; }
        public virtual StatusMaster? Status { get; set; }


    }
}
