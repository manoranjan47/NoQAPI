using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CompanyMasterDTO
    {
        public string? CompanyName { get; set; } = null!;
        [Required(ErrorMessage = "Mobile is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid mobile number. Please enter 10 digits.")]
        public string Mobile { get; set; } = null!;
        
        public string? Email { get; set; }
        public int? CategoryId { get; set; }

    }
}
