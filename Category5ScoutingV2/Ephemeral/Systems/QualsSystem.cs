using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems;

public class QualsSystem : System
{
    public override string Type => SystemManager.Quals;
    public override DiscordColor EmbedColor => DiscordColor.DarkGreen;

    public override DiscordInteractionResponseBuilder CreateModal(string modalType)
    {
        throw new NotImplementedException();
    }
}