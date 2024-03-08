namespace Category5ScoutingV2.Ephemeral.Systems.Quals;

public class MatchByMatch(System system) : Modal(system)
{
    public override string Type => "Match-by-Match";
    public override int SortingOrder => 1;
    public override ButtonStyle ButtonStyle => ButtonStyle.Primary;
    public override bool IsMatchModal => true;

    protected override void Build()
    {
        AddInstructions("Should be used as a game is going on, This should be a solid replacement for options like Notes apps.");
        AddQuestion(new TextInput()
        {
            Label = "Match-by-Match Notes",
            Placeholder = "Type your match-by-match notes here",
            Style = TextInputStyle.Paragraph
        });
    }
}
