using System.Net.Http.Json;
using System.Text.Json;

namespace Metaldle.BlazorWASM.Services;

public class SpotifyService
{
    private readonly HttpClient _http;
    private string? _accessToken;
    private Dictionary<string, string>? _trackDictionary;

    private const string ClientId = "ac0500727bea49acbaca812d49e20f05";
    private const string ClientSecret = "612e8bf54b1f40f1b71ebaaeb7d07e48";

    public SpotifyService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string?> GetTrackIdAsync(string bandName)
    {
        _trackDictionary ??= await LoadTrackDictionaryAsync();

        if (!_trackDictionary.TryGetValue(bandName, out var topTrack))
            return null;

        _accessToken ??= await GetAccessTokenAsync();
        if (_accessToken == null) return null;

        return await SearchTrackAsync(topTrack, bandName);
    }

    private async Task<Dictionary<string, string>> LoadTrackDictionaryAsync()
    {
        var json = await _http.GetFromJsonAsync<Dictionary<string, LastFmEntry>>("lastfm_results.json");
        return json?.ToDictionary(x => x.Key, x => x.Value.TopTrack) ?? new();
    }

    private async Task<string?> GetAccessTokenAsync()
    {
        var credentials = Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"));

        var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
        request.Headers.Authorization = new("Basic", credentials);
        request.Content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });

        var response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadFromJsonAsync<JsonElement>();
        return data.GetProperty("access_token").GetString();
    }

    private async Task<string?> SearchTrackAsync(string track, string artist)
    {
        var query = Uri.EscapeDataString($"track:{track} artist:{artist}");
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.spotify.com/v1/search?q={query}&type=track&limit=1");
        request.Headers.Authorization = new("Bearer", _accessToken);

        var response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadFromJsonAsync<JsonElement>();
        return data
            .GetProperty("tracks")
            .GetProperty("items")[0]
            .GetProperty("id")
            .GetString();
    }

    private record LastFmEntry(string TopTrack);
}