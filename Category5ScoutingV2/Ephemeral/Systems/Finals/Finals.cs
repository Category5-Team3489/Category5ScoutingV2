
using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems.Finals;

public class Finals(System system) : Modal(system)
{
    public override string Type => "Finals";
    public override int SortingOrder => 1;
    public override ButtonStyle ButtonStyle => ButtonStyle.Success;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Obtain data from your set alliance. This data should be actionable, recent, concise, and quickly");
        AddQuestion(new TextInput()
        {
            Label = "Alliance Summary",
            Placeholder = "This should be a concise summary of your highlighted info. This should be your most actionable data.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Alliance Strategy",
            Placeholder = "Record team strategy based off how alliances worked as a unit.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Robot Qualities",
            Placeholder = "Record info based off physical robot attributes and changes. Data should directly help drive team.",
            Style = TextInputStyle.Paragraph
        });
    }

    public override async Task OnSubmit(CommandContext ctx, TeamNumber teamNumber, IReadOnlyDictionary<string, string> values)
    {
        int allianceNumber = -teamNumber;
        if (allianceNumber < 1 || allianceNumber > 8)
        {
            throw new Exception("Team number is not in alliance number format.");
        }

        var embedBuilder = new DiscordEmbedBuilder()
            .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
            .WithColor(DiscordColor.DarkRed)
            .WithTitle($"Alliance {allianceNumber}")
            .WithFooter($"{DateTime.Now:hh:mm:ss tt}");

        foreach ((ModalKey modalKey, string value) in values)
        {
            (string _, _, string label, bool saves) = Modal.SplitTextInputCustomId(modalKey);
            if (!saves)
            {
                continue;
            }

            embedBuilder.AddField(label, value);
        }

        var channels = (await ctx.Guild.GetChannelsAsync()).ToList();
        var channel = channels.Find(c => c.Name == $"alliance-{allianceNumber}") ?? throw new Exception($"Alliance channel {allianceNumber} not found.");

        await new DiscordMessageBuilder()
            .AddEmbed(embedBuilder)
            .SendAsync(channel);
    }
}
