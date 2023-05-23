using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OilUsage.Data.Entity;

public partial class Oil
{ 
    public string PK => $"OIL#";

    public string SK => $"OIL#{OilGuid}";

    [JsonIgnore]
    public int OilId { get; set; }

    public Guid? OilGuid { get; set; }

    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usage> Usages { get; set; } = new List<Usage>();
}
