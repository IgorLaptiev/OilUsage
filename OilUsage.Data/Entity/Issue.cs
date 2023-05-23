using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace OilUsage.Data.Entity;

public partial class Issue
{
    public string PK => $"ISSUE#";

    public string SK => $"ISSUE#{IssueGuid}";

    [JsonIgnore]
    public int IssueId { get; set; }

    public string? Name { get; set; }

    public Guid? IssueGuid { get; set; }

    [JsonIgnore]
    public virtual ICollection<AdditionalRecomendation> AdditionalRecomendations { get; set; } = new List<AdditionalRecomendation>();

    [JsonIgnore]
    public virtual ICollection<Usage> Usages { get; set; } = new List<Usage>();
}
