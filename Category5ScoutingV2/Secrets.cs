namespace Category5ScoutingV2;

public record Secrets(string BotToken, string TbaAuthKey)
{
#if DEBUG
    private const string FilePath = "../../../secrets.json";
#else
    private const string FilePath = "secrets.json";
#endif

    public static Secrets Load()
    {
        string json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<Secrets>(json) ?? throw new Exception("Unable to deserialize secrets.");
    }

    //public static void SaveEmpty()
    //{
    //    string json = JsonConvert.SerializeObject(new Secrets("", ""));
    //    File.WriteAllText(FilePath, json);
    //}
}
