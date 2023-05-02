using OilUsage.Domain.Models;

namespace OilUsage.Domain
{
    public interface IOilUsageService
    {
        Task<List<IssueDto>> GetIssuesAsync();

        Task<List<OilDto>> GetOilsAsync();

        Task<List<OilUsageDto>> GetOilByIssue(UsageType type, String[] issues);
    }
}