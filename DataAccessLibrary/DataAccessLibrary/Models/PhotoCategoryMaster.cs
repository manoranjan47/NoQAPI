using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class PhotoCategoryMaster
{
    public int PhotoCategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<BranchPhoto> BranchPhotos { get; set; } = new List<BranchPhoto>();
}
