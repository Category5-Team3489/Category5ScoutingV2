namespace Category5ScoutingV2.Ephemeral.Systems.Pit;

public class Design(System system) : Modal(system)
{
    public override string Type => "Design";
    public override int SortingOrder => 2;
    public override ButtonStyle ButtonStyle => ButtonStyle.Danger;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("This should be used to answer questions with as much detail possible. Use the Check Label to help remember things said by the other team. Give information that describes the physical aspects of the robot.");
        AddQuestion(new TextInput()
        {
            Label = "What is the robot’s Chassis design?",
            Placeholder = "Do they have drive trains like swerve, six wheel, 8 wheel, mecanum, etc. Why did they choose this?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "What is the speed, weight, size, height?",
            Placeholder = "Describe the more physical attributes of their robot. Use comparisons to make up for non-specific #s",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Robot arm design, shooter, climber,intake.",
            Placeholder = "Describe these features using correct terminology. If unknown/unique ask what the team calls it.",
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
