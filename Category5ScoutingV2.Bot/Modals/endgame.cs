namespace Category5ScoutingV2.Bot.Modals;


public static class Endgame
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Endgame-modal")
            .WithTitle("Endgame")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Endgame-instructions-modal",
                value: "Scouters should determine how consistently each robot completes/ gets to the endgame task.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Endgame Effectiveness",
                customId: "Endgame-effectiveness-modal",
                placeholder: "Determine if the endgame task is completed effectively.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Endgame time",
                customId: "Endgame-time-modal",
                placeholder: "Evaluate transition from Teleop-endgame.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Endgame Comparison",
                customId: "Endgame-comparison-modal",
                placeholder: "Evaluate robot's endgame performence comparatively.",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}