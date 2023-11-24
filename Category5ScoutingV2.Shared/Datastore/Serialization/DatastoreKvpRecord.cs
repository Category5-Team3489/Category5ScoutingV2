namespace Category5ScoutingV2.Shared.Datastore.Serialization;

internal record DatastoreKvpRecord(string Key, string ValueTypeName, string ValueJson)
{
    public static DatastoreKvpRecord FromKvp(KeyValuePair<string, TypedJsonCell> kvp)
    {
        (string key, (Type type, string json)) = kvp;
        string valueTypeName = TypeToName.Convert(type);
        string valueJson = json;
        return new(key, valueTypeName, valueJson);
    }

    public KeyValuePair<string, TypedJsonCell> ToKvp()
    {
        Type type = NameToType.Convert(ValueTypeName);
        TypedJsonCell value = new(type, ValueJson);
        return new(Key, value);
    }
}
