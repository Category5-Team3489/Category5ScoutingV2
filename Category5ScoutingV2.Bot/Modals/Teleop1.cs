namespace Category5ScoutingV2.Bot.Modals;


public static class Teleop1
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Teleop-modal")
            .WithTitle("TeleOp-1")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Teleopinstructions-modal",
                value: "Should be used as the game is going on, This should be a solid replacement for options like the Notes apps.\nDO NOT EDIT!",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Teleop-start",
                customId: "teleop-start-modal",
                placeholder: "From the very start do they do something differently vs during the game",
                required: true,
                style: TextInputStyle.Paragraph
            ))
             .AddComponents(new TextInputComponent(
                label: "Teleop-middle",
                customId: "Teleop-middle-modal",
                placeholder: "Main game plan; What do they do throughtout the main stage of the game?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
             .AddComponents(new TextInputComponent(
                label: "Teleop-end",
                customId: "Teleop-end-modal",
                placeholder: "TeleOp-end questions go here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}