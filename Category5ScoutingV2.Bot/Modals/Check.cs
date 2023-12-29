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
                label: "Chassis, Arm design, Intake, Weight, Speed",
                customId: "Check-1-modal",
                placeholder: "Check off Phyical robot design aspects and functions",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Auto scoring,pickup,positions, #",
                customId: "Check-2-modal",
                placeholder: "Check off all the different auto related aspects the robot does",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Offseason, Past event, Fav part robo",
                customId: "Check-3-modal",
                placeholder: "Suggestions of possible more friendly things to talk to teams about.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Cycle, Endgame, Game history, scoring",
                customId: "Check-4-modal",
                placeholder: "Check off game related qeustions that get an idea of teams performence",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}