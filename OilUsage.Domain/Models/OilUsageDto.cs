namespace OilUsage.Domain.Models
{
    public class OilUsageDto
    {

        public int OilId { get; set; }

        public string? Usage { get; set; }

        public string? Name { get; set; }

        public IEnumerable<string>? Issues { get; set; }
    }
}

