using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class StateMaster
{
    public int StateId { get; set; }

    public int? CountryId { get; set; }

    public string StateName { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual CountryMaster? Country { get; set; }

    public virtual ICollection<DistrictMaster> DistrictMasters { get; set; } = new List<DistrictMaster>();
}
