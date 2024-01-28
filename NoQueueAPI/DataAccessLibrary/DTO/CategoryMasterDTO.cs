using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CategoryMasterDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string CategoryCode { get; set; } = null!;
    }
}
