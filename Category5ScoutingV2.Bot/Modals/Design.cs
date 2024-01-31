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
                label: "What is the robot’s Chassis design?",
                customId: "Design-1-modal",
                placeholder: "Do they have drive trains like swerve, six wheel, 8 wheel, mecanum, etc. Why did they choose this?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the speed, weight, size, height?",
                customId: "Design-2-modal",
                placeholder: "Describe the more physical attributes of their robot. Use comparisons to make up for non-specific #s",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Robot arm design, shooter, climber,intake.",
                customId: "Design-3-modal",
                placeholder: "Describe these features using correct terminology. If unknown/unique ask what the team calls it.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Aditional info",
                customId: "Design-4-modal",
                placeholder: "Post any additional info here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}