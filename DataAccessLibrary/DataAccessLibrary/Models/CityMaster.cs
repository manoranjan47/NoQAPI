using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class CityMaster
{
    public int CityId { get; set; }

    public int? DistrictId { get; set; }

    public string CityName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual DistrictMaster? District { get; set; }
}
