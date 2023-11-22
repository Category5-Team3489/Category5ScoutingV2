CancellationTokenSource cts = new();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = true;
};

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
bool isBotRunning = false;
while (isRunning && !cts.IsCancellationRequested)
{
    await Task.Delay(100);

    if (Console.KeyAvailable)
    {
        continue;
    }

    var c = Console.ReadKey().KeyChar;

    switch (c)
    {
        case 'x':
            isRunning = false;
            break;
        case 'b':
            if (!isBotRunning)
            {
                isBotRunning = true;

                Console.WriteLine("\nStarting bot...");

                _ = Bot.RunAsync();
            }
            else
            {
                Console.WriteLine("The bot is already running.");
            }
            break;
    }
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
