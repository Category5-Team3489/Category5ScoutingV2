using Category5ScoutingV2.Ephemeral.Systems;

namespace Category5ScoutingV2.Ephemeral.Managers;

public static class SystemManager
{
    public const string Quals = nameof(Quals);
    public const string Pit = nameof(Pit);
    public const string Pre = nameof(Pre);
    public const string Finals = nameof(Finals);
    public static readonly IReadOnlyDictionary<string, Func<System>> Systems = new Dictionary<string, Func<System>>
    {
        [Quals] = () => new QualsSystem(),
        [Pit] = () => new PitSystem(),
        [Pre] = () => new PreSystem(),
        [Finals] = () => new FinalsSystem(),
    };

    public static readonly TimeSpan PromptTimeout = TimeSpan.FromMinutes(15);
    public const string Close = nameof(Close);
}