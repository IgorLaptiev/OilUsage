using Microsoft.Extensions.Options;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Model;
using OilUsage.Bot.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace OilUsage.Bot.Commands;

public class IssuesCommandHandler : ICommandHandler
{
    private readonly IOptions<ApiSettings> _options;
    
    public string Command => "issues";
    
    public string Description => "Получить список проблем";
    
    public IssuesCommandHandler(IOptions<ApiSettings> options)
    {
        _options = options;
    }
    
    public async Task ExecuteAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        try
        {
            var issues = (await GetIssues(cancellationToken))
                .Select(issue => new[] { InlineKeyboardButton.WithCallbackData(issue.Name, issue.IssueGuid.ToString()) })
                .ToList();
       
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

    private async Task<List<IssueDto>> GetIssues(CancellationToken cancellationToken)
    {
        var config = new API.NetClient.Client.Configuration
        {
            BasePath = _options.Value.BasePath
        };
        config.ApiKey.Add("X-API-Key", _options.Value.ApiKey);

        var api = new IssuesApi(config);
        return await api.ApiIssuesGetAsync(0, cancellationToken);
    }
}