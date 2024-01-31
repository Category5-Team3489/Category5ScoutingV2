using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Category5ScoutingV2.Bot.Modals;


public static class Teleop1
{
    public static DiscordInteractionResponseBuilder CreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("TeleOp1-modal")
            .WithTitle("TeleOp-1")
            .AddComponents(new TextInputComponent(
                label: "Instructions (DO NOT EDIT!)",
                customId: "Teleopinstructions-modal",
                value: "Should be used as the game is going on, This should be a solid replacement for options like the Notes apps.\nDO NOT EDIT!",
                required: true,
                style: TextInputStyle.Paragraph
            ))
            .AddComponents(new TextInputComponent(
                label: "Preference in Speaker or Amp or scores both?",
                customId: "teleop-start-modal",
                placeholder: "If a robot scores both in Amp and in Speaker explain their strategy of when and why they switch.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
             .AddComponents(new TextInputComponent(
                label: "What is the robot’s strategy through Teleop?",
                customId: "Teleop-middle-modal",
                placeholder: "Explain the decision making process the robot goes through. Any unique decisions?",
                required: true,
                style: TextInputStyle.Paragraph
            ))
             .AddComponents(new TextInputComponent(
                label: "General cycle time, routing, and speed.",
                customId: "Teleop-end-modal",
                placeholder: "Describe speed and cycle time by comparing it to other robot averages. Be indef about routes.",
                required: true,
                style: TextInputStyle.Paragraph
            ))
             .AddComponents(new TextInputComponent(
                label: "Defense, or Scoring bot. Effective at job?",
                customId: "Teleop-end-modal2",
                placeholder: "One of the three roles or a combination. Effectiveness at the role comparatively. Switch roles thru?",
                required: true,
                style: TextInputStyle.Paragraph
            ));

    }
}