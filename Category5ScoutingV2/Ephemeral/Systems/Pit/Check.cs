namespace Category5ScoutingV2.Ephemeral.Systems.Pit;

public class Check(System system) : Modal(system)
{
    public override string Type => "Check";
    public override int SortingOrder => 1;
    public override ButtonStyle ButtonStyle => ButtonStyle.Primary;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Simple check to remember information while talking to the team. This should be used as a replacement to the notes app.");
        AddQuestion(new TextInput()
        {
            Label = "Chassis/Intake/Shooter/Climber/Speed/Arm/Size",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Auto scoring,positions,routes,speaker vs amp",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Cycle,Stage task,Game history,scoring,routes",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Any new drive/pit team? General experience?",
            Style = TextInputStyle.Paragraph
        });
    }
}
