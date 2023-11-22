CancellationTokenSource cts = new();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = true;
};

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

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapFallbackToFile("/index.html");

_ = app.RunAsync(/*"https://*:12345"*/);

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

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
