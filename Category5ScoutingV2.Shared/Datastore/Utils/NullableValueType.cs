namespace Category5ScoutingV2.Shared.Datastore.Utils;

internal static class NullableValueType
{
    private readonly static object underlyingTypeCacheLock = new();
    private readonly static Dictionary<Type, Type> underlyingTypeCache = [];

    public static Type Strip(Type type)
    {
        lock (underlyingTypeCacheLock)
        {
            if (!underlyingTypeCache.TryGetValue(type, out var underlyingType))
            {
                underlyingType = Get(type);
                underlyingTypeCache.Add(type, underlyingType);
            }

            Debug.Assert(underlyingTypeCache[type] == underlyingType, $"<\"{type}\", \"{underlyingType}\"> not found in underlying type cache.");

            return underlyingType;
        }
    }

    // https://stackoverflow.com/a/8939958/10725664
    // Only nullable value types are a different type at runtime from the non-nullable counterparts
    private static Type Get(Type type)
    {
        var underlyingType = Nullable.GetUnderlyingType(type);
        if (underlyingType is not null)
        {
            return underlyingType;
        }

        return type;
    }
}