namespace Category5ScoutingV2.Bot.Modals;


public static class MatchByMatch
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("match-by-match_modal")
            .WithTitle("Match-by-match")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "match-by-match-instructions_modal",
                value: "Should be used as a game is going on, This should be a solid replacement for options like Notes apps.\nDO NOT EDIT!",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Match-by-match",
                customId: "match-by-match-modal",
                placeholder: "Type your match-by-match notes here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}