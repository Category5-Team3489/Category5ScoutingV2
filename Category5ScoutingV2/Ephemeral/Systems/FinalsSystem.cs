using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems;

public class FinalsSystem : System
{
    public override string Type => SystemManager.Finals;
    public override DiscordColor EmbedColor => DiscordColor.DarkRed;

    public override DiscordInteractionResponseBuilder CreateModal(string modalType)
    {
        throw new NotImplementedException();
    }
}