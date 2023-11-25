// https://dsharpplus.github.io/DSharpPlus/articles/slash_commands.html

namespace Category5ScoutingV2.Bot.Commands;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
public class SlashCommands : ApplicationCommandModule
{
    //[SlashCommand("time", "A slash command made to test the DSharpPlusSlashCommands library!")]
    //public async Task TestCommand(InteractionContext ctx)
    //{
    //    if (!datastore.HasValue)
    //    {
    //        await ctx.CreateResponseAsync(
    //            InteractionResponseType.ChannelMessageWithSource,
    //            new DiscordInteractionResponseBuilder().WithContent("Datastore not found!")
    //        );
    //        return;
    //    }

    //    string response;

    //    if (datastore.Value.TryRead<string>(Constants.TestKey, out var time))
    //    {
    //        response = time;
    //    }
    //    else
    //    {
    //        response = "Time not found";
    //    }

    //    //await ctx.DeferAsync(true);
    //    await ctx.CreateResponseAsync(
    //        InteractionResponseType.ChannelMessageWithSource,
    //        new DiscordInteractionResponseBuilder().WithContent(response)
    //    );
    //}

    [SlashCommand("test", "A slash command made to test the DSharpPlus Slash Commands extension!")]
    public async Task DelayTestCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

        await Task.Delay(15000);

        await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Thanks for waiting!"));
    }

    //    .AddFile(
    //    "Test.cs",
    //    File.OpenText(@"C:\Users\Connor\Documents\Projects\Category5ScoutingV2\Category5ScoutingV2.Server\Program.cs").BaseStream,
    //    false
    //)
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0060 // Remove unused parameter