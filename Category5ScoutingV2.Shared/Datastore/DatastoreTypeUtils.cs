namespace Category5ScoutingV2.Shared.Datastore;

internal static class DatastoreTypeUtils
{
    // https://stackoverflow.com/a/8939958/10725664
    // Reference types cannot be nullable types during runtime, it is a compiler feature apparently.
    public static Type StripNullableValueType(Type type)
    {
        var underlyingType = Nullable.GetUnderlyingType(type);
        if (underlyingType is not null)
        {
            return underlyingType;
        }

        return type;
    }

    public static class StringToType
    {
        private readonly static object typeCacheLock = new();
        private readonly static Dictionary<string, Type> typeCache = [];

        public static Type Get(string typeString)
        {
            lock (typeCacheLock)
            {
                if (!typeCache.TryGetValue(typeString, out var type)
                {
                    type =
                }


            }
        }
    }

    public static string TypeToString(Type type)
    {
        string assemblyQualifiedName = type.AssemblyQualifiedName ?? throw new UnreachableException("This should not be a generic type parameter.");
        int secondCommaIndex = GetNthIndex(assemblyQualifiedName, ',', 2);
        return assemblyQualifiedName.AsSpan(0, secondCommaIndex).ToString();
    }

    private static int GetNthIndex(string s, char t, int n)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t)
            {
                count++;
                if (count == n)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}
