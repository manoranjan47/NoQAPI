using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CityMasterDTO
    {

       
        public int? DistrictId { get; set; }

        public string CityName { get; set; } = null!;
    }
}
