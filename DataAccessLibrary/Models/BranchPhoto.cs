using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class BranchPhoto:BaseEntity
{
    public int PhotoId { get; set; }

    public int? BranchId { get; set; }

    public int? PhotoCategoryId { get; set; }

    public string? Photo { get; set; }

    public int? Sequenct { get; set; }

    public bool? IsCoverPhoto { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual PhotoCategoryMaster? PhotoCategory { get; set; }
}
