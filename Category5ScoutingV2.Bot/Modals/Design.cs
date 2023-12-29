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
                value: "This should be used to answer qeustions indef with as much detail told. Use the Check Label to help rember things said by the other team.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the robots Chassis design. Why did this team pick this Chassis and its main benefit",
                customId: "Design-1-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the robots Arm/Intake design. How consistent has it proven to be. What does it grab.",
                customId: "Design-2-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the general speed, weight, size,height compared to other robots.",
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