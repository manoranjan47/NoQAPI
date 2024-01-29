using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class DiscountDTO
    {
        public int DiscountId { get; set; }

        public int? BranchId { get; set; }

        public int? FoodItemId { get; set; }

        public int? FoodCategoryId { get; set; }

        public int? FoodSubCategoryId { get; set; }

        public decimal? AmountLimit { get; set; }

        public string? PromoCode { get; set; }

        public string? DiscountType { get; set; }

        public decimal? Value { get; set; }

        public decimal? MaxDiscountValue { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTill { get; set; }

        public bool? IsActive { get; set; }
    }
}
