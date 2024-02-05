using System.Text;

namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Group("event")]
public class EventModule : BaseCommandModule
{
    [Command("update")]
    public async Task Update(CommandContext ctx, EventKey eventKey) => await Cmd(ctx, async () =>
    {
        var eventSimple = await Tba.Get<EventSimple>($"/event/{eventKey}/simple");

        if (eventSimple.key != eventKey)
        {
            throw new Exception($"{eventKey} is not a valid event key.");
        }

        var teamSimples = await Tba.Get<List<TeamSimple>>($"/event/{eventKey}/teams/simple");

        Db.Op(data =>
        {
            data.CurrentEventKey = eventKey;

            if (!data.Events.TryGetValue(eventKey, out var @event))
            {
                @event = new(eventKey, eventSimple.year, [], [], []);
                data.Events[eventKey] = @event;
            }

            @event.Teams.Clear();
            @event.Teams.AddRange(teamSimples.Select(t => new Team(t.team_number, t.nickname)));
        });

        await ctx.RespondAsync($"Set the current event as {eventSimple.name}, and loaded all of the attending teams.");
    });

    [Command("teams")]
    public async Task Teams(CommandContext ctx) => await Cmd(ctx, async () =>
    {
        string teams = Db.Op(data =>
        {
            StringBuilder sb = new();
            foreach (var team in data.Events[data.CurrentEventKey].Teams)
            {
                sb.AppendLine($"{team.TeamNumber}: {team.Nickname}");
            }

            return sb.ToString();
        });

        var interactivity = ctx.Client.GetInteractivity();
        var pages = interactivity.GeneratePagesInEmbed(teams, DSharpPlus.Interactivity.Enums.SplitType.Line);

        await ctx.Channel.SendPaginatedMessageAsync(ctx.User, pages);
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression