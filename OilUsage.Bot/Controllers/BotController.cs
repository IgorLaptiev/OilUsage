using Microsoft.AspNetCore.Mvc;
using OilUsage.Bot.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace OilUsage.Bot.Controllers;

[ApiController]
[Route("[controller]")]
public class BotController : ControllerBase
{
    private const string CheckMark = "✔ ";
    private readonly ITelegramBotClient _botClient;
    private readonly ICommandsManager _commandsManager;
    private readonly ILogger<BotController> _logger;

    public BotController(ITelegramBotClient botClient, ICommandsManager commandsManager, ILogger<BotController> logger)
    {
        _botClient = botClient;
        _commandsManager = commandsManager;
        _logger = logger;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update([FromBody] Update update, CancellationToken cancellationToken)
    {
        var handler = update switch
        {
            { Message: { } message } => BotMessageReceived(message, cancellationToken),
            { CallbackQuery: { } callbackQuery } => BotOnCallbackQueryReceived(callbackQuery, cancellationToken),
            { }
            _ => UnknownUpdate(update)
        };
        
        await handler;
        return Ok();
    }

    private async Task BotOnCallbackQueryReceived(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Received inline keyboard callback from: {CallbackQueryId}", callbackQuery.Id);

        var button = FindButton(callbackQuery);
        if (button != null)
        {
            await SwitchButton(callbackQuery.Id, button, cancellationToken);
            await _botClient.EditMessageReplyMarkupAsync(
                chatId: callbackQuery.Message!.Chat.Id,
                messageId: callbackQuery.Message!.MessageId,
                replyMarkup: callbackQuery.Message!.ReplyMarkup,
                cancellationToken: cancellationToken);
        }
    }

    private InlineKeyboardButton? FindButton(CallbackQuery callbackQuery)
    {
        foreach (var row in callbackQuery.Message!.ReplyMarkup?.InlineKeyboard ?? new List<IEnumerable<InlineKeyboardButton>>())
        {
            foreach (var item in row)
            {
                if (item.CallbackData == callbackQuery.Data)
                {
                    return item;
                }
            }
        }

        return null;
    }

    private async Task SwitchButton(string id, InlineKeyboardButton item, CancellationToken cancellationToken)
    {
        if (item.Text.StartsWith(CheckMark))
        {
            item.Text = item.Text.Substring(CheckMark.Length);
            await _botClient.AnswerCallbackQueryAsync(
                callbackQueryId: id,
                text: $"Исключено {item.Text}",
                cancellationToken: cancellationToken);
        }
        else
        {
            await _botClient.AnswerCallbackQueryAsync(
                callbackQueryId: id,
                text: $"Выбрано {item.Text}",
                cancellationToken: cancellationToken);
            item.Text = $"{CheckMark}{item.Text}";
        }
    }

    private Task UnknownUpdate(Update update)
    {
        _logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }

    private async Task BotMessageReceived(Message message, CancellationToken cancellationToken)
    {
        if (!await _commandsManager.ExecuteAsync(message, cancellationToken))
        {
            await _botClient.SendTextMessageAsync(
                chatId: message!.Chat.Id,
                text: $"Received {message.Text}",
                cancellationToken: cancellationToken);
        }
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