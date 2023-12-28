namespace Category5ScoutingV2.Shared.Datastore;

internal class TypedJsonCell(Type type, string json)
{
    private readonly Type type = NullableValueType.Strip(type);
    private volatile string json = json;

    public static TypedJsonCell FromValue<T>(T value)
    {
        return new(typeof(T), ToJson(value));
    }

    public void Deconstruct(out Type type, out string json)
    {
        type = this.type;
        json = this.json;
    }

    /// <exception cref="DatastoreKeyTypeMismatchException"></exception>
    /// <exception cref="DatastoreTypeMismatchException"></exception>
    public T Read<T>(DatastoreKey key)
    {
        key.ThrowOnKeyTypeMismatch(type);
        ThrowOnTypeMismatch<T>(key);
        // It is okay for value to be null.
        // The only way it can be null is if json is "null", which means the user provided a nullable type that is null.
        return JsonSerializer.Deserialize<T>(json)!;
    }

    /// <exception cref="DatastoreKeyTypeMismatchException"></exception>
    /// <exception cref="DatastoreTypeMismatchException"></exception>
    public void Write<T>(DatastoreKey key, T value)
    {
        key.ThrowOnKeyTypeMismatch(type);
        ThrowOnTypeMismatch<T>(key);
        json = ToJson(value);
    }

    /// <exception cref="DatastoreTypeMismatchException"></exception>
    private void ThrowOnTypeMismatch<T>(DatastoreKey key)
    {
        Type given = NullableValueType.Strip(typeof(T));
        if (given != type)
        {
            throw new DatastoreTypeMismatchException(type, given, key);
        }
    }

    private static string ToJson<T>(T value)
    {
        return JsonSerializer.Serialize(value);
    }
}