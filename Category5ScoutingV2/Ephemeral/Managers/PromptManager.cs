using DSharpPlus.Entities;
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

    public static async Task PromptSystem(CommandContext ctx, string systemType, TeamNumber teamNumber)
    {
        System system = CreateSystem(systemType);

        string teamNickname = Db.Op(data => data.CurrentEvent.GetTeam(teamNumber)).Nickname;

        var embedBuilder = new DiscordEmbedBuilder()
            .WithAuthor(name: ctx.Member!.Nickname, iconUrl: ctx.Member!.AvatarUrl)
            .WithColor(system.EmbedColor)
            .WithTitle(system.Type)
            .WithFooter($"Team {teamNumber} - {teamNickname}");

        system.BuildEmbed(embedBuilder);

        // TODO Extract msg builder elsewhere, then use AddSystemButtons()

        var msg = await new DiscordMessageBuilder()
            .AddEmbed(embedBuilder)
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Primary, "Hi", "Hi", emoji: new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":test_tube:")))
            })
            .AddComponents(new DiscordComponent[]
            {
                SystemButton(Quals, system),
                SystemButton(Pit, system),
                SystemButton(Pre, system),
                SystemButton(Finals, system),
            })
            .AddComponents(new DiscordComponent[]
            {
                Button(ButtonStyle.Danger, Close)
            })
            .WithReply(ctx.Message.Id, mention: true)
            .SendAsync(ctx.Channel);

        var interact = ctx.Client.GetInteractivity();

        DateTime start = DateTime.Now;
        while (DateTime.Now - start < PromptTimeout)
        {
            var result = await interact.WaitForButtonAsync(msg, ctx.User);
            if (result.TimedOut || result.Result.Id == Close)
            {
                await msg.DeleteAsync();
                return;
            }

            // TODO Implement system type switching, so you dont have to type in a command to switch each time
            switch (result.Result.Id)
            {
                case Quals:
                case Pit:
                case Pre:
                case Finals:
                    throw new NotImplementedException();
            }

            await result.Result.Interaction.DeferAsync(true);
            await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, new DiscordInteractionResponseBuilder()
               .WithCustomId("test")
               .WithTitle("Test")
            );
        }
    }

    #region Generic Helpers
    private static System CreateSystem(string systemType)
    {
        var result = Process.ExtractOne(systemType, SystemManager.Systems.Keys);
        return SystemManager.Systems[result.Value].Invoke();
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
