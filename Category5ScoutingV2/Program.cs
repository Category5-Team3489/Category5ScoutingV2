CancellationTokenSource cts = new();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = true;
};

Console.WriteLine("Hello, World!");

Secrets secrets = Secrets.Load();

Db.Instance = new();
Tba.AuthKey = secrets.TbaAuthKey;

await Bot.RunAsync(secrets.BotToken);

const double SaveIntervalSeconds = 3;
while (!cts.IsCancellationRequested)
{
    Db.Save();
    await Task.Delay(TimeSpan.FromSeconds(SaveIntervalSeconds));
}

Db.Save();

// To-Do
/*
 * Get saving modals working
*/

// Maybes
/*
 * Ephemeral Interactions, "DeferAsync"
 * 
*/