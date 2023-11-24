namespace Category5ScoutingV2.Shared.Datastore;

internal record SerializedDatastore(List<SerializedDatastoreKeyValuePair> SerializedKvps)
{
    /// <exception cref="DatastoreDeserializationException"></exception>
    public static SerializedDatastore FromJson(string json)
    {
        return JsonSerializer.Deserialize<SerializedDatastore>(json)!;

        try
        {
            var serializedDatastore = JsonSerializer.Deserialize<SerializedDatastore>(json);
            if (serializedDatastore is not null)
            {
                return serializedDatastore;
            }

            throw new DatastoreDeserializationException();
        }
        catch (Exception inner)
        {
            throw new DatastoreDeserializationException(inner);
        }
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}