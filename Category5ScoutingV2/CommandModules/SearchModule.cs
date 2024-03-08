using System.Text;
using Category5ScoutingV2.Ephemeral;
using DSharpPlus.Entities;
using FuzzySharp;

namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Description("Commands to search through scouting data")]
[Group("search")]
public class SearchModule : BaseCommandModule
{
    //[GroupCommand]
    //public async Task Search(CommandContext ctx) => await Cmd(ctx, async () =>
    //{
    //    throw new NotImplementedException();
    //    // TODO Paginate
    //});

    // TODO require specific system
    [Command("team")]
    public async Task SearchTeam(CommandContext ctx, TeamNumber teamNumber) => await Cmd(ctx, async () =>
    {
        string teamNickname = Db.Op(data => data.CurrentEvent.GetTeam(teamNumber)).Nickname;

        var embedBuilder = new DiscordEmbedBuilder()
            .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
            .WithColor(DiscordColor.CornflowerBlue)
            .WithTitle("Search Results:")
            .WithFooter($"Team {teamNumber} - {teamNickname}");

        Db.Op(data =>
        {
            foreach ((string key, string value) in data.CurrentEvent.TeamData)
            {
                var teamModalKey = TeamModalKey.FromString(key);
                if (teamModalKey.TeamNumber != teamNumber)
                {
                    continue;
                }

                (string systemType, string modalType, string label, bool saves) = Modal.SplitTextInputCustomId(teamModalKey.ModalKey);
                if (!saves)
                {
                    continue;
                }

                embedBuilder.AddField($"{systemType} - {modalType}: {label}", value);
            }
        });

        var msg = await new DiscordMessageBuilder()
            .AddEmbed(embedBuilder)
            .WithReply(ctx.Message.Id, mention: true)
            .SendAsync(ctx.Channel);
    });

    [GroupCommand]
    public async Task SearchSystem(CommandContext ctx, [RemainingText] string searchTerms) => await Cmd(ctx, async () =>
    {
        //await ctx.RespondAsync(searchTerms);

        var embedBuilder = new DiscordEmbedBuilder()
            .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
            .WithColor(DiscordColor.HotPink)
            .WithTitle($"Search results for \"{searchTerms}\"");

        Dictionary<string, string> questions = Db.Op(data =>
        {
            Dictionary<string, string> questions = [];
            foreach ((string key, string value) in data.CurrentEvent.TeamData)
            {
                var teamModalKey = TeamModalKey.FromString(key);
                (string systemType, string modalType, string label, bool saves) = Modal.SplitTextInputCustomId(teamModalKey.ModalKey);
                if (!saves)
                {
                    continue;
                }

                questions.Add($"{teamModalKey.TeamNumber} {systemType} {modalType}: {label}", value);
            }

            foreach ((string key, string value) in data.CurrentEvent.TeamMatchData)
            {
                var teamMatchModalKey = TeamMatchModalKey.FromString(key);
                (string systemType, string modalType, string label, bool saves) = Modal.SplitTextInputCustomId(teamMatchModalKey.ModalKey);
                if (!saves)
                {
                    continue;
                }

                int matchNumberIndex = teamMatchModalKey.MatchKey.LastIndexOf("qm");
                int matchNumber = int.Parse(teamMatchModalKey.MatchKey[(matchNumberIndex + 2)..]);

                questions.Add($"{teamMatchModalKey.TeamNumber} Match {matchNumber} {systemType} {modalType}: {label}", value);
            }

            return questions;
        });

        StringBuilder sb = new();
        var sortedKeys = Process.ExtractSorted(searchTerms, questions.Select(q => q.Key));
        foreach (var sortedKey in sortedKeys)
        {
            var value = questions[sortedKey.Value];
            sb.AppendLine($"{sortedKey.Value}");
            sb.AppendLine($"{value}");
            sb.AppendLine("----------------");
        }

        var interactivity = ctx.Client.GetInteractivity();
        var pages = interactivity.GeneratePagesInEmbed(sb.ToString(), DSharpPlus.Interactivity.Enums.SplitType.Line, embedBuilder);

        await ctx.Channel.SendPaginatedMessageAsync(ctx.User, pages);
    });

    //[GroupCommand]
    //public async Task SearchTeamSystem(CommandContext ctx, TeamNumber teamNumber, string systemType) => await Cmd(ctx, async () =>
    //{
    //    throw new NotImplementedException();
    //    // TODO pop up buttons to select modal type
    //});
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression