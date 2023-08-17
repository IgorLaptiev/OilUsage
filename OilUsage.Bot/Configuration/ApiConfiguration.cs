namespace OilUsage.Bot.Configuration;

public class ApiSettings
{
    public static readonly string KeyName = "OilUsageAPI";

    public string BasePath { get; init; } = default!;
    public string ApiKey { get; init; } = default!;
}