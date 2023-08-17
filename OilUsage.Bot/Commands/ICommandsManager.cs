using Telegram.Bot.Types;

namespace OilUsage.Bot.Commands;

public interface ICommandsManager
{
    Task<bool> ExecuteAsync(Message? message, CancellationToken cancellationToken);
    IEnumerable<BotCommand> GetCommands();
}