using System;
using System.Collections.Generic;

namespace OilUsage.Data.Entity;

public partial class Issue
{
    public int IssueId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<AdditionalRecomendation> AdditionalRecomendations { get; set; } = new List<AdditionalRecomendation>();

    public virtual ICollection<Usage> Usages { get; set; } = new List<Usage>();
}
