using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class CartItem:BaseEntity
{
    public int CartItemId { get; set; }

    public int? CartId { get; set; }

    public int? FoodItemId { get; set; }

    public decimal? Price { get; set; }

    public int? Qty { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }


    public virtual Cart? Cart { get; set; }

    public virtual FoodItem? FoodItem { get; set; }
}
