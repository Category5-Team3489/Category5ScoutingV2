﻿using Category5ScoutingV2.Ephemeral.Managers;
using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral.Systems;

public class PitSystem : System
{
    public override string Type => SystemManager.Pit;
    public override DiscordColor EmbedColor => DiscordColor.Yellow;

    public override DiscordInteractionResponseBuilder CreateModal(string modalType)
    {
        throw new NotImplementedException();
    }
}