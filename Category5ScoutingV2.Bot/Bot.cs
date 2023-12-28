using Category5ScoutingV2.Bot.Commands.Archive;

namespace Category5ScoutingV2.Bot;

public static class Bot
{
    internal static readonly TimeSpan InteractivityTimeout = TimeSpan.FromMinutes(15);
    private static readonly string[] StringPrefixes = ["!"];
    private const ulong DiscordServerId = 1170064715792269373;
    //private const ulong DiscordServerId = 904118883324137552;

    public static async Task RunAsync(Datastore datastore)
    {
        var token = File.ReadAllText("token.secret");

        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            MinimumLogLevel = LogLevel.Information
        });

        var services = new ServiceCollection()
            .AddSingleton(datastore)
            .BuildServiceProvider();

        // Commands
        {
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = StringPrefixes,
                Services = services,
                EnableDms = false,
            });

            commands.RegisterCommands<GeneralModule>();
            commands.RegisterCommands<PreModule>();
        }

        // Slash
        {
            var slash = discord.UseSlashCommands(new SlashCommandsConfiguration()
            {
                Services = services
            });

            slash.RegisterCommands<SlashCommands>(DiscordServerId);
        }

        // Interactivity
        {
            discord.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = InteractivityTimeout
            });
        }

        await discord.ConnectAsync();
    }
}
