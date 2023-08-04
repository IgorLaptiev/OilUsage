namespace OilUsage.Bot.Commands;

public static class CommandsRegistrationExtension
{
    public static void RegisterCommands(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICommandHandler, IssuesCommandHandler>();
        serviceCollection.AddScoped<CommandsManager>();
    }
}