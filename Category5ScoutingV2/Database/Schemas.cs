namespace Category5ScoutingV2.Database;

public record Team(
    int TeamNumber,
    string Nickname
)
{
    public string TeamKey => $"frc{TeamNumber}";
}

public record TeamAndEvent(int TeamNumber, string EventKey);

public record Event(
    int Year,
    string EventKey,
    List<Team> Teams,
    Dictionary<TeamAndEvent, Modal> Modals
);

public record Modal(string Key);