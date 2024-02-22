namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Group("tba")]
public class TbaModule : BaseCommandModule
{
    [GroupCommand]
    public async Task Get(CommandContext ctx, [RemainingText] string endpoint) => await Cmd(ctx, async () =>
    {
        string json = await Tba.GetString(endpoint);
        json = JsonConvert.SerializeObject(json, Formatting.Indented);
        json = json.Replace("\\n", "\n");
        json = json[1..^1];

        await ctx.RespondAsync(json);
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression