namespace Category5ScoutingV2._Database;

public class Data
{
    public string CurrentEventKey { get; set; } = "";
    public Dictionary<string, Event> Events { get; set; } = [];
}

public record struct TeamAndEvent(int TeamNumber, string EventKey);

public record Team(
    int TeamNumber,
    string Nickname
)
{
    public string TeamKey => $"frc{TeamNumber}";
}

public record Event(
    int Year,
    string EventKey,
    List<Team> Teams,
    Dictionary<TeamAndEvent, Modal> Modals
);

public record Modal(string Key);