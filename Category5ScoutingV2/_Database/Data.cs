global using EventKey = string;
global using MatchKey = string;
global using ModalKey = string;
global using TeamNumber = int;

namespace Category5ScoutingV2._Database;

public class Data
{
    public EventKey CurrentEventKey { get; set; } = "";
    public Dictionary<EventKey, Event> Events { get; set; } = [];
}

public record struct TeamEventModalKey(TeamNumber TeamNumber, EventKey EventKey, ModalKey ModalKey);
public record struct TeamMatchModalKey(TeamNumber TeamNumber, MatchKey MatchKey, ModalKey ModalKey);

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

    Dictionary<TeamEventModalKey, Modal> TeamEventModals,
    Dictionary<TeamMatchModalKey, Modal> TeamMatchModals
);

public record Modal(ModalKey ModalKey);