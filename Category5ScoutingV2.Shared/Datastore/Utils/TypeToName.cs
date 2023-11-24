namespace Category5ScoutingV2.Shared.Datastore.Utils;

internal static class TypeToName
{
    private readonly static object typeNameCacheLock = new();
    private readonly static Dictionary<Type, string> typeNameCache = [];

    public static string Convert(Type type)
    {
        lock (typeNameCacheLock)
        {
            if (!typeNameCache.TryGetValue(type, out var typeName))
            {
                typeName = Get(type);
                typeNameCache.Add(type, typeName);
            }

            Debug.Assert(typeNameCache[type] == typeName, $"<\"{type}\", \"{typeName}\"> not found in type name cache.");

            return typeName;
        }
    }

    private static string Get(Type type)
    {
        string assemblyQualifiedName = type.AssemblyQualifiedName ??
            throw new Exception($"Unable to get assembly qualified name of type \"{type}\".");

        int secondCommaIndex = GetNthIndex(assemblyQualifiedName, ',', 2);
        if (secondCommaIndex == -1)
        {
            throw new Exception($"Unexpected type name format \"{assemblyQualifiedName}\".");
        }

        return assemblyQualifiedName[..secondCommaIndex];
    }

    // https://stackoverflow.com/a/2571744/10725664
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