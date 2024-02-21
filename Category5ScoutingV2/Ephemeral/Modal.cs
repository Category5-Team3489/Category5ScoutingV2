﻿using DSharpPlus.Entities;

namespace Category5ScoutingV2.Ephemeral;

public abstract class Modal
{
    public abstract string Key { get; }

    private readonly List<(TextInput textInput, bool save)> textInputs = [];

    public DiscordInteractionResponseBuilder Get()
    {
        DiscordInteractionResponseBuilder builder = new();

        builder
            .WithCustomId(Key)
            .WithTitle(Key);

        Build();

        // TODO Fill value here from database

        // TODO Ensure save and value arent both configured for the TExtInput struct

        // TODO Ensure custom id is less than or equal to 100 chars
        // TODO ENsure all text input component params are valid
        // TODO Ensure "Key" is less than or eq to 45 chars

        builder = null!;
        return null!;
    }

    public abstract void Build();

    protected void AddInstructions(string value)
    {
        //components.Add(new(
        //    label: "Instructions (DO NOT EDIT!)",
        //    customId: "", // TODO IMPLEMENT
        //    value,
        //    style: TextInputStyle.Paragraph
        //));

        textInputs.Add((new TextInput()
        {
            Label = "Instructions (DO NOT EDIT!)",

        }, save: false));
    }

    protected void AddQuestions(TextInput textInput)
    {
        //textInputs.Add(textInput);
    }

    protected readonly struct TextInput()
    {
        public required string Label { get; init; }
        public string? Placeholder { get; init; }
        public string? Value { get; init; }
        public bool Required { get; init; } = true;
        public TextInputStyle Style { get; init; } = TextInputStyle.Short;
        public int MinLength { get; init; } = 0;
        public int? MaxLength { get; init; } = null;
    }

    public static string GetCustomId(string key, string label)
    {
        return $"{key}^{label}";
    }

    public static (string key, string label) SplitCustomId(string customId)
    {
        // TODO Use the custom id to say if the textbox saves append S or N to the end or smthn

        string[] split = customId.Split('^');
        if (split.Length != 2)
        {
            throw new Exception($"Expected \"{customId}\" to split into exactly two.");
        }

        return (split[0], split[1]);
    }
}