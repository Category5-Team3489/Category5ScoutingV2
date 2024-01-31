namespace Category5ScoutingV2.Bot.Modals;


public static class Endgame
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Endgame-modal")
            .WithTitle("Endgame")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Endgame-instructions-modal",
                value: "Scouters should determine how consistently each robot completes/ gets to the endgame task.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How/Do they score trap.Do they need to climb?",
                customId: "Endgame-effectiveness-modal",
                placeholder: "Do they need to climb or score from floor for trap.Consistency?Do they need to be in a certain spot?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "What time do they need to climb/score trap?",
                customId: "Endgame-time-modal",
                placeholder: "How soon do they need to transition from Teleop to endgame? How long does it take to climb/score?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Single/double/triple climb. How consistent?",
                customId: "Endgame-time-modal2",
                placeholder: "How consistently can they climb with multiple robots on average. How do they get past robot's space.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Room taken up on chain? Why a lot or little?",
                customId: "Endgame-comparison-modal",
                placeholder: "How much room do they leave for other robots to get on chain. Do they always hang in middle.",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}