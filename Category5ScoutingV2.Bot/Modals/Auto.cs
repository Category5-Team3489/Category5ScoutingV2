namespace Category5ScoutingV2.Bot.Modals;


public static class Auto
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Auto-modal")
            .WithTitle("Auto")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Auto-instructions-modal",
                value: "Does their robot have an auto, write about what it does and where it goes. Auto consistency and quality should be commented on as well",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Auto starting position,routing, note order.",
                customId: "Auto-start-modal",
                placeholder: "Use the sub-woofer as reference for auto positions. Note order is the order they pick up and score?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Amp, Speaker, Distances Scored, Consistency?",
                customId: "Auto-middle-modal",
                placeholder: "Consistency marks how many times auto worked, penalties, or effect alliance members.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Unique robot strategies/thoughts in auto?",
                customId: "Auto-end-modal",
                placeholder: "Does their auto do anything unique or not? Does their auto do anything strategy related?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Auto NOTES (not game piece)",
                customId: "Auto-end1-modal",
                placeholder: "Add any notes not asked by other boxes and put your opinions. Also any info helpful to drive team.",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}