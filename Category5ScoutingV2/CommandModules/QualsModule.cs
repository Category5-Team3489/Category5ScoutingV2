using Category5ScoutingV2.Ephemeral.Managers;

namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Description("Commands to scout the qualification matches")]
[Group("quals")]
public class QualsModule : BaseCommandModule
{
    [GroupCommand]
    public async Task Quals(CommandContext ctx, TeamNumber teamNumber) => await Cmd(ctx, async () =>
    {
        await PromptManager.PromptSystem(ctx, SystemManager.Quals, teamNumber);
    });

    [GroupCommand]
    public async Task Quals(CommandContext ctx, TeamNumber teamNumber, int matchNumber) => await Cmd(ctx, async () =>
    {
        MatchKey matchKey = $"{Db.Op(data => data.CurrentEvent.EventKey)}_qm{matchNumber}";
        var matchSimple = await Tba.Get<MatchSimple>($"/match/{matchKey}/simple");
        if (matchSimple.key != matchKey)
        {
            throw new Exception("Match not found at current event.");
        }

        var team = Db.Op(data => data.CurrentEvent.GetTeam(teamNumber));
        if (!matchSimple.alliances.red.team_keys.Contains(team.TeamKey) && !matchSimple.alliances.blue.team_keys.Contains(team.TeamKey))
        {
            throw new Exception($"Team {teamNumber} is not in match {matchKey}.");
        }

        await PromptManager.PromptSystem(ctx, SystemManager.Quals, teamNumber, matchKey);
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression