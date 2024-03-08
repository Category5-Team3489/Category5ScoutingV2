namespace Category5ScoutingV2.Ephemeral.Systems.Finals;

public class Finals(System system) : Modal(system)
{
    public override string Type => "Finals";
    public override int SortingOrder => 1;
    public override ButtonStyle ButtonStyle => ButtonStyle.Success;
    public override bool IsMatchModal => false;

    protected override void Build()
    {
        AddInstructions("Obtain data from your set alliance. This data should be actionable, recent, concise, and quickly");
        AddQuestion(new TextInput()
        {
            Label = "Alliance Summary",
            Placeholder = "This should be a concise summary of your highlighted info. This should be your most actionable data.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Alliance Strategy",
            Placeholder = "Record team strategy based off how alliances worked as a unit.",
            Style = TextInputStyle.Paragraph
        });
        AddQuestion(new TextInput()
        {
            Label = "Robot Qualities",
            Placeholder = "Record info based off physical robot attributes and changes. Data should directly help drive team.",
            Style = TextInputStyle.Paragraph
        });
    }
}
