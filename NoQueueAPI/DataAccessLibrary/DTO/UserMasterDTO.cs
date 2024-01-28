using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class UserMasterDTO
    {
        public int? BranchId { get; set; }

        public string UserName { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string? Email { get; set; }

        public string? Pwd { get; set; }

        public int? CreatedBy { get; set; }
        public string? Ipaddress { get; set; }

        public string? Browser { get; set; }

    }
}
