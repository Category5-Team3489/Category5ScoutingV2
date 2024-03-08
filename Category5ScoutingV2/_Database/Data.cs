global using EventKey = string;
global using MatchKey = string;
global using ModalKey = string;
global using TeamNumber = int;

namespace Category5ScoutingV2._Database;

public class Data
{
    public EventKey CurrentEventKey { get; set; } = "";
    public Dictionary<EventKey, Event> Events { get; set; } = [];

    [JsonIgnore]
    public Event CurrentEvent => Events[CurrentEventKey];
}

public record struct TeamModalKey(TeamNumber TeamNumber, ModalKey ModalKey)
{
    public static TeamModalKey FromString(string value)
    {
        string[] split = value.Split('|');
        return new(TeamNumber.Parse(split[0]), split[1]);
    }

    public override readonly string ToString()
    {
        return $"{TeamNumber}|{ModalKey}";
    }
}
public record struct TeamMatchModalKey(TeamNumber TeamNumber, MatchKey MatchKey, ModalKey ModalKey)
{
    public static TeamMatchModalKey FromString(string value)
    {
        string[] split = value.Split('|');
        return new(TeamNumber.Parse(split[0]), split[1], split[2]);
    }

    public override readonly string ToString()
    {
        return $"{TeamNumber}|{MatchKey}|{ModalKey}";
    }
}

public record Team(
    TeamNumber TeamNumber,
    string Nickname
)
{
    [JsonIgnore]
    public string TeamKey => $"frc{TeamNumber}";
}

public record Event(
    EventKey EventKey,

    int Year,
    List<Team> Teams,

    Dictionary<string, string> TeamData,
    Dictionary<string, string> TeamMatchData
)
{
    public Team GetTeam(TeamNumber teamNumber) => Teams.Find(t => t.TeamNumber == teamNumber) ?? throw new Exception($"Team {teamNumber} not found at current event {EventKey}.");
}