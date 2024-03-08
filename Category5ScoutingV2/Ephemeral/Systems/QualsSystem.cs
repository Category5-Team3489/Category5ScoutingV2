using Category5ScoutingV2.Ephemeral.Managers;
using Category5ScoutingV2.Ephemeral.Systems.Quals;
using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems;

public class QualsSystem : System
{
    public override string Type => SystemManager.Quals;
    public override DiscordColor EmbedColor => DiscordColor.DarkGreen;
    public override List<Modal> Modals => [new MatchByMatch(this), new Auto(this), new Teleop1(this), new Teleop2(this), new Endgame(this)];
}