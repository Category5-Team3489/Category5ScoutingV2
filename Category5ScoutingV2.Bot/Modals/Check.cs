namespace Category5ScoutingV2.Bot.Modals;


public static class Check
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Check-modal")
            .WithTitle("Check")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Check-instructions-modal",
                value: "Simple check to remember information while talking to the team. This should be used as a replacement to the notes app.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Chassis/Intake/Shooter/Climber/Speed/Arm/Size",
                customId: "Check-1-modal",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Auto scoring,positions,routes,speaker vs amp",
                customId: "Check-2-modal",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Cycle,Stage task,Game history,scoring,routes",
                customId: "Check-3-modal",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Any new drive/pit team? General experience?",
                customId: "Check-4-modal",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}