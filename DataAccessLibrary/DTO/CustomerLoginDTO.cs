using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CustomerLoginDTO
    {
        public string? Name { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public int? BranchId { get; set; }

    }
}
