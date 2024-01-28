using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class UserMaster
{
    public int UserId { get; set; }

    public int? BranchId { get; set; }

    public string UserName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string? Email { get; set; }

    public string? Pwd { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<UserProfileLink> UserProfileLinks { get; set; } = new List<UserProfileLink>();
}
