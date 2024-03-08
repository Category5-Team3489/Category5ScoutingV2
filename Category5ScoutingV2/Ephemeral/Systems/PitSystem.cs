using Category5ScoutingV2.Ephemeral.Managers;
using Category5ScoutingV2.Ephemeral.Systems.Pit;
using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems;

public class PitSystem : System
{
    public override string Type => SystemManager.Pit;
    public override DiscordColor EmbedColor => DiscordColor.Yellow;
    public override List<Modal> Modals => [new Check(this), new Design(this), new GameComp(this), new Social(this)];
}