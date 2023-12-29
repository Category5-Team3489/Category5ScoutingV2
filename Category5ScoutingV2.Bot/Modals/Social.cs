namespace Category5ScoutingV2.Bot.Modals;


public static class Social
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("Social-modal")
            .WithTitle("Social")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Social-instructions-modal",
                value: "This should be used to answer questions with as much detail possible. Use the Check Label to help remember things said by the other team.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How has their drive team/pit crew changed.",
                customId: "Social-1-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Their favorite part of their robot.",
                customId: "Social-2-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How had their past season gone?",
                customId: "Social-3-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How friendly and approchable is their team?",
                customId: "Social-4-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}