using System.Net.Http.Json;
using Metaldle.BlazorWASM.Models;

namespace Metaldle.BlazorWASM.Services;

public class MetaldleApiService
{
    private readonly HttpClient _http;

    public MetaldleApiService(HttpClient http)
    {
        _http = http;
    }
    //methods to call the API endpoints
    public async Task<List<String>?> SearchEntitiesAsync(string query)
    {
        return await _http.GetFromJsonAsync<List<string>>($"/api/entities/search?q={query}");
    }

    public async Task<SessionResponse?> StartGameAsync(string sessionId)
    {
       var response = await _http.PostAsJsonAsync("/api/game/start", new {sessionId});
       return await response.Content.ReadFromJsonAsync<SessionResponse>();
    }

    public async Task<SessionResponse?> MakeGuessAsync(string sessionId, string guessedEntity)
    {
        var response = await _http.PostAsJsonAsync("/api/game/guess", new { sessionId, guessedEntity });
        return await response.Content.ReadFromJsonAsync<SessionResponse>();
    }
}