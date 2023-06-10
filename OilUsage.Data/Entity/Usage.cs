using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OilUsage.Data.Entity;

public partial class Usage
{
    public string PK => $"ISSUE#{Issue!.IssueGuid}";

    public string SK => $"OIL#{Oil!.OilGuid}";

    [JsonIgnore]
    public int UsageId { get; set; }

    [JsonIgnore]
    public int? IssueId { get; set; }

    [JsonIgnore]
    public int? OilId { get; set; }

    [JsonIgnore]
    public int? UsageTypeId { get; set; }

    public virtual Issue? Issue { get; set; }

    public virtual Oil? Oil { get; set; }

    public virtual UsageType? UsageType { get; set; }
}
