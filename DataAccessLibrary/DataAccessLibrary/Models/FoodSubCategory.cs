using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class FoodSubCategory
{
    public int FoodSubCategoryId { get; set; }

    public int? FoodCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? FoodSubCategoryImage { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual FoodCategory? FoodCategory { get; set; }

    public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
}
