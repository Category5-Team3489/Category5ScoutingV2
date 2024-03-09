using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using FuzzySharp;
using static Category5ScoutingV2.Ephemeral.Managers.SystemManager;

namespace Category5ScoutingV2.Ephemeral.Managers;

public static class PromptManager
{
    public static async Task PromptSystemModal(CommandContext ctx, string systemType, string modalType)
    {
        await Task.Delay(0);
        throw new NotImplementedException();
    }

    public static async Task PromptSystem(CommandContext ctx, string systemType, TeamNumber teamNumber, MatchKey? matchKey = null)
    {
        System system = CreateSystem(systemType);

        var embedBuilder = new DiscordEmbedBuilder();
        if (systemType == Finals)
        {
            embedBuilder
                .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
                .WithColor(system.EmbedColor)
                .WithTitle(system.Type)
                .WithFooter($"Alliance {teamNumber}");

            teamNumber = -teamNumber;
        }
        else
        {
            string teamNickname = Db.Op(data => data.CurrentEvent.GetTeam(teamNumber)).Nickname;

            embedBuilder
                .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
                .WithColor(system.EmbedColor)
                .WithTitle(system.Type)
                .WithFooter($"Team {teamNumber} - {teamNickname}");
        }

        if (matchKey != null)
        {
            embedBuilder.WithDescription(matchKey);
        }

        var msgBuilder = new DiscordMessageBuilder()
            .AddEmbed(embedBuilder);

        AddModalButtons(msgBuilder, system, matchKey);

        // TODO Extract msg builder elsewhere, then use AddSystemButtons()

        var msg = await msgBuilder
            //.AddComponents(new DiscordComponent[]
            //{
            //    new DiscordButtonComponent(ButtonStyle.Primary, "Hi", "Hi", emoji: new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":test_tube:")))
            //})
            //.AddComponents(new DiscordComponent[]
            //{
            //    SystemButton(Quals, system),
            //    SystemButton(Pit, system),
            //    SystemButton(Pre, system),
            //    SystemButton(Finals, system),
            //})
            //.AddComponents(new DiscordComponent[]
            //{
            //    Button(ButtonStyle.Danger, Close)
            //})
            .WithReply(ctx.Message.Id, mention: true)
            .SendAsync(ctx.Channel);

        var interact = ctx.Client.GetInteractivity();

        //DateTime start = DateTime.Now;
        //Task<InteractivityResult<ComponentInteractionCreateEventArgs>>? overrideButtonInteractTask = null;
        //while (DateTime.Now - start < PromptTimeout)
        {
            InteractivityResult<ComponentInteractionCreateEventArgs> result;
            //if (overrideButtonInteractTask == null)
            //{
            result = await interact.WaitForButtonAsync(msg, ctx.User);
            //}
            //else
            //{
            //    result = await overrideButtonInteractTask;
            //    overrideButtonInteractTask = null;
            //}

            if (result.TimedOut || result.Result.Id == Close)
            {
                await msg.DeleteAsync();
                return;
            }

            var resultId = result.Result.Id;

            // TODO Implement system type switching, so you dont have to type in a command to switch each time
            //switch (resultId)
            //{
            //    case Quals:
            //    case Pit:
            //    case Pre:
            //    case Finals:
            //        throw new NotImplementedException();
            //}

            //await result.Result.Interaction.DeferAsync(true);

            var modal = system.Modals.Find(m => m.Type == resultId)!;
            DiscordInteractionResponseBuilder modalBuilder = modal.Get(teamNumber, matchKey);

            await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, modalBuilder);

            var modalInteractTask = interact.WaitForModalAsync(modalBuilder.CustomId, ctx.User, TimeSpan.FromMinutes(15));
            //var buttonInteractTask = interact.WaitForButtonAsync(msg, ctx.User);

            //await Task.WhenAny(modalInteractTask, buttonInteractTask);

            //if (buttonInteractTask.IsCompleted)
            //{
            //    overrideButtonInteractTask = buttonInteractTask;
            //    continue;
            //}

            var modifiedMsgBuilder = new DiscordMessageBuilder()
                .AddEmbed(embedBuilder);

            await msg.ModifyAsync(modifiedMsgBuilder);

            var modalInteract = await modalInteractTask;

            if (modalInteract.TimedOut)
            {
                await msg.DeleteAsync();
                return;
            }

            foreach ((ModalKey modalKey, string value) in modalInteract.Result.Values)
            {
                (string _, string modalType, string label, bool saves) = Modal.SplitTextInputCustomId(modalKey);
                if (!saves)
                {
                    continue;
                }

                if (matchKey == null)
                {
                    Db.Op(data => data.CurrentEvent.TeamData[new TeamModalKey(teamNumber, modalKey).ToString()] = value);
                }
                else
                {
                    Db.Op(data => data.CurrentEvent.TeamMatchData[new TeamMatchModalKey(teamNumber, matchKey, modalKey).ToString()] = value);
                }
            }

            await modal.OnSubmit(ctx, teamNumber, modalInteract.Result.Values);

            await modalInteract.Result.Interaction.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                    .WithContent("Submitted successfully!")
            );

            //await msg.DeleteAsync();
        }
    }

    #region Generic Helpers
    private static System CreateSystem(string systemType)
    {
        var result = Process.ExtractOne(systemType, SystemManager.Systems.Keys);
        return SystemManager.Systems[result.Value].Invoke();
    }

    private static void AddModalButtons(DiscordMessageBuilder builder, System currentSystem, MatchKey? matchKey = null)
    {
        List<DiscordButtonComponent> buttons = [];
        List<Modal> modals;
        if (matchKey == null)
        {
            modals = currentSystem.Modals.OrderBy(m => m.SortingOrder).Where(m => !m.IsMatchModal).ToList();
        }
        else
        {
            modals = currentSystem.Modals.OrderBy(m => m.SortingOrder).Where(m => m.IsMatchModal).ToList();
        }

        foreach (var modal in modals)
        {
            buttons.Add(Button(modal.ButtonStyle, modal.Type));

            if (buttons.Count == 5)
            {
                builder.AddComponents(buttons);
                buttons = [];
            }
        }

        if (buttons.Count > 0)
        {
            builder.AddComponents(buttons);
        }
    }

    private static void AddSystemButtons(DiscordMessageBuilder builder, System currentSystem)
    {
        List<DiscordButtonComponent> buttons = [];
        foreach (string systemType in SystemManager.Systems.Keys)
        {
            buttons.Add(SystemButton(systemType, currentSystem));

            if (buttons.Count == 5)
            {
                builder.AddComponents(buttons);
                buttons = [];
            }
        }

        if (buttons.Count > 0)
        {
            builder.AddComponents(buttons);
        }
    }

    private static DiscordButtonComponent SystemButton(string systemType, System currentSystem)
    {
        const ButtonStyle Style = ButtonStyle.Secondary;

        if (systemType == currentSystem.Type)
        {
            return new DiscordButtonComponent(Style, systemType, systemType, true);
        }

        return Button(Style, systemType);
    }
    private static DiscordButtonComponent Button(ButtonStyle style, string label) => new(style, label, label);
    #endregion
}
