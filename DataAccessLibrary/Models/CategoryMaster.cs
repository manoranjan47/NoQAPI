using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class CategoryMaster : BaseEntity
{
    [System.ComponentModel.DataAnnotations.Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string CategoryCode { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<CompanyMaster> CompanyMasters { get; set; } = new List<CompanyMaster>();
}
