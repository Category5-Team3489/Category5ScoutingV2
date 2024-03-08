namespace Category5ScoutingV2.Ephemeral.Systems.Quals;

public class Teleop1(System system) : Modal(system)
{
    public override string Type => "Teleop 1";
    public override int SortingOrder => 2;
    public override ButtonStyle ButtonStyle => ButtonStyle.Success;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Write detailed information about the main portion of the game after auto but before robots start interacting with the stage. Use correct terminology when talking about game elements and game pieces. Highlight repeated behavior, routes, and trends.");
        AddQuestion(new TextInput()
        {
            Label = "Preference in Speaker or Amp or scores both?",
            Placeholder = "If a robot scores both in Amp and in Speaker explain their strategy of when and why they switch.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "What is the robot’s strategy through Teleop?",
            Placeholder = "Explain the decision making process the robot goes through. Any unique decisions?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "General cycle time, routing, and speed.",
            Placeholder = "Describe speed and cycle time by comparing it to other robot averages. Be indef about routes.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Defense, or Scoring bot. Effective at job?",
            Placeholder = "One of the three roles or a combination. Effectiveness at the role comparatively. Switch roles thru?",
            Style = TextInputStyle.Paragraph
        });
    }
}
