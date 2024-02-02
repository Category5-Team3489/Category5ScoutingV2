using Category5ScoutingV2.Database;
using Category5ScoutingV2.TbaApi;
using Category5ScoutingV2.TbaApi.Schemas;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Category5ScoutingV2.CommandModules;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[Group("config")]
public class ConfigModule : BaseCommandModule
{
    public Db Db { get; set; } = null!;
    public Tba Tba { get; set; } = null!;

    [Command("event")]
    public async Task Event(CommandContext ctx, string eventKey)
    {
        try
        {
            var eventSimple = await Tba.Get<EventSimple>($"/event/{eventKey}/simple");

            if (eventSimple.key != eventKey)
            {
                throw new Exception($"Provided event key {eventKey} is not equal to found {eventSimple.key}");
            }

            Db.Op(data =>
            {
                data.CurrentEventKey = eventKey;
            });

            await ctx.RespondAsync($"Configured the current event as {eventSimple.name}.");
        }
        catch (Exception ex)
        {
            await ctx.RespondAsync(ex.ToString());
        }
    }
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression