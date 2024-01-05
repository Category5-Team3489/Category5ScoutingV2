namespace Category5ScoutingV2.Bot.Modals;


public static class Final
{
// I named the class "Final" because if I didn't it would conflict with the Task Finals
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("finals-modal")
            .WithTitle("Alliance Info")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Finals-instructions-modal",
                value: "Obtain data from your set alliance. This data should be actionable, recent, concise, and quickly",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Alliance Summary",
                customId: "Finals-1-modal",
                placeholder: "This should be a concise summary of your highlighted info. This should be your most actionable data.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Alliance Strategy",
                customId: "Finals-2-modal",
                placeholder: "Record team strategy based off how alliances worked as a unit.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Robot Qualities",
                customId: "Finals-3-modal",
                placeholder: "Record info based off physical robot attributes and changes. Data should directly help drive team. ",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }
}