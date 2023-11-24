

#region Interrupt Cancel Key
using System.Diagnostics;
using Category5ScoutingV2.Shared.Datastore;

CancellationTokenSource cts = new();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = true;
};
#endregion

#region Datastore

Type t = typeof(string);
string n = t.AssemblyQualifiedName!;
Console.WriteLine(n);
Type y = Type.GetType(n)!;
Console.WriteLine(y);

return;
var datastore = Datastore.FromJson();

var stopwatch = Stopwatch.StartNew();

const int Iterations = 10_000;
int processorCount = Environment.ProcessorCount;
int totalIterations = Iterations * processorCount;

Parallel.For(0, processorCount, new ParallelOptions()
{
    MaxDegreeOfParallelism = processorCount,
}, i =>
{
    //Console.WriteLine($"{i}: {Environment.CurrentManagedThreadId}");

    int start = i * Iterations;
    int end = (i + 1) * Iterations;
    for (int j = start; j < end; j++)
    {
        datastore.Write(DatastoreKey.Unsafe(null, j.ToString()), j);
    }
});

//// check by going through sum, use i + i n times formula

//for (int i = 0; i < Iters; i++)
//{
//    // 453_992 per / sec
//    datastore.Write(DatastoreKey.Unsafe(null, i.ToString()), i);

//    // 1067243 per / sec
//    //datastore.Write(DatastoreKey.Typed<int>(i.ToString()), i);
//}

stopwatch.Stop();
Console.WriteLine($"Finished in {stopwatch.Elapsed.TotalSeconds} seconds.");
Console.WriteLine(totalIterations / stopwatch.Elapsed.TotalSeconds);

//var json = datastore.ToJson();
#endregion

return;
#pragma warning disable CS0162 // Unreachable code detected
_ = 0;

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
