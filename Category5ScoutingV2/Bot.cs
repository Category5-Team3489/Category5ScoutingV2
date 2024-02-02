using Category5ScoutingV2.CommandModules;
using Category5ScoutingV2.Database;
using Category5ScoutingV2.TbaApi;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Category5ScoutingV2;

public static class Bot
{
    private static readonly TimeSpan InteractivityTimeout = TimeSpan.FromMinutes(15);
    private static readonly string[] CommandPrefixes = ["!"];

    public static async Task RunAsync(Db db, Tba tba)
    {
        var token = File.ReadAllText("../../../token.secret");

        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            MinimumLogLevel = LogLevel.Information
        });

        var services = new ServiceCollection()
             .AddSingleton(db)
             .AddSingleton(tba)
             .BuildServiceProvider();

        // Init CommandsNext
        {
            var commandsNext = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = CommandPrefixes,
                Services = services,
                EnableDms = false,
            });

            commandsNext.RegisterCommands<ConfigModule>();
            commandsNext.RegisterCommands<TbaModule>();
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