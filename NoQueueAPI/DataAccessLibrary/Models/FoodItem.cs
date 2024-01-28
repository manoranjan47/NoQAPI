using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class FoodItem:BaseEntity
{
    public int FoodItemId { get; set; }

    public int? BranchId { get; set; }

    public int? FoodCategoryId { get; set; }

    public int? FoodSubCategoryId { get; set; }

    public string FoodName { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? FoodImage { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }
    public bool? IsNonVeg { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual FoodCategory? FoodCategory { get; set; }

    public virtual FoodSubCategory? FoodSubCategory { get; set; }
}
