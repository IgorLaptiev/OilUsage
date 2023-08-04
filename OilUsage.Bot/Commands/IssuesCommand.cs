using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace OilUsage.Bot.Commands;

public class IssuesCommandHandler : ICommandHandler
{
    public string Command => "issues";
    
    public async Task ExecuteAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        try
        {
            var issues = new[]
            {
                new[] { InlineKeyboardButton.WithCallbackData("btn1", Guid.NewGuid().ToString()) },
                new[] { InlineKeyboardButton.WithCallbackData("btn2", Guid.NewGuid().ToString()) },
                new[] { InlineKeyboardButton.WithCallbackData("btn3", Guid.NewGuid().ToString()) }
            };

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Please select an issue",
                replyMarkup: new InlineKeyboardMarkup(issues), 
                cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}