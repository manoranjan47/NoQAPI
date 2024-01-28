using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class BranchStaff : BaseEntity
    {
        [NotMapped]
        public new int Id { get; set; }
        public string? LoginId { get; set; }
        [Key]
        public int StaffId { get; set; }
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public string? Name { get; set; } = null!;
        public string? PhotoUrl { get; set; }=null!;
        public string? Email { get; set; } = null!;
        public string? Mobile { get; set; } = null!;
        public string? Phone { get; set; } = null!;
        public string? Designation { get; set; } = null!;
        public DateTime? JoinDate { get; set; } = null!;
        public DateTime? LeftDate { get; set; } = null!;
        public string? RoleId { get; set; } = null!;
        public string? RoleName { get; set; } = null!;
        public string? NormalizedName { get; set; } = null!;

        public bool? IsVerified { get; set; } = null!;
        public bool? IsActive { get; set; } = null!;
        public int? CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public int? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; } = null!;
        public string? Ipaddress { get; set; } = null!;
        public string? Browser { get; set; } = null!;
        public virtual Branch? Branch { get; set; } = null!;
        public virtual CompanyMaster? Company { get; set; } = null!;
        public virtual IdentityRole? Role { get; set; } = null!;
        public bool IsRegisteredVerified { get; set; }


    }
}
