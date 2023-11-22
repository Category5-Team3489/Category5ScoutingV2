using System.Diagnostics.CodeAnalysis;

namespace Category5ScoutingV2.Shared;

public static class DatastoreExtensions
{
    public static bool TryRead<T>(this Datastore datastore, string key, [MaybeNullWhen(false)] out T value)
    {
        return datastore.TryRead(key, out value, out _);
    }
    public static T? Read<T>(this Datastore datastore, string key)
    {
        if (datastore.TryRead<T>(key, out var value, out _))
        {
            return value;
        }

        return default;
    }

    public static void Write<T>(this Datastore datastore, string key, T value)
    {
        datastore.TryWrite(key, value, out _);
    }
}