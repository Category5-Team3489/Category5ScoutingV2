namespace Category5ScoutingV2._Database;

public sealed class DatabaseOpReturnTypeException(Type type) : Exception($"Database operation return type must be a value type or string. Found {type}.");

public static class Db
{
    public static Database Instance { private get; set; } = null!;

    public static void Save()
    {
        Instance.Save();
    }

    public static void Op(Action<Data> action)
    {
        Instance.Op(action);
    }

    public static T Op<T>(Func<Data, T> func)
    {
        return Instance.Op(func);
    }
}

public class Database
{
#if DEBUG
    private const string FilePath = "../../../database.json";
#else
    private const string FilePath = "database.json";
#endif

    private readonly Data data;
    private readonly object dataLock = new();

    public Database()
    {
        try
        {
            string json = File.ReadAllText(FilePath);
            data = JsonConvert.DeserializeObject<Data>(json)!;
        }
        catch { }

        data ??= new();
    }

    public void Save()
    {
        lock (dataLock)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }

    public void Op(Action<Data> action)
    {
        lock (dataLock)
        {
            action(data);
        }
    }

    public T Op<T>(Func<Data, T> func)
    {
        ThrowIfOpReturnTypeIsInvalid<T>();

        lock (dataLock)
        {
            return func(data);
        }
    }

    private static void ThrowIfOpReturnTypeIsInvalid<T>()
    {
        if (!typeof(T).IsValueType && typeof(T) != typeof(string))
        {
            throw new DatabaseOpReturnTypeException(typeof(T));
        }
    }
}