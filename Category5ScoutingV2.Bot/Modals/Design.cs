namespace Category5ScoutingV2.Bot.Modals;


public static class Design
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Design-modal")
            .WithTitle("Design")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Design-instructions-modal",
                value: "This should be used to answer questions with as much detail possible. Use the Check Label to help remember things said by the other team.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the robots Chassis design.",
                customId: "Design-1-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the robots Arm/Intake design.",
                customId: "Design-2-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the speed, weight, size.",
                customId: "Design-3-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How has the robot changed from last event.",
                customId: "Design-4-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}