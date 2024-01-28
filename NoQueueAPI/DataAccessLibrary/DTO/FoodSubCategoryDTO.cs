using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class FoodSubCategoryDTO
    {

        public int? FoodCategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string? FoodSubCategoryImage { get; set; }
    }
}
