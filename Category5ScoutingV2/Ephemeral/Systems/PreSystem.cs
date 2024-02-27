using Category5ScoutingV2.Ephemeral.Managers;
using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems;

public class PreSystem : System
{
    public override string Type => SystemManager.Pre;
    public override DiscordColor EmbedColor => DiscordColor.Aquamarine;

    public override DiscordInteractionResponseBuilder CreateModal(string modalType)
    {
        throw new NotImplementedException();
    }
}