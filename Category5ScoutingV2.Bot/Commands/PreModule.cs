﻿using Category5ScoutingV2.Bot.Modals;

namespace Category5ScoutingV2.Bot.Commands;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

public class PreModule : BaseCommandModule
{
    [Command("pre")]
    public async Task Pre(CommandContext ctx, int teamNumber)
    {
        await ctx.RespondAsync($"This is the \"pre\" scouting command! You entered this team number: {teamNumber}!");

        var msg = await new DiscordMessageBuilder()
            .WithEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Green)
                .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
                .WithTitle("Predictive Scouting Data")
                .WithFooter($"Team Number: {teamNumber}")
            )
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Success, "Predict", "Predict"),
                new DiscordButtonComponent(ButtonStyle.Danger, "Strategy", "Strategy"),

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
                    case "Predict":
                        modal = Predict.CreateModal();
                        break;
                    case "Strategy":
                        modal = Strategy.CreateModal();
                        break;
                }

                if (modal != null)
                {
                    await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, modal);
                }
            }
        }
    }
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression