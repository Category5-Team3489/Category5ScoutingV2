namespace Category5ScoutingV2.Bot.Modals;


public static class Teleop2
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("TeleOp2-modal")
            .WithTitle("TeleOp-2")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Teleop-2-instructions-modal",
                value: "Write detailed information about the main portion of the game after auto but before robots start interacting with the stage. Use correct terminology when talking about game elements and game pieces. Highlight repeated behavior, routes, and trends.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Do they consistently get penalty points? How?",
                customId: "other-teleop-question-1-modal",
                placeholder: "How effective is the robot is at avoiding or getting penalties. How do the robots get penalties?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Do they deal with traffic well or cause it.",
                customId: "other-teleop-question-2-modal",
                placeholder: "How does the robot deal with traffic using strategy or cause it. Do they cause traffic on purpose?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Is performance affected by physical aspects?",
                customId: "other-teleop-question-22-modal",
                placeholder: "How does the robots unique robot attributes hinder or help their performance?Weight,height,speed.etc",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Helpful and actionable notes for drive team",
                customId: "other-teleop-question-3-modal",
                placeholder: "Notes for drive team as a reference .This should make things like Finals easier. Also use as notes.",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}