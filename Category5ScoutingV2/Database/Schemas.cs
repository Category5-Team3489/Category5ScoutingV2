namespace Category5ScoutingV2.Database;

public record struct Team(
    int TeamNumber,
    string Nickname
)
{
    public readonly string TeamKey => $"frc{TeamNumber}";
}

public record struct TeamAndEvent(int TeamNumber, string EventKey);

public record Event(
    int Year,
    string EventKey,
    List<Team> Teams,
    Dictionary<TeamAndEvent, Modal> Modals
);

public record Modal();