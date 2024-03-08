using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral;

public abstract class Modal(System system)
{
    public System System { get; init; } = system;
    public abstract string Type { get; }
    public abstract int SortingOrder { get; }
    public abstract ButtonStyle ButtonStyle { get; }
    public abstract bool IsMatchModal { get; }

    private readonly List<(TextInput textInput, bool saves)> textInputs = [];

    public DiscordInteractionResponseBuilder Get(TeamNumber teamNumber, MatchKey? matchKey = null)
    {
        DiscordInteractionResponseBuilder builder = new();

        builder
            .WithCustomId(Type)
            .WithTitle($"{System.Type} - {Type}");

        Build();

        foreach ((var textInput, bool saves) in textInputs)
        {
            textInput.Validate();

            if (saves && textInput.Value != null)
            {
                throw new Exception($"Text input with label {textInput.Label} must not be preloaded with a value if it is being saved.");
            }

            string customId = GetTextInputCustomId(System.Type, Type, textInput.Label, saves);

            if (customId.Length < 1 || customId.Length > 100) throw new Exception($"Custom id {customId} length is invalid.");

            string value = textInput.Value!;

            if (saves)
            {
                if (IsMatchModal && matchKey == null)
                {
                    throw new Exception("Match key cannot be null if the modal is a match modal.");
                }

                ModalKey modalKey = customId;
                if (matchKey == null)
                {
                    TeamModalKey teamModalKey = new(teamNumber, modalKey);
                    value = Db.Op(data =>
                    {
                        data.CurrentEvent.TeamData.TryGetValue(teamModalKey.ToString(), out var v);
                        return v ?? "";
                    });
                }
                else
                {
                    TeamMatchModalKey teamMatchModalKey = new(teamNumber, matchKey, modalKey);
                    value = Db.Op(data =>
                    {
                        data.CurrentEvent.TeamMatchData.TryGetValue(teamMatchModalKey.ToString(), out var v);
                        return v ?? "";
                    });
                }
            }

            builder.AddComponents(new TextInputComponent(
                textInput.Label,
                customId,
                textInput.Placeholder!,
                value,
                textInput.Required,
                textInput.Style,
                textInput.MinLength,
                textInput.MaxLength
            ));
        }

        return builder;
    }

    protected abstract void Build();

    protected void AddInstructions(string value)
    {
        textInputs.Add((new TextInput()
        {
            Label = "Instructions (DO NOT EDIT!)",
            Value = value,
            Style = TextInputStyle.Paragraph
        }, saves: false));
    }

    protected void AddQuestion(TextInput textInput, bool saves = true)
    {
        textInputs.Add((textInput, saves));
    }

    protected readonly struct TextInput()
    {
        public required string Label { get; init; }
        public string? Placeholder { get; init; }
        public string? Value { get; init; }
        public bool Required { get; init; } = false;
        public TextInputStyle Style { get; init; } = TextInputStyle.Short;
        public int MinLength { get; init; } = 0;
        public int? MaxLength { get; init; } = null;

        public void Validate()
        {
            if (Label.Length < 1 || Label.Length > 45 || Label.Contains('^', '$')) throw new Exception($"Label {Label} is invalid.");
            if (MinLength < 0 || MinLength > 4000) throw new Exception($"MinLength {MinLength} is invalid.");
            if (MaxLength.HasValue && (MaxLength < 1 || MaxLength > 4000)) throw new Exception($"MaxLength {MaxLength} is invalid.");
            if (Value != null && (Value.Length < 0 || Value.Length > 4000)) throw new Exception($"Value {Value} is invalid.");
            if (Placeholder != null && (Placeholder.Length < 1 || Placeholder.Length > 100)) throw new Exception($"Placeholder {Placeholder} is invalid.");
        }
    }

    public static string GetTextInputCustomId(string systemType, string modalType, string label, bool saves)
    {
        string end = saves ? "$" : "";
        return $"{systemType}^{modalType}^{label}{end}";
    }

    public static (string systemType, string modalType, string label, bool saves) SplitTextInputCustomId(string customId)
    {
        bool saves = customId.EndsWith('$');
        if (saves)
        {
            customId = customId[..^1];
        }

        string[] split = customId.Split('^');
        if (split.Length != 3)
        {
            throw new Exception($"Expected \"{customId}\" to split into exactly three.");
        }

        return (split[0], split[1], split[2], saves);
    }
}