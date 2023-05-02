using System;
using System.Collections.Generic;

namespace OilUsage.Data.Entity;

public partial class Usage
{
    public int UsageId { get; set; }

    public string? Usagecol { get; set; }

    public int? IssueId { get; set; }

    public int? OilId { get; set; }

    public int? UsageTypeId { get; set; }

    public virtual Issue? Issue { get; set; }

    public virtual Oil? Oil { get; set; }

    public virtual UsageType? UsageType { get; set; }
}
