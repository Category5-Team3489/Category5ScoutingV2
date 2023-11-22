namespace Category5ScoutingV2.Bot;

public static class Bot
{
    internal static readonly TimeSpan InteractivityTimeout = TimeSpan.FromMinutes(15);
    private static readonly string[] StringPrefixes = ["!"];
    //private const ulong DiscordServerId = 1170064715792269373;
    private const ulong DiscordServerId = 904118883324137552;

    private static readonly string Token = File.ReadAllText("token.secret");

    public static async Task RunAsync()
    {
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = Token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            MinimumLogLevel = LogLevel.Information
        });

        var services = new ServiceCollection()
            //.AddSingleton(db)
            .BuildServiceProvider();

        // Commands
        {
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = StringPrefixes,
                Services = services
            });

            commands.RegisterCommands<GeneralModule>();
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
