using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class BranchStaffDTO
    {
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public string? Name { get; set; } = null!;
        public string? PhotoUrl { get; set; } = null!;
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
    }
}
