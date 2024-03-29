﻿using Category5ScoutingV2.Ephemeral.Managers;

namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Description("Commands to scout pits")]
[Group("pit")]
public class PitModule : BaseCommandModule
{
    [GroupCommand]
    public async Task Pit(CommandContext ctx, TeamNumber teamNumber) => await Cmd(ctx, async () =>
    {
        await PromptManager.PromptSystem(ctx, SystemManager.Pit, teamNumber);
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression