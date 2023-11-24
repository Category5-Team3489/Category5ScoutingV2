namespace Category5ScoutingV2.Shared.Datastore.Utils;

internal static class NameToType
{
    private readonly static object typeCacheLock = new();
    private readonly static Dictionary<string, Type> typeCache = [];

    public static Type Convert(string typeName)
    {
        lock (typeCacheLock)
        {
            if (!typeCache.TryGetValue(typeName, out var type))
            {
                type = Get(typeName);
                typeCache.Add(typeName, type);
            }

            Debug.Assert(typeCache[typeName] == type, $"<\"{typeName}\", \"{type}\"> not found in type cache.");

            return type;
        }
    }

    private static Type Get(string typeName)
    {
        return Type.GetType(typeName) ??
            throw new Exception($"Unable to determine type from provided type name \"{typeName}\".");
    }
}