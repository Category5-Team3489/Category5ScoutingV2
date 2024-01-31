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
                label: "How is their drive team/pit crew? Changes?",
                customId: "Social-1-modal",
                placeholder: "Mark how their team has changed over seasons. How much previous drive practice was obtained.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Is their team fun,approachable,sociable?",
                customId: "Social-2-modal",
                placeholder: "Important when picking if we want to pitch. Do they have a good relationship with us?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Notes",
                customId: "Social-3-modal",
                placeholder: "Anything socially important or that could help drive team. Anything that can be used in a pitch.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "additional info",
                customId: "Social-4-modal",
                placeholder: "Post additional info here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}