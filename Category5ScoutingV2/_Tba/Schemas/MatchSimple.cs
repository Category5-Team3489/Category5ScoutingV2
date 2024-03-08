namespace Category5ScoutingV2._Tba.Schemas;

#pragma warning disable IDE1006 // Naming Styles

public class MatchSimple
{
    public string key { get; set; } = "";
    public int match_number { get; set; }
    public Alliances alliances { get; set; } = null!;
}

public class Alliances
{
    public MatchAlliance red { get; set; } = null!;
    public MatchAlliance blue { get; set; } = null!;
}

public class MatchAlliance
{
    public List<string> team_keys { get; set; } = null!;
}

#pragma warning restore IDE1006 // Naming Styles