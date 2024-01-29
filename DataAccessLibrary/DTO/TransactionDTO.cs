using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class TransactionDTO
    {
        public string? TransactionNo { get; set; }
        public int? CartId { get; set; }
        public int? CustomerId { get; set; }
        public int BranchId { get; set; }
        public decimal? Amount { get; set; }
        public string? Mode { get; set; }
        public string? Method { get; set; }
        public string? Status { get; set; }
        public string? TransactionResponse { get; set; }
    }
}
