namespace Category5ScoutingV2.Bot.Modals;


public static class Strategy
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Strategy-modal")
            .WithTitle("Stratrgy")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Strategy-instructions-modal",
                value: "Strategy related information of predictive scouting. Use the information gained to start making a game plan/strategy for the Playoffs. This can also be referred to during Alliance scouting.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Strategy compatibility with other robots.",
                customId: "Strategy-1-modal",
                placeholder: "Do we take different routes reducing traffic or do their auto pick up in different spots etc?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Draft a pitch showing robot compatibility.",
                customId: "Strategy-2-modal",
                placeholder: "Make a pitch demonstrating why we would make good allies. Attempt to convince our allies.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What auto/scoring areas are used in finals?",
                customId: "Strategy-3-modal",
                placeholder: "What auto, scoring paths, routes, strategy, etc are they most likely to use during finals?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Additional info",
                customId: "Strategy-4-modal",
                placeholder: "Post any additional info here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}