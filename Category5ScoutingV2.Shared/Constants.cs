namespace Category5ScoutingV2.Shared;

public static class Constants
{
    public static readonly DatastoreKey TestKey = DatastoreKey.Typed<string>("test");

    public static readonly IReadOnlyList<DiscordTeamTag> DiscordTeamTags = [
        new DiscordTeamTag("BLT", ":sandwich:"),
        new DiscordTeamTag("Good to work with", ":shaking_hands:"),
        new DiscordTeamTag("Bad to work with", ":imp:"),
        new DiscordTeamTag("Good auto", ":desktop:"),
        new DiscordTeamTag("Red card", ":red_square:"),
        new DiscordTeamTag("Yellow card", ":yellow_square:"),
        new DiscordTeamTag("DQ'd", ":sob:"),
        new DiscordTeamTag("No auto", ":chair:"),
        new DiscordTeamTag("Good endgame", ":alarm_clock:"),
        new DiscordTeamTag("Has an auto", ":mechanical_arm:"),
    ];
}