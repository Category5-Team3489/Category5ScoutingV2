using System.Reflection;
using DSharpPlus.CommandsNext.Executors;

namespace Category5ScoutingV2;

public static class Bot
{
    private static readonly TimeSpan InteractivityTimeout = TimeSpan.FromMinutes(15);
    private static readonly string[] CommandPrefixes = ["!"];

    public static async Task RunAsync(string token)
    {
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            MinimumLogLevel = LogLevel.Information
        });

        var services = new ServiceCollection()
            .BuildServiceProvider();

        // Init CommandsNext
        {
            var commandsNext = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = CommandPrefixes,
                Services = services,
                EnableDms = false,
                CommandExecutor = new ParallelQueuedCommandExecutor(256),
            });

            commandsNext.RegisterCommands(Assembly.GetExecutingAssembly());
        }

        // Init SlashCommands
        //{
        //    var slashCommands = discord.UseSlashCommands(new SlashCommandsConfiguration()
        //    {
        //        Services = services
        //    });
        //}

        // Init Interactivity
        {
            discord.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = InteractivityTimeout
            });
        }

        await discord.ConnectAsync();
    }
}