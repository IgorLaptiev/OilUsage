using System;
using System.Collections.Generic;

namespace OilUsage.Data.Entity;

public partial class Oil
{
    public int OilId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Usage> Usages { get; set; } = new List<Usage>();
}
