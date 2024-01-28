using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class StatusMaster
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<CompanyMaster> CompanyMasters { get; set; } = new List<CompanyMaster>();
}
