namespace OilUsage.API.Authorization;

public interface IApiKeyValidator
{
    bool IsValid(string apiKey);
}