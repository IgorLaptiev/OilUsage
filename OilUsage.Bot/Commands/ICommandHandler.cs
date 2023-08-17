using Telegram.Bot;
using Telegram.Bot.Types;

namespace OilUsage.Bot.Commands;

public interface ICommandHandler
{
    string Command { get; }

    string Description { get; }
    
    Task ExecuteAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken);
}