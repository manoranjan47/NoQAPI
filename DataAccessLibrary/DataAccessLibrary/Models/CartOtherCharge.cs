using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class CartOtherCharge
{
    public int OtherChargesId { get; set; }

    public int? CartId { get; set; }

    public string? Desc { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Cart? Cart { get; set; }
}
