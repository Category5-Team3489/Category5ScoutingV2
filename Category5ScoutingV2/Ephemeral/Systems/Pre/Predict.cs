namespace Category5ScoutingV2.Ephemeral.Systems.Pre;

public class Predict(System system) : Modal(system)
{
    public override string Type => "Predict";
    public override int SortingOrder => 1;
    public override ButtonStyle ButtonStyle => ButtonStyle.Success;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Predict what will happen to your individual robot later in the competition. This will help us be prepared for Alliance scouting and Playoffs. Have this completed before Alliance Picking.");
        AddQuestion(new TextInput()
        {
            Label = "Are they going to be in a picking position?",
            Placeholder = "This is a spot that allows them to have input on alliance partners. Not just the alliance captain.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Predicted first, second, or third pick.",
            Placeholder = "This is the order that the Alliance captain picks each partner. Use robot quality to predict this.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Is convincing them to ally with us needed?",
            Placeholder = "We pitch to teams in picking spots we should be allied. Is it valuable for us to pitch to this team?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Additional info",
            Placeholder = "Post additional info here",
            Style = TextInputStyle.Paragraph
        });
    }
}
