using System;
using System.Collections.Generic;

namespace OilUsage.Data.Entity;

public partial class AdditionalRecomendation
{
    public int AdditionalRecomendationId { get; set; }

    public string? Description { get; set; }

    public int? IssueId { get; set; }

    public virtual Issue? Issue { get; set; }
}
