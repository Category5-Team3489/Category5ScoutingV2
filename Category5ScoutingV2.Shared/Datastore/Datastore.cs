namespace Category5ScoutingV2.Shared.Datastore;

public class Datastore
{
    private readonly ConcurrentDictionary<string, TypedJsonCell> data;

    private Datastore(IEnumerable<KeyValuePair<string, TypedJsonCell>> data)
    {
        this.data = new(data);
    }

    /// <exception cref="DatastoreDeserializationException"></exception>
    /// <exception cref="DatastoreTypeDeserializationException"></exception>
    public static Datastore FromJson(string? json = null)
    {
        if (string.IsNullOrEmpty(json))
        {
            return new([]);
        }

        var serializedDatastore = SerializedDatastore.FromJson(json);
        Dictionary<string, Type> typeCache = [];
        var data = serializedDatastore.SerializedKvps.Select(kvp => kvp.ToKvp(typeCache)).ToList();
        return new(data);
    }

    public string ToJson()
    {
        var dataCopy = data.ToArray();
        var serializedKvps = dataCopy.Select(SerializedDatastoreKeyValuePair.FromKvp).ToList();
        return new SerializedDatastore(serializedKvps).ToJson();
    }

    /// <exception cref="DatastoreKeyTypeMismatchException"></exception>
    /// <exception cref="DatastoreTypeMismatchException"></exception>
    public bool TryRead<T>(DatastoreKey key, [MaybeNullWhen(false)] out T value)
    {
        if (data.TryGetValue(key, out var cell))
        {
            value = cell.Read<T>(key);
            return true;
        }

        value = default;
        return false;
    }

    // Writes could be queued in a ConcurrentQueue when ToJson() is blocking everything, but:
    // - Premature optimization
    // - No exceptions thrown immediately if something is wrong
    // - Complexity
    /// <exception cref="DatastoreKeyTypeMismatchException"></exception>
    /// <exception cref="DatastoreTypeMismatchException"></exception>
    public void Write<T>(DatastoreKey key, T value)
    {
        if (data.TryGetValue(key, out var cell))
        {
            cell.Write(key, value);
        }
        else
        {
            data[key] = TypedJsonCell.FromValue(value);
        }
    }

    /// <exception cref="DatastoreKeyTypeMismatchException"></exception>
    public bool Delete(DatastoreKey key, [MaybeNullWhen(false)] out Type type, [MaybeNullWhen(false)] out string json)
    {
        if (data.Remove(key, out var cell))
        {
            (type, json) = cell;
            key.ThrowOnKeyTypeMismatch(type);
            return true;
        }

        type = default;
        json = default;
        return false;
    }
}
