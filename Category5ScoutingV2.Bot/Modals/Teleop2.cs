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
                value: "Should be used as a game is going on, This should be a solid replacement for options like Notes apps.\nDO NOT EDIT!",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Other Teleop question 1",
                customId: "other-teleop-question-1-modal",
                placeholder: "Answer 1 goes here",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Other Teleop question 2",
                customId: "other-teleop-question-2-modal",
                placeholder: "Answer 2 goes here",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Other Teleop question 3",
                customId: "other-teleop-question-3-modal",
                placeholder: "Answer 3 goes here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}