using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class FoodCategoryDTO
    {
        public int? BranchId { get; set; }
        public string Name { get; set; } = null!;
        public string? FoodCategoryImage { get; set; }
    }
}
