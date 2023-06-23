using Microsoft.AspNetCore.Mvc;
using OilUsage.API.Authorization;
using OilUsage.Domain;
using OilUsage.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilUsage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiKey]
    public class IssuesController : Controller
    {
        private readonly IOilUsageService oilUsageService;

        public IssuesController(IOilUsageService oilUsageService)
        {
            this.oilUsageService = oilUsageService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<IssueDto>> Get()
        {
            return await oilUsageService.GetIssuesAsync();
        }

        
        [HttpGet("GetOilForInternalUsage")]
        public async Task<IEnumerable<OilUsageDto>> GetOilForInternalUsage(String[] issues)
        {
            return (await oilUsageService.GetOilByIssue(Domain.Models.UsageType.Internal, issues))
                .Where(o => !String.IsNullOrWhiteSpace(o.Name))
                .ToList();
        }

        [HttpGet("GetOilForCareProducts")]
        public async Task<IEnumerable<OilUsageDto>> GetOilForCareProducts(String[] issues)
        {
            return (await oilUsageService.GetOilByIssue(Domain.Models.UsageType.CareProducts, issues))
                .Where(o => !String.IsNullOrWhiteSpace(o.Name))
                .ToList();
        }

        [HttpGet("GetOilForBaseCare")]
        public async Task<IEnumerable<OilUsageDto>> GetOilForBaseCare(String[] issues)
        {
            return (await oilUsageService.GetOilByIssue(Domain.Models.UsageType.BaseCare, issues))
                .Where(o => !String.IsNullOrWhiteSpace(o.Name))
                .ToList();
        }
    }
}

