﻿using Category5ScoutingV2;
using Category5ScoutingV2.Database;
using Category5ScoutingV2.TbaApi;

CancellationTokenSource cts = new();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = true;
};

Console.WriteLine("Hello, World!");

#region Database
#if DEBUG
string dbFilePath = "../../../database.dat";
#else
string dbFilePath = "database.dat";
#endif

Db db = new(dbFilePath);
#endregion

#region TBA
string tbaApiKey = db.Op(data => data.TbaApiKey);
Tba tba = new(tbaApiKey);
#endregion

db.Op(data =>
{
    data.Events.Add(new Event(2024, "2024scand", [], new()
    {
        [new TeamAndEvent(3489, "2024scand")] = new Modal("test")
    }));
});

await Bot.RunAsync(db, tba);

const double SaveIntervalSeconds = 30;
while (!cts.IsCancellationRequested)
{
    db.Save();
    await Task.Delay(TimeSpan.FromSeconds(SaveIntervalSeconds));
}

db.Save();