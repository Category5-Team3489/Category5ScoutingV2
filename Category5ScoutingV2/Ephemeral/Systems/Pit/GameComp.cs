namespace Category5ScoutingV2.Ephemeral.Systems.Pit;

public class GameComp(System system) : Modal(system)
{
    public override string Type => "Game Composition";
    public override int SortingOrder => 3;
    public override ButtonStyle ButtonStyle => ButtonStyle.Success;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("This should be used to answer questions with as much detail possible. Use the Check Label to help remember things said by the other team. Give information that relates to the action of the game.");
        AddQuestion(new TextInput()
        {
            Label = "Amount of autos, function, auto starting spot",
            Placeholder = "Use the speaker as reference when talking about auto start. Describe note order in each auto.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "What is the robot’s general cycle time?",
            Placeholder = "Cycle time is the time from a robot's scoring to picking up note to scoring. Use comparison.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Do they score in Amp, speaker, or trap?",
            Placeholder = "Can they score in more than one. If they can score in multiple but prefer one describe.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Additional info",
            Placeholder = "Post Additional info here",
            Style = TextInputStyle.Paragraph
        });
    }
}
