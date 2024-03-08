namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Description("Commands to search through scouting data")]
[Group("search")]
public class SearchModule : BaseCommandModule
{
    [GroupCommand]
    public async Task Search(CommandContext ctx) => await Cmd(ctx, async () =>
    {
        throw new NotImplementedException();
        // TODO Paginate
    });

    [GroupCommand]
    public async Task SearchTeam(CommandContext ctx, TeamNumber teamNumber) => await Cmd(ctx, async () =>
    {
        throw new NotImplementedException();
        // TODO
    });

    [GroupCommand]
    public async Task SearchSystem(CommandContext ctx, string systemType) => await Cmd(ctx, async () =>
    {
        throw new NotImplementedException();
        // TODO pop up buttons to select modal type
    });

    [GroupCommand]
    public async Task SearchTeamSystem(CommandContext ctx, TeamNumber teamNumber, string systemType) => await Cmd(ctx, async () =>
    {
        throw new NotImplementedException();
        // TODO pop up buttons to select modal type
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression