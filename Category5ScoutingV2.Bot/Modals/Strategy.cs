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
                value: "Instructions (DO NOT EDIT!)",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Stategy Question 1",
                customId: "Strategy-1-modal",
                placeholder: "Do they work well with pit. How do they work?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Stategy Question 2",
                customId: "Strategy-2-modal",
                placeholder: "Robot strategy combatibility with other robots.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Stategy Question 3",
                customId: "Strategy-3-modal",
                placeholder: "Scouters should determine how friendly a team is.?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Stategy Question 4",
                customId: "Strategy-4-modal",
                placeholder: "Determine a Strategy Pitch for how robot compliments ours?",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}