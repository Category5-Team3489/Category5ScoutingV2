using System.Diagnostics.CodeAnalysis;

namespace Category5ScoutingV2.Shared;

public class Datastore
{
    public enum ReadError : byte
    {
        None,
        TypeMismatch,
        DeserializeIsNull,
        DNE
    }

    public enum WriteError : byte
    {
        None,
        TypeMismatch
    }

    private readonly ConcurrentDictionary<string, TypedJsonCell> data = new();

    public bool TryRead<T>(string key, [MaybeNullWhen(false)] out T value, out ReadError error)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("\"key\" cannot be null or empty.", nameof(key));
        }

        if (data.TryGetValue(key, out var cell))
        {
            if (cell.TryRead(out value, out var cellError))
            {
                error = ReadError.None;
                return true;
            }

            error = (ReadError)cellError;
            return false;
        }

        value = default;
        error = ReadError.DNE;
        return false;
    }

    public bool TryWrite<T>(string key, T value, out WriteError error)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("\"key\" cannot be null or empty.", nameof(key));
        }

        if (data.TryGetValue(key, out var cell))
        {
            if (cell.TryWrite(value, out var cellError))
            {
                error = WriteError.None;
                return true;
            }

            error = (WriteError)cellError;
            return false;
        }

        data[key] = TypedJsonCell.Init(value);

        error = WriteError.None;
        return true;
    }
}
