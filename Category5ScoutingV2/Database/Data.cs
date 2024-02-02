namespace Category5ScoutingV2.Database;

public class Data
{
    public string TbaApiKey { get; set; } = "";
    public string CurrentEventKey { get; set; } = "";
    public List<Event> Events { get; set; } = [];
}