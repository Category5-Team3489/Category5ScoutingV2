namespace Category5ScoutingV2.Bot.Modals;


public static class Predict
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Predict-modal")
            .WithTitle("Predict")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Predict-instructions-modal",
                value: "This should be used while Alliance’s are playing and and right after Alliances are picked.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Predict Question 1",
                customId: "Predict-1-modal",
                placeholder: "What rank are they going to be? (Opinion)",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Predict Question 2",
                customId: "Predict-2-modal",
                placeholder: "Are they going to be top 8?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Predict Question 3",
                customId: "Predict-3-modal",
                placeholder: "Are they going to be first, secound, or third pick?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Predict Question 4",
                customId: "Predict-4-modal",
                placeholder: "Do we need to convince their team to ally with us?",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}