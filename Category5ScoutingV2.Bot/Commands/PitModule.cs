using Category5ScoutingV2.Bot.Modals;

namespace Category5ScoutingV2.Bot.Commands;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

public class PitModule : BaseCommandModule
{
    [Command("pit")]
    public async Task Pit(CommandContext ctx, int teamNumber)
    {
        // Buttons: Quick Notes, Teleop 1, Teleop 2, Auto 1

        var msg = await new DiscordMessageBuilder()
            .WithEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Green)
                .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
                .WithTitle("Pit Scouting")
                .WithFooter($"Team Number: {teamNumber}")
            )
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Primary, "Check", "Check"),
                new DiscordButtonComponent(ButtonStyle.Danger, "Design", "Design"),
                new DiscordButtonComponent(ButtonStyle.Success, "Game-Comp", "Game-Comp"),
                new DiscordButtonComponent(ButtonStyle.Secondary, "Social", "Social"),
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
                    case "Check":
                        modal = Check.CreateModal();
                        break;
                    case "Design":
                        modal = Design.CreateModal();
                        break;
                    case "Game-Comp":
                        modal = GameComposition.CreateModal();
                        break;
                    case "Social":
                        modal = Social.CreateModal();
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