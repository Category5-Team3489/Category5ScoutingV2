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
                value: "This should be used to answer qeustions indef with as much detail told. Use the Check Label to help rember things said by the other team.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the auto of this robot.",
                customId: "Comp-1-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How many autos does the robot has and auto positions.",
                customId: "Comp-2-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the robots past sucess or failures.",
                customId: "Comp-3-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What is the robots cycle time.",
                customId: "Comp-4-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}