using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class Cart:BaseEntity
{
    public int CartId { get; set; }

    public int? CustomerId { get; set; }

    public int? BranchId { get; set; }

    public decimal? Amount { get; set; }

    public decimal? OtherCharge { get; set; }

    public decimal? DicountAmount { get; set; }

    public string? TaxDesc { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? PayAmount { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public string? Latitude { get; set; }

    public string? Longtitude { get; set; }
    public bool? IsActive { get; set; } = null!;
    public virtual Branch? Branch { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<CartOtherCharge> CartOtherCharges { get; set; } = new List<CartOtherCharge>();
    public virtual Customer? Customer { get; set; }
}
