using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class StateMasterDTO
    {
        public int? CountryId { get; set; }
        public string StateName { get; set; } = null!;
        public string StateCode { get; set; } = null!;
    }
}
