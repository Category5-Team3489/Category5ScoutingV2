namespace Category5ScoutingV2;

public static class Utils
{
    public static async Task Cmd(CommandContext ctx, Func<Task> func)
    {
        try
        {
            await func();
        }
        catch (Exception ex)
        {
            await ctx.RespondAsync(ex.ToString());
        }
    }
}