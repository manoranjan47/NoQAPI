using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CompanyDTO
    {
        public int CategoryId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ContactPerson { get; set; } = null!;
        public int? Status { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
    }
}
