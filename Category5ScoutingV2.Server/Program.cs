using Category5ScoutingV2.Server;

#region Interrupt Cancel Key
CancellationTokenSource cts = new();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = true;
};
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

    _ = Bot.RunAsync();
}

#if !DEBUG
startBot();
#endif
#endregion

#region ASP.NET
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapWeatherForecast();

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

    if (Console.KeyAvailable)
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
