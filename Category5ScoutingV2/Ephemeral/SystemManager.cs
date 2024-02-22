using Category5ScoutingV2.Ephemeral.Systems;
using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral;

public static class SystemManager
{
    public const string Quals = nameof(Quals);
    public const string Pit = nameof(Pit);
    public const string Pre = nameof(Pre);
    public const string Finals = nameof(Finals);

    private static readonly TimeSpan PromptTimeout = TimeSpan.FromMinutes(60);
    private const string Close = nameof(Close);

    public static async Task PromptSystemModal(CommandContext ctx, string systemType, string modalType)
    {
        await ctx.RespondAsync("Prompting specific system modals is not yet implemented.");
    }

    public static async Task PromptSystem(CommandContext ctx, string systemType, int teamNumber)
    {
        System system = CreateSystem(systemType);

        var embedBuilder = new DiscordEmbedBuilder()
            .WithAuthor("TODO")
            .WithColor(system.EmbedColor)
            .WithTitle(system.Type)
            .WithFooter($"Team {teamNumber} - INSERT TEAM NAME HERE");

        system.BuildEmbed(embedBuilder);

        var msg = await new DiscordMessageBuilder()
            .AddEmbed(embedBuilder)
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Primary, "Hi", "Hi", emoji: new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":test_tube:")))
            })
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Secondary, Quals, Quals),
                new DiscordButtonComponent(ButtonStyle.Secondary, Pit, Pit),
                new DiscordButtonComponent(ButtonStyle.Secondary, Pre, Pre),
                new DiscordButtonComponent(ButtonStyle.Secondary, Finals, Finals),
            })
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Danger, Close, Close)
            })
            .WithReply(ctx.Message.Id, mention: true)
            .SendAsync(ctx.Channel);

        var interact = ctx.Client.GetInteractivity();

        DateTime start = DateTime.Now;
        while ((DateTime.Now - start) < PromptTimeout)
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
                case "Quals":
                case "Pit":
                case "Pre":
                case "Finals":
                    throw new NotImplementedException();
            }

            await result.Result.Interaction.DeferAsync(true);
            await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, new DiscordInteractionResponseBuilder()
               .WithCustomId("test")
               .WithTitle("Test")
            );
        }
    }

    private static System CreateSystem(string systemType)
    {
        return systemType switch
        {
            Quals => new QualsSystem(),
            Pit => new PitSystem(),
            Pre => new PreSystem(),
            Finals => new FinalsSystem(),
            _ => throw new NotImplementedException($"System type \"{systemType}\" is not implemented."),
        };
    }
}