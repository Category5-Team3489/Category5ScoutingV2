using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Category5ScoutingV2.Shared;

internal class TypedJsonCell
{
    public enum ReadError : byte
    {
        None,
        TypeMismatch,
        DeserializeIsNull
    }

    public enum WriteError : byte
    {
        None,
        TypeMismatch
    }

    private readonly Type type;
    private volatile string json;

    private TypedJsonCell(Type type, string json)
    {
        this.type = type;
        this.json = json;
    }

    public static TypedJsonCell Init<T>(T value)
    {
        return new(typeof(T), Serialize(value));
    }

    public bool TryRead<T>([MaybeNullWhen(false)] out T value, out ReadError error)
    {
        if (typeof(T) != type)
        {
            value = default;
            error = ReadError.TypeMismatch;
            return false;
        }

        var maybeValue = JsonSerializer.Deserialize<T>(json);
        if (maybeValue is null)
        {
            value = default;
            error = ReadError.DeserializeIsNull;
            return false;
        }

        value = maybeValue;
        error = ReadError.None;
        return true;
    }

    public bool TryWrite<T>(T value, out WriteError error)
    {
        if (typeof(T) != type)
        {
            error = WriteError.TypeMismatch;
            return false;
        }

        json = Serialize(value);
        error = WriteError.None;
        return true;
    }

    private static string Serialize<T>(T value)
    {
        return JsonSerializer.Serialize(value);
    }
}