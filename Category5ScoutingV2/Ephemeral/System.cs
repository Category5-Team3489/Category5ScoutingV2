using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral;

public abstract class System
{
    public abstract string Type { get; }
    public abstract DiscordColor EmbedColor { get; }

    public virtual void BuildEmbed(DiscordEmbedBuilder embedBuilder) { }

    public abstract DiscordInteractionResponseBuilder CreateModal(string modalType);
}