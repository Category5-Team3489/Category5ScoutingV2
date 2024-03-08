namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Description("Commands related to the current event")]
[Group("team")]
public class TeamModule : BaseCommandModule
{
    [Description("Displays information regarding the provided team")]
    [GroupCommand]
    public async Task Team(CommandContext ctx, TeamNumber teamNumber) => await Cmd(ctx, async () =>
    {
        // TODO Provide TBA and tags info
        throw new NotImplementedException();
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression