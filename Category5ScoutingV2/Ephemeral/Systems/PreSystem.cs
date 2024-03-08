using Category5ScoutingV2.Ephemeral.Managers;
using Category5ScoutingV2.Ephemeral.Systems.Pre;
using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems;

public class PreSystem : System
{
    public override string Type => SystemManager.Pre;
    public override DiscordColor EmbedColor => DiscordColor.Aquamarine;
    public override List<Modal> Modals => [new Predict(this), new Strategy(this)];
}