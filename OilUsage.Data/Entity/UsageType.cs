using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OilUsage.Data.Entity;

public partial class UsageType
{
    public int UsageTypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usage> Usages { get; set; } = new List<Usage>();
}

