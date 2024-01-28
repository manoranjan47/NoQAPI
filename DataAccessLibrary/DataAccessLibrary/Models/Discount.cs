using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class Discount
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

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual FoodCategory? FoodCategory { get; set; }

    public virtual FoodItem? FoodItem { get; set; }

    public virtual FoodSubCategory? FoodSubCategory { get; set; }
}
