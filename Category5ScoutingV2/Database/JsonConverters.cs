using System.Text.Json;
using System.Text.Json.Serialization;

namespace Category5ScoutingV2.Database;

public class TeamAndEventJsonConverter : JsonConverter<TeamAndEvent>
{
    public override TeamAndEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Console.WriteLine("AAAAAAAAAa");
        var teamAndEvent = reader.GetString()!.Split('|');
        return new(int.Parse(teamAndEvent[0]), teamAndEvent[1]);
    }

    public override void Write(Utf8JsonWriter writer, TeamAndEvent value, JsonSerializerOptions options)
    {
        Console.WriteLine("BBBBBBBBB");
        writer.WriteStringValue($"{value.TeamNumber}|{value.EventKey}");
    }
}


public class ModalJsonConverter : JsonConverter<Modal>
{
    public override Modal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, Modal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Key);
    }
}
