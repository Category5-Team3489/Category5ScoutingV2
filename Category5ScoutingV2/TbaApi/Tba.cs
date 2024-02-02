using System.Net.Http.Json;

namespace Category5ScoutingV2.TbaApi;

public class TbaApiException(string endpoint) : Exception($"Get request to {endpoint} failed.");

public class Tba(string apiKey)
{
    private readonly HttpClient Http = new(new SocketsHttpHandler()
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(10),
        PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
        MaxConnectionsPerServer = 10,
    });

    private readonly string apiKey = apiKey;

    public async Task<T> Get<T>(string endpoint)
    {
        var value = await GetNullable<T>(endpoint);
        return value == null ? throw new TbaApiException(endpoint) : value;
    }

    public async Task<T?> GetNullable<T>(string endpoint)
    {
        return await Http.GetFromJsonAsync<T>(GetUrl(endpoint));
    }

    public async Task<string> GetString(string endpoint)
    {
        return await Http.GetStringAsync(GetUrl(endpoint));
    }

    private string GetUrl(string endpoint) => $"https://www.thebluealliance.com/api/v3{endpoint}?X-TBA-Auth-Key={apiKey}";
}