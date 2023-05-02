using System;
using System.Collections.Generic;

namespace OilUsage.Data.Entity;

public partial class UsageType
{
    public int UsageTypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Usage> Usages { get; set; } = new List<Usage>();
}

