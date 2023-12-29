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
                value: "This should be used to answer qeustions indef with as much detail told. Use the Check Label to help rember things said by the other team.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How has their drive team or pit crew changed from last year.",
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
                label: "How did their past season go? Was it sucessful or not sucessful in their eyes?",
                customId: "Social-3-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "How friendly is their team? Are they approchable and friendly in your eyes?",
                customId: "Social-4-modal",
                placeholder: "Blank",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}