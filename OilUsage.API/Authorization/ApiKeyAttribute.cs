using Microsoft.AspNetCore.Mvc;

namespace OilUsage.API.Authorization;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}