using Category5ScoutingV2.Bot.Modals;

namespace Category5ScoutingV2.Bot.Commands;

// TODO Make modal buttons persistant


#pragma warning disable CA1822 // Mark members as static
//#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
public class GeneralModule : BaseCommandModule
{
    [Command("quals")]
    public async Task Quals(CommandContext ctx)
    {
        var msg = await new DiscordMessageBuilder()
            .WithEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Green)
                .WithAuthor("AUTHOR")
                .WithTitle("TITLE")
                .WithFooter("FOOTER")
            )
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Primary, "MatchByMatch", "Match-by-match"),
                new DiscordButtonComponent(ButtonStyle.Danger, "Auto1", "Auto 1"),
                new DiscordButtonComponent(ButtonStyle.Danger, "Auto2", "Auto 2"),
                new DiscordButtonComponent(ButtonStyle.Success, "Teleop", "Teleop")
            })
            .WithReply(ctx.Message.Id, true)
            .SendAsync(ctx.Channel);

        var interact = ctx.Client.GetInteractivity();

        while (true)
        {
            var result = await interact.WaitForButtonAsync(msg, ctx.User);
            if (result.TimedOut)
            {
                //await ctx.RespondAsync("Timeout");
                await msg.DeleteAsync();
                break;
            }
            else
            {
                //await ctx.RespondAsync($"You pressed button {result.Result.Id}");

                DiscordInteractionResponseBuilder? modal = null;

                string buttonId = result.Result.Id;
                switch (buttonId)
                {
                    case "MatchByMatch":
                        modal = MatchByMatch.CreateModal();
                        break;
                    case "Auto1":
                        modal = CreateTestingModal();
                        break;
                    case "Auto2":
                        modal = CreateTestingModal();
                        break;
                    case "Teleop":
                        modal = CreateTestingModal();
                        break;
                }

                if (modal != null)
                {
                    await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, modal);
                }
            }
        }

        //await msg.DeleteAsync();
    }

    [Command("test")]
    public async Task Test(CommandContext ctx)
    {
        var msg = await new DiscordMessageBuilder()
    .WithEmbed(new DiscordEmbedBuilder()
        .WithColor(DiscordColor.Green)
        .WithAuthor("AUTHOR")
        .WithTitle("TITLE")
        .WithFooter("FOOTER")
    )
    .AddComponents(new DiscordComponent[]
    {
        new DiscordButtonComponent(ButtonStyle.Primary, "1", "Test")
    })
    .WithReply(ctx.Message.Id, true)
    .SendAsync(ctx.Channel);

        var interact = ctx.Client.GetInteractivity();

        var result = await interact.WaitForButtonAsync(msg, ctx.User);
        if (result.TimedOut)
        {
            await ctx.RespondAsync("Timeout");
        }
        else
        {
            //await ctx.RespondAsync($"You pressed button {result.Result.Id}");

            await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, MatchByMatch.CreateModal());
        }

        await msg.DeleteAsync();
    }

    [Command("tags")]
    public async Task Hello(CommandContext ctx)
    {
        List<DiscordSelectComponentOption> options = Constants.DiscordTeamTags.Select(t => t.ToComponentOption(ctx.Client)).ToList();

        //{
        //    new DiscordSelectComponentOption(
        //        "Label, no description",
        //        "label_no_desc"),

        //    new DiscordSelectComponentOption(
        //        "Label, Description",
        //        "label_with_desc",
        //        "This is a description!"),

        //    new DiscordSelectComponentOption(
        //        "Label, Description, Emoji",
        //        "label_with_desc_emoji",
        //        "This is a description!",
        //        emoji: new DiscordComponentEmoji(854260064906117121)),

        //    new DiscordSelectComponentOption(
        //        "Label, Description, Emoji (Default)",
        //        "label_with_desc_emoji_default",
        //        "This is a description!",
        //        isDefault: true,
        //        new DiscordComponentEmoji(854260064906117121))
        //};

        // Make the dropdown
        var dropdown = new DiscordSelectComponent("dropdown", null, options, false, 1, options.Count);

        var builder = new DiscordMessageBuilder()
    .WithContent("Look, it's a dropdown!")
        .AddComponents(dropdown);

        await ctx.RespondAsync(builder);
    }

    [Command("modal")]
    public async Task Modal(CommandContext ctx)
    {
        var msg = await new DiscordMessageBuilder()
            .WithEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Green)
                .WithAuthor("AUTHOR")
                .WithTitle("TITLE")
                .WithFooter("FOOTER")
            )
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Primary, "1", "LABEL 1"),
                new DiscordButtonComponent(ButtonStyle.Primary, "2", "LABEL 2"),
                new DiscordButtonComponent(ButtonStyle.Primary, "3", "LABEL 3"),
                new DiscordButtonComponent(ButtonStyle.Primary, "4", "LABEL 4")
            })
            .WithReply(ctx.Message.Id, true)
            .SendAsync(ctx.Channel);

        var interact = ctx.Client.GetInteractivity();

        for (int i = 0; i < 10; i++)
        {
            var result = await interact.WaitForButtonAsync(msg, ctx.User);
            if (result.TimedOut)
            {
                await ctx.RespondAsync("Timeout");
            }
            else
            {
                //await ctx.RespondAsync($"You pressed button {result.Result.Id}");

                await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, GetEventCreateModal());
            }
        }

        await msg.DeleteAsync();
    }

    private static DiscordInteractionResponseBuilder CreateTestingModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("auto-1_modal")
            .WithTitle("Auto 1")
            .AddComponents(new TextInputComponent(
                label: "Text box 1",
                customId: "1",
                placeholder: "Type your notes here",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Text box 2",
                customId: "2",
                placeholder: "Type your notes here",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Text box 3",
                customId: "3",
                placeholder: "Type your notes here",
                required: true,
                style: TextInputStyle.Paragraph
            ));
    }


    private static DiscordInteractionResponseBuilder GetEventCreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("event_create_modal")
            .WithTitle("New Event")
            .AddComponents(new TextInputComponent(
                label: "Title",
                customId: "event_create_modal_title",
                placeholder: "Ex: \"Meeting\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 0,
                max_length: 70
            ))
            .AddComponents(new TextInputComponent(
                label: "Info (Optional)",
                customId: "event_create_modal_info",
                placeholder: "Ex: \"BRING SAFETY GLASSES!!!\"",
                required: false,
                style: TextInputStyle.Paragraph,
                min_length: 0,
                max_length: 280
            ))
            .AddComponents(new TextInputComponent(
                label: "Date (M/D/YYYY ONLY)",
                customId: "event_create_modal_date",
                placeholder: "Ex: \"12/25/2022\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 8,
                max_length: 10
            ))
            .AddComponents(new TextInputComponent(
                label: "Start Time (H:MM am/pm ONLY)",
                customId: "event_create_modal_start_time",
                placeholder: "Ex: \"9:00am\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 6,
                max_length: 7
            ))
            .AddComponents(new TextInputComponent(
                label: "End Time (H:MM am/pm ONLY)",
                customId: "event_create_modal_end_time",
                placeholder: "Ex: \"4:00pm\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 6,
                max_length: 7
            )
        );
    }
}
//#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static