using Amazon;
using OilUsage.Bot.Configuration;
using OilUsage.Bot.Services;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddSystemsManager(source =>
    {
        source.Path = "/oilUsage";
        source.Optional = true;
        source.ReloadAfter = TimeSpan.FromSeconds(30);
        source.AwsOptions = new Amazon.Extensions.NETCore.Setup.AWSOptions()
        {
            Region = RegionEndpoint.USEast1
        };   
    });

builder.Logging.AddLambdaLogger(new LambdaLoggerOptions(builder.Configuration));

// Add services to the container.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddHealthChecks();
var botConfigurationSection = builder.Configuration.GetSection(BotConfiguration.KeyName);
builder.Services.Configure<BotConfiguration>(botConfigurationSection);

var botConfiguration = botConfigurationSection.Get<BotConfiguration>();

builder.Services.AddHttpClient("telegram_bot_client")
    .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
    {
        BotConfiguration? botConfig = botConfiguration;
        TelegramBotClientOptions options = new(botConfig.BotToken);
        return new TelegramBotClient(options, httpClient);
    });

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddHostedService<ConfigureWebhook>();

var app = builder.Build();
app.MapHealthChecks("/healthcheck");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.Run();