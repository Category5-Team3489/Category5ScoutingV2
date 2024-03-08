namespace Category5ScoutingV2.Ephemeral.Systems.Pre;

public class Strategy(System system) : Modal(system)
{
    public override string Type => "Strategy";
    public override int SortingOrder => 2;
    public override ButtonStyle ButtonStyle => ButtonStyle.Danger;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Strategy related information of predictive scouting. Use the information gained to start making a game plan/strategy for the Playoffs. This can also be referred to during Alliance scouting.");
        AddQuestion(new TextInput()
        {
            Label = "Strategy compatibility with other robots.",
            Placeholder = "Do we take different routes reducing traffic or do their auto pick up in different spots etc?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Draft a pitch showing robot compatibility.",
            Placeholder = "Make a pitch demonstrating why we would make good allies. Attempt to convince our allies.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "What auto/scoring areas are used in finals?",
            Placeholder = "What auto, scoring paths, routes, strategy, etc are they most likely to use during finals?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Additional info",
            Placeholder = "Post any additional info here",
            Style = TextInputStyle.Paragraph
        });
    }
}
