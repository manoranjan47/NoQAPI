using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class UserProfileLink
{
    public int LinkId { get; set; }

    public int? ProfileId { get; set; }

    public int? UserId { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual ProfileMaster? Profile { get; set; }

    public virtual UserMaster? User { get; set; }
}
