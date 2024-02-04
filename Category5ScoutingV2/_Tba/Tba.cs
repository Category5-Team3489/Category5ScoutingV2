using System.Net.Http.Json;

namespace Category5ScoutingV2._Tba;

public sealed class TbaApiException(string endpoint, Exception? innerException = null) : Exception($"Get request to {endpoint} failed.", innerException);

public static class Tba
{
    public static string AuthKey { private get; set; } = "";

    private static readonly HttpClient Http = new(new SocketsHttpHandler()
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(10),
        PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
        MaxConnectionsPerServer = 10,
    });

    public static async Task<T> Get<T>(string endpoint)
    {
        try
        {
            var value = await GetNullable<T>(endpoint);
            return value ?? throw new TbaApiException(endpoint);
        }
        catch (Exception ex)
        {
            throw new TbaApiException(endpoint, ex);
        }
    }

    public static async Task<T?> GetNullable<T>(string endpoint)
    {
        try
        {
            return await Http.GetFromJsonAsync<T>(GetUrlWithEndpoint(endpoint));
        }
        catch (Exception ex)
        {
            throw new TbaApiException(endpoint, ex);
        }
    }

    public static async Task<string> GetString(string endpoint)
    {
        try
        {
            return await Http.GetStringAsync(GetUrlWithEndpoint(endpoint));
        }
        catch (Exception ex)
        {
            throw new TbaApiException(endpoint, ex);
        }
    }

    private static string GetUrlWithEndpoint(string endpoint) => $"https://www.thebluealliance.com/api/v3{endpoint}?X-TBA-Auth-Key={AuthKey}";
}