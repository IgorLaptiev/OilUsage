using System.Text.Json.Nodes;
using CliWrap;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace OilUsage.Bot.Services;

public class TunnelService: BackgroundService
{
    private const string NgrokLocalHttpUrl = "http://127.0.0.1:4040/api/tunnels";
    private readonly IServer _server;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ConfigureWebhook _bothook;
    private readonly ILogger<TunnelService> _logger;

    public TunnelService(
        IServer server,
        IHostApplicationLifetime hostApplicationLifetime,
        ConfigureWebhook bothook,
        ILogger<TunnelService> logger
    )
    {
        _server = server;
        _hostApplicationLifetime = hostApplicationLifetime;
        _bothook = bothook;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await WaitForApplicationStarted();

        var urls = _server.Features.Get<IServerAddressesFeature>()!.Addresses;
        // Use https:// if you authenticated ngrok, otherwise, you can only use http://
        var localUrl = urls.Single(u => u.StartsWith("https://"));

        _logger.LogInformation("Starting ngrok tunnel for {LocalUrl}", localUrl);
        var ngrokTask = StartNgrokTunnel(localUrl, stoppingToken);

        var publicUrl = await GetNgrokPublicUrl();
        _logger.LogInformation("Public ngrok URL: {NgrokPublicUrl}", publicUrl);
        await _bothook.SetWebhook(publicUrl, stoppingToken); 
        await ngrokTask;
        
        _logger.LogInformation("Ngrok tunnel stopped");
    }

    private Task WaitForApplicationStarted()
    {
        var completionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        _hostApplicationLifetime.ApplicationStarted.Register(() => completionSource.TrySetResult());
        return completionSource.Task;
    }

    private CommandTask<CommandResult> StartNgrokTunnel(string localUrl, CancellationToken stoppingToken)
    {
        var ngrokTask = Cli.Wrap("ngrok")
            .WithArguments(args => args
                .Add("http")
                .Add(localUrl)
                .Add("--log")
                .Add("stdout"))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(s => _logger.LogDebug(s)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(s => _logger.LogError(s)))
            .ExecuteAsync(stoppingToken);
        return ngrokTask;
    }

    private async Task<string> GetNgrokPublicUrl()
    {
        using var httpClient = new HttpClient();
        for (var ngrokRetryCount = 0; ngrokRetryCount < 10; ngrokRetryCount++)
        {
            _logger.LogDebug("Get ngrok tunnels attempt: {RetryCount}", ngrokRetryCount + 1);

            try
            {
                var json = await httpClient.GetFromJsonAsync<JsonNode>(NgrokLocalHttpUrl);
                var publicUrl = json["tunnels"].AsArray()
                    .Select(e => e["public_url"].GetValue<string>())
                    .SingleOrDefault(u => u.StartsWith("https://"));
                if (!string.IsNullOrEmpty(publicUrl)) return publicUrl;
            }
            catch
            {
                // ignored
            }

            await Task.Delay(200);
        }

        throw new ApplicationException("Ngrok dashboard did not start in 10 tries");
    }
}