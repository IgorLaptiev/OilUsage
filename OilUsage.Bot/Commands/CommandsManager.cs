using Telegram.Bot;
using Telegram.Bot.Types;

namespace OilUsage.Bot.Commands;

public class CommandsManager : ICommandsManager
{
    private readonly ITelegramBotClient _client;
    private const string CommandPrefix = "/";
    
    private readonly Dictionary<string, ICommandHandler> _commandHandlers;

    public CommandsManager(ITelegramBotClient client, IEnumerable<ICommandHandler> handlers)
    {
        _client = client;
        _commandHandlers = handlers.ToDictionary(h => h.Command, h => h);
    }

    public async Task<bool> ExecuteAsync(Message? message, CancellationToken cancellationToken)
    {
        if (message?.Text?.StartsWith(CommandPrefix) ?? false)
        {
            if(_commandHandlers.TryGetValue(message?.Text?.Substring(CommandPrefix.Length) ?? string.Empty, out var handler))
            {
                await handler.ExecuteAsync(_client, message, cancellationToken);
                return true;
            }
        }
        return false;
    }

    public IEnumerable<BotCommand> GetCommands()
    {
        return _commandHandlers.Select(commandHandler =>
            new BotCommand
            {
                Command = commandHandler.Value.Command,
                Description = commandHandler.Value.Description
            });
    }
}