using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace OilUsage.Bot.Controllers;

[ApiController]
[Route("[controller]")]
public class BotController : ControllerBase
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<BotController> _logger;

    public BotController(ITelegramBotClient botClient, ILogger<BotController> logger)
    {
        _botClient = botClient;
        _logger = logger;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update([FromBody] Update update, CancellationToken cancellationToken)
    {
        await _botClient.SendTextMessageAsync(
            chatId: update.Message!.Chat.Id,
            text: $"Received {update.Message.Text}",
            cancellationToken: cancellationToken);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task SetWebhook(CancellationToken cancellationToken)
    {
        var webhookAddress = $"https://b74e-186-96-169-197.ngrok-free.app/bot/update";
        _logger.LogInformation("Setting webhook: {WebhookAddress}", webhookAddress);
        await _botClient.SetWebhookAsync(
            url: webhookAddress,
            allowedUpdates: Array.Empty<UpdateType>(),
            cancellationToken: cancellationToken);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetWebhookInfo(CancellationToken cancellationToken)
    {
        var info = await _botClient.GetWebhookInfoAsync(cancellationToken);
        return Ok(info);
    }
}