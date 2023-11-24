namespace Category5ScoutingV2.Shared.Datastore.Serialization;

internal record DatastoreRecord(List<DatastoreKvpRecord> SerializedKvps)
{
    public static DatastoreRecord FromJson(string json)
    {
        return JsonSerializer.Deserialize<DatastoreRecord>(json) ??
            throw new Exception("Unable to deserialize datastore JSON.");
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}