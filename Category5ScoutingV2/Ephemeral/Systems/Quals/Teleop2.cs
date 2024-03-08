namespace Category5ScoutingV2.Ephemeral.Systems.Quals;

public class Teleop2(System system) : Modal(system)
{
    public override string Type => "Teleop 2";
    public override int SortingOrder => 3;
    public override ButtonStyle ButtonStyle => ButtonStyle.Success;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Write detailed information about the main portion of the game after auto but before robots start interacting with the stage. Use correct terminology when talking about game elements and game pieces. Highlight repeated behavior, routes, and trends.");
        AddQuestion(new TextInput()
        {
            Label = "Do they consistently get penalty points? How?",
            Placeholder = "How effective is the robot is at avoiding or getting penalties. How do the robots get penalties?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Do they deal with traffic well or cause it?",
            Placeholder = "How does the robot deal with traffic using strategy or cause it. Do they cause traffic on purpose?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Is performance affected by physical aspects?",
            Placeholder = "How does the robots unique robot attributes hinder or help their performance?Weight,height,speed.etc",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Helpful and actionable notes for drive team",
            Placeholder = "Notes for drive team as a reference .This should make things like Finals easier. Also use as notes.",
            Style = TextInputStyle.Paragraph
        });
    }
}
