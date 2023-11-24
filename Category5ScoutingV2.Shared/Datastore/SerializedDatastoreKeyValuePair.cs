namespace Category5ScoutingV2.Shared.Datastore;

internal record SerializedDatastoreKeyValuePair(string Key, string ValueTypeAssemblyQualifiedName, string ValueJson)
{
    public static SerializedDatastoreKeyValuePair FromKvp(KeyValuePair<string, TypedJsonCell> kvp)
    {
        (string key, (Type type, string json)) = kvp;
        string valueTypeAssemblyQualifiedName = type.AssemblyQualifiedName ??
            throw new UnreachableException("This should not be a generic type parameter.");
        string valueJson = json;
        return new(key, valueTypeAssemblyQualifiedName, valueJson);
    }

    /// <exception cref="DatastoreTypeDeserializationException"></exception>
    public KeyValuePair<string, TypedJsonCell> ToKvp(Dictionary<string, Type> typeCache)
    {
        if (!typeCache.TryGetValue(ValueTypeAssemblyQualifiedName, out Type? type))
        {
            try
            {
                type = Type.GetType(ValueTypeAssemblyQualifiedName);
                if (type is null)
                {
                    throw new DatastoreTypeDeserializationException(ValueTypeAssemblyQualifiedName);
                }
            }
            catch (Exception inner)
            {
                throw new DatastoreTypeDeserializationException(ValueTypeAssemblyQualifiedName, inner);
            }

            typeCache.Add(ValueTypeAssemblyQualifiedName, type);
        }

        TypedJsonCell value = new(type, ValueJson);
        return new(Key, value);
    }
}
