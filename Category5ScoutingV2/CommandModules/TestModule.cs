﻿namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Group("test")]
public class TestModule : BaseCommandModule
{
    [GroupCommand]
    public async Task Test(CommandContext ctx) => await Cmd(ctx, async () =>
    {
        throw new NotImplementedException();
    });
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression