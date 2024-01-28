using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CartDTO
    {
        public int? CustomerId { get; set; }

        public int? BranchId { get; set; }

        public decimal? Amount { get; set; }

        public decimal? OtherCharge { get; set; }

        public decimal? DicountAmount { get; set; }

        public string? TaxDesc { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? PayAmount { get; set; }
 
        public string? Latitude { get; set; }

        public string? Longtitude { get; set; }
    }
}
