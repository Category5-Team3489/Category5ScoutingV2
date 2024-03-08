namespace Category5ScoutingV2.Ephemeral.Systems.Quals;

public class Endgame(System system) : Modal(system)
{
    public override string Type => "Endgame";
    public override int SortingOrder => 4;
    public override ButtonStyle ButtonStyle => ButtonStyle.Secondary;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Scouters should determine how consistently each robot completes/ gets to the endgame task.");
        AddQuestion(new TextInput()
        {
            Label = "How/Do they score trap.Do they need to climb?",
            Placeholder = "Do they need to climb or score from floor for trap.Consistency?Do they need to be in a certain spot?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "What time do they need to climb/score trap?",
            Placeholder = "How soon do they need to transition from Teleop to endgame? How long does it take to climb/score?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Single/double/triple climb. How consistent?",
            Placeholder = "How consistently can they climb with multiple robots on average. How do they get past robot's space.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Room taken up on chain? Why a lot or little?",
            Placeholder = "How much room do they leave for other robots to get on chain. Do they always hang in middle.",
            Style = TextInputStyle.Paragraph
        });
    }
}
