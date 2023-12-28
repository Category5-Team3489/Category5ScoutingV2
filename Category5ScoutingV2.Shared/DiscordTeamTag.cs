namespace Category5ScoutingV2.Shared;

public record DiscordTeamTag(string Label, string EmojiName)
{
    public DiscordSelectComponentOption ToComponentOption(DiscordClient client)
    {
        return new DiscordSelectComponentOption(
            label: Label,
            value: Label,
            emoji: new DiscordComponentEmoji(DiscordEmoji.FromName(client, EmojiName))
        );
    }
}