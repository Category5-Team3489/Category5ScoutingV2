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
                value: "Predict what will happen to your individual robot later in the competition. This will help us be prepared for Alliance scouting and Playoffs. Have this completed before Alliance Picking.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Are they going to be in a picking position?",
                customId: "Predict-1-modal",
                placeholder: "This is a spot that allows them to have input on alliance partners. Not just the alliance captain.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Predicted first, second, or third pick.",
                customId: "Predict-2-modal",
                placeholder: "This is the order that the Alliance captain picks each partner. Use robot quality to predict this.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Is convincing them to ally with us needed?",
                customId: "Predict-3-modal",
                placeholder: "We pitch to teams in picking spots we should be allied. Is it valuable for us to pitch to this team?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Additional info",
                customId: "Predict-4-modal",
                placeholder: "Post Additional info here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}