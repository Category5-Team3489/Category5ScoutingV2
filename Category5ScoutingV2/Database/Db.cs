using System.Text.Json;

namespace Category5ScoutingV2.Database;

public class DbOpTypeException(Type type) : Exception($"Db operation type must be a value type or string. Found {type}.");

public class Db
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        WriteIndented = true
    };

    private readonly string filePath;

    private readonly Data data;
    private readonly object dataLock = new();

    public Db(string filePath)
    {
        jsonSerializerOptions.Converters.Add(new TeamAndEventJsonConverter());

        this.filePath = filePath;

        try
        {
            string json = File.ReadAllText(filePath);
            data = JsonSerializer.Deserialize<Data>(json, jsonSerializerOptions)!;
        }
        catch { }

        data ??= new();
    }

    public void Save()
    {
        lock (dataLock)
        {
            string json = JsonSerializer.Serialize(data, jsonSerializerOptions);
            File.WriteAllText(filePath, json);
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
        CheckType<T>();

        lock (dataLock)
        {
            return func(data);
        }
    }

    private static void CheckType<T>()
    {
        if (!typeof(T).IsValueType && typeof(T) != typeof(string))
        {
            throw new DbOpTypeException(typeof(T));
        }
    }
}