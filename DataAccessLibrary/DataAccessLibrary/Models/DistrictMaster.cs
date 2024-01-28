using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class DistrictMaster
{
    public int DistrictId { get; set; }

    public int? StateId { get; set; }

    public string DistrictName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<CityMaster> CityMasters { get; set; } = new List<CityMaster>();

    public virtual StateMaster? State { get; set; }
}
