using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models;

public partial class CountryMaster:BaseEntity
{
    [NotMapped]
    public new int Id { get; set; }
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public bool? IsActive { get; set; }
    public DateTime? CreatedDate{ get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<StateMaster> StateMasters { get; set; } = new List<StateMaster>();
}
