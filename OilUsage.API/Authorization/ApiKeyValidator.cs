using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using OilUsage.API.Settings;

namespace OilUsage.API.Authorization;

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly IOptions<ApiSettings> _options;

    public ApiKeyValidator(IOptions<ApiSettings> options)
    {
        _options = options;
    }
    
    public bool IsValid(string apiKey)
    {
        return Sha256(apiKey).Equals(_options.Value.ApiKeyHash);
    }
    
    private static string Sha256(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }
}

