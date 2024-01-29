using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class FoodCategory : BaseEntity
{
    public int FoodCategoryId { get; set; }

    public int? BranchId { get; set; }

    public string Name { get; set; } = null!;

    public string? FoodCategoryImage { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Discount>? Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<FoodItem>? FoodItems { get; set; } = new List<FoodItem>();

    public virtual ICollection<FoodSubCategory>? FoodSubCategories { get; set; } = new List<FoodSubCategory>();
}
