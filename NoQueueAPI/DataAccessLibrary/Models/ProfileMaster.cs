using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class ProfileMaster:BaseEntity
{
    public int ProfileId { get; set; }

    public string ProfileName { get; set; } = null!;

    public string ProfileCode { get; set; } = null!;
    public DateTime? CreatedDate{ get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<UserProfileLink> UserProfileLinks { get; set; } = new List<UserProfileLink>();
}
