using DSharpPlus.Entities;

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
            MemoryStream ms = new(System.Text.Encoding.UTF8.GetBytes(ex.ToString()));
            await new DiscordMessageBuilder()
                .AddFile("Exception.txt", ms)
                .SendAsync(ctx.Channel);
            // await ctx.RespondAsync(ex.ToString());
        }
    }
}