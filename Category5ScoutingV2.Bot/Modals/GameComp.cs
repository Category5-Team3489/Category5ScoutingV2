namespace Category5ScoutingV2.Bot.Modals;


public static class GameComposition
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Comp-modal")
            .WithTitle("Comp")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Comp-instructions-modal",
                value: "This should be used to answer questions with as much detail possible. Use the Check Label to help remember things said by the other team.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Amount of autos, function, auto starting spot",
                customId: "Comp-1-modal",
                placeholder: "Use the speaker as reference when talking about auto start. Describe note order in each auto.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the robot’s general cycle time?",
                customId: "Comp-2-modal",
                placeholder: "Cycle time is the time from a robot's scoring to picking up note to scoring. Use comparison.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Do they score in Amp, speaker, or trap?",
                customId: "Comp-3-modal",
                placeholder: "Can they score in more than one. If they can score in multiple but prefer one describe.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Additional info",
                customId: "Comp-4-modal",
                placeholder: "Post Additional info here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}