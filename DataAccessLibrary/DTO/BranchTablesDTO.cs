using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class BranchTablesDTO
    {
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string? TableName { get; set; } = null!;
        public string? TableQrUrl { get; set; } = null!;
        public int? Capacity { get; set; } = null!;
/*        public int? Price { get; set; } = null!;
*/        public bool? IsActive { get; set; } = null!;
        public bool? IsTakeAway { get; set; } = null!;
        public bool? IsDeleted { get; set; } = null!;
    }
}
