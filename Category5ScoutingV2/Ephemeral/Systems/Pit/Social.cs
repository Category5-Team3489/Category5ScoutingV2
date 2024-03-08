namespace Category5ScoutingV2.Ephemeral.Systems.Pit;

public class Social(System system) : Modal(system)
{
    public override string Type => "Social";
    public override int SortingOrder => 4;
    public override ButtonStyle ButtonStyle => ButtonStyle.Secondary;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("This should be used to answer questions with as much detail possible. Use the Check Label to help remember things said by the other team. Information is geared towards the social implications of pit scouting.");
        AddQuestion(new TextInput()
        {
            Label = "How is their drive team/pit crew? Changes?",
            Placeholder = "Mark how their team has changed over seasons. How much previous drive practice was obtained.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Is their team fun,approachable,sociable?",
            Placeholder = "Important when picking if we want to pitch. Do they have a good relationship with us?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Notes",
            Placeholder = "Anything socially important or that could help drive team. Anything that can be used in a pitch.",
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
