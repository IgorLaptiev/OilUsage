namespace OilUsage.API.Settings;

public class ApiSettings
{
    public static string KeyName => "ApiSettings";
    
    public string? ApiKeyHash { get; set; }
}