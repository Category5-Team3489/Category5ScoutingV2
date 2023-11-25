

#region Interrupt Cancel Key
using Category5ScoutingV2.Shared;
using Category5ScoutingV2.Shared.Datastore;

CancellationTokenSource cts = new();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = true;
};
#endregion

#region Datastore
var datastore = Datastore.FromJson();
#endregion

#region Bot
bool isBotRunning = false;
void startBot()
{
    if (isBotRunning)
    {
        Console.WriteLine("The bot is already running.");
        return;
    }

    isBotRunning = true;
    Console.WriteLine("Starting bot...");

    _ = Bot.RunAsync(datastore);
}

#if !DEBUG
startBot();
#endif
#endregion

//// TODO Remove
//startBot();
//await Task.Delay(-1);
//return;

#region ASP.NET
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(datastore);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapWeatherForecast();

app.MapGet("/datastore", (Datastore datastore) =>
{
    if (datastore.TryRead<string>(Constants.TestKey, out var test))
    {
        return $"Value: {test}";
    }

    return $"404";
});

app.MapFallbackToFile("/index.html");

#if DEBUG
_ = app.RunAsync();
#endif
#if !DEBUG
_ = app.RunAsync("http://*:25561");
#endif
#endregion

#region Command System
bool isRunning = true;
while (isRunning && !cts.IsCancellationRequested)
{
    await Task.Delay(100);

    {
        datastore.Write(Constants.TestKey, DateTime.Now.ToString());
    }

    if (!Console.KeyAvailable)
    {
        continue;
    }

    var c = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (c)
    {
        case 'x':
            isRunning = false;
            break;
        case 'b':
            startBot();
            break;
    }
}
#endregion
