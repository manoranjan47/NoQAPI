using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class BranchDTO
    {
        public int BranchId { get; set; }

        public int? CompanyId { get; set; }

        public string? BranchName { get; set; } = null!;

        public string? BranchCode { get; set; } = null!;

        public string? Mobile { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? ContactPerson { get; set; } = null!;

        public string? Address { get; set; }

        public int? CityId { get; set; }

        public string? OtherCity { get; set; }

        public int? DistrictId { get; set; }

        public int? StateId { get; set; }

        public int? CountryId { get; set; }

        public int? PinCode { get; set; }

        public string? Latitude { get; set; }

        public string? Longtitude { get; set; }

        public string? MapLocation { get; set; }

        public int? Status { get; set; }

        public int? StatusUpdatedBy { get; set; }

        public DateTime? StatusUpdatedDate { get; set; }

        public string? Remarks { get; set; }

        public bool? IsPrimary { get; set; }

        public bool? IsActive { get; set; }
        public string? Ipaddress { get; set; }

        public string? Browser { get; set; }
    }
}
