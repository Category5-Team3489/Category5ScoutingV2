namespace Category5ScoutingV2.Bot.Commands;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

public class PreModule : BaseCommandModule
{
    [Command("pre")]
    public async Task Pre(CommandContext ctx)
    {
        await ctx.RespondAsync("This is the \"pre\" scouting command!");
    }
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression