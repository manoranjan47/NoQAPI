using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public partial class FoodItemDTO
    {

        public int? BranchId { get; set; }

        public int? FoodCategoryId { get; set; }

        public int? FoodSubCategoryId { get; set; }

        public string? FoodName { get; set; } = null!;

        public decimal? Price { get; set; }

        public string? FoodImage { get; set; }

        public string? Description { get; set; }
        public bool? IsNonVeg { get; set; }


    }
}
