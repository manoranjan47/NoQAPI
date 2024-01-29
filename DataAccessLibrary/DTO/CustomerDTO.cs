using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CustomerDTO
    {
        public int? BranchId { get; set; }
        public string? Name { get; set; }
        public string Mobile { get; set; } = null!;
        public string? Ipaddress { get; set; }
        public string? Browser { get; set; }
        public string? DeviceNo { get; set; }
    }
}
