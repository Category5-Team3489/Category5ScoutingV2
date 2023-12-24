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
                label: "Auto Start",
                customId: "Auto-start-modal",
                placeholder: "Does their robot do anything in begining?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Auto middle",
                customId: "Auto-middle-modal",
                placeholder: "How many things do they go after what things do they go after can they do other things?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Auto End",
                customId: "Auto-end-modal",
                placeholder: "Are there end game auto points (balancing)?",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}