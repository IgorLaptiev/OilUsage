using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OilUsage.Data;
using OilUsage.Data.Entity;
using OilUsage.Domain.Models;

namespace OilUsage.Domain
{
    public class OilUsageService : IOilUsageService
    {
        private readonly OildbContext _oilDbContext;

        public OilUsageService(OildbContext oilDbContext)
        {
            _oilDbContext = oilDbContext;
        }

        public async Task<List<IssueDto>> GetIssuesAsync()
        {
            return await _oilDbContext.Issues.Select(o => new IssueDto
            {
                Name = o.Name,
                IssueGuid = o.IssueGuid!.Value
            }).ToListAsync();
        }

        public async Task<List<OilDto>> GetOilsAsync()
        {
            return await _oilDbContext.Oils.Select(o => new OilDto
            {
                Name = o.Name,
                OilId = o.OilId
            }).ToListAsync();
        }

        public async Task<List<OilUsageDto>> GetOilByIssue(Models.UsageType type, String[] issues) 
        {
            var usages = await _oilDbContext.Usages
                .Include(u => u.Issue)
                .Include(u => u.Oil)
                .Where(usage => usage.UsageTypeId == (int)type)
                .Where(usage => issues.Contains(usage.Issue!.Name))
                .ToListAsync();


            return usages
                          .GroupBy(usage => usage.Oil)
                          .Select(group =>
                                 new OilUsageDto
                                 {
                                     Name = group.Key!.Name,
                                     OilId = group.Key!.OilId,
                                     Usage = type.ToString(),
                                     Issues = group.Select(i => i!.Issue!.Name!)
                                 })
                          .OrderByDescending(u => u.Issues!.Count())
                .ToList();
        }
    }
}

