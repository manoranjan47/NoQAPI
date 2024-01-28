using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class BankDetailDTO
    {
        public int? BranchId { get; set; }
        public string BankName { get; set; } = null!;
        public string? Ifsccode { get; set; } = null!;

        public string? AccountNo { get; set; } = null!;

        public string? AccountHolderName { get; set; } = null!;

        public string? BankBranch { get; set; }

        public bool? IsDefaultAccount { get; set; }

        public bool? IsVerified { get; set; }

        public bool? IsActive { get; set; }
    }
}
