using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class BranchLoginDTO
    {
        public int? BranchId { get; set; }
        public string Mobile { get; set; } = null!;
    }
}
