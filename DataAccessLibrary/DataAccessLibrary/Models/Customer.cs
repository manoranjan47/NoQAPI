using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int? BranchId { get; set; }

    public string? Name { get; set; }

    public string Mobile { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public string? DeviceNo { get; set; }

    public bool? IsActivated { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
