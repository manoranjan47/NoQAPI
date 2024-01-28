using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class CountryMaster
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<StateMaster> StateMasters { get; set; } = new List<StateMaster>();
}
