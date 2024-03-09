using Category5ScoutingV2.Ephemeral.Managers;

namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Description("Commands to scout the playoff matches")]
[Group("finals")]
public class FinalsModule : BaseCommandModule
{
    [GroupCommand]
    public async Task Finals(CommandContext ctx, int allianceNumber) => await Cmd(ctx, async () =>
    {
        if (allianceNumber < 1 || allianceNumber > 8)
        {
            throw new Exception("Alliance number is not in the correct range.");
        }

        await PromptManager.PromptSystem(ctx, SystemManager.Finals, allianceNumber);
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression