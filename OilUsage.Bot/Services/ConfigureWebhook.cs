using Microsoft.Extensions.Options;
using OilUsage.Bot.Commands;
using OilUsage.Bot.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace OilUsage.Bot.Services;

public class ConfigureWebhook : IHostedService
{
    private readonly ITelegramBotClient _bot;
    private readonly ICommandsManager _commandsManager;
    private readonly BotConfiguration _botConfig;
    private readonly ILogger<ConfigureWebhook> _logger;

    public ConfigureWebhook(ITelegramBotClient bot, IOptions<BotConfiguration> botOptions, ICommandsManager commandsManager, ILogger<ConfigureWebhook> logger)
    {
        _bot = bot;
        _commandsManager = commandsManager;
        _botConfig = botOptions.Value;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await SetWebhook(_botConfig.HostAddress, cancellationToken);
    }

    public async Task SetWebhook(string botHostAddress, CancellationToken cancellationToken)
    {
        var webhookAddress = $"{botHostAddress}{_botConfig.Route}";
        _logger.LogInformation("Setting webhook: {WebhookAddress}", webhookAddress);
        await _bot.SetWebhookAsync(
            url: webhookAddress,
            allowedUpdates: Array.Empty<UpdateType>(),
            secretToken: _botConfig.SecretToken,
            cancellationToken: cancellationToken);
        await _bot.SetMyCommandsAsync(_commandsManager.GetCommands(), cancellationToken: cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Removing webhook");
        await _bot.DeleteWebhookAsync(cancellationToken: cancellationToken);
    }
}