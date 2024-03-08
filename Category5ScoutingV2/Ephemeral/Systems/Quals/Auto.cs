namespace Category5ScoutingV2.Ephemeral.Systems.Quals;

public class Auto(System system) : Modal(system)
{
    public override string Type => "Auto";
    public override int SortingOrder => 1;
    public override ButtonStyle ButtonStyle => ButtonStyle.Danger;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Does their robot have an auto, write about what it does and where it goes. Auto consistency and quality should be commented on as well.");
        AddQuestion(new TextInput()
        {
            Label = "Auto starting position,routing, note order.",
            Placeholder = "Use the sub-woofer as reference for auto positions. Note order is the order they pick up and score?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Amp, Speaker, Distances Scored, Consistency?",
            Placeholder = "Consistency marks how many times auto worked, penalties, or effect alliance members.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Unique robot strategies/thoughts in auto?",
            Placeholder = "Does their auto do anything unique or not? Does their auto do anything strategy related?",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Auto NOTES (not game piece)",
            Placeholder = "Add any notes not asked by other boxes and put your opinions. Also any info helpful to drive team.",
            Style = TextInputStyle.Paragraph
        });
    }
}
