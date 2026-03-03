using System.Net.Http.Json;
using System.Text.Json;
using Metaldle.BlazorWASM.Models;

namespace Metaldle.BlazorWASM.Services;

public class MetaldleApiService
{
    private readonly HttpClient _http;

    public MetaldleApiService(HttpClient http)
    {
        _http = http;
    }
    
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };
    
    //methods to call the API endpoints
    /*public async Task<List<String>?> SearchEntitiesAsync(string query)
    {
        return await _http.GetFromJsonAsync<List<string>>($"/api/entities/search?q={query}");
    }
    */
    
    public async Task<List<string>?> GetAllEntitiesAsync()
    {
        return await _http.GetFromJsonAsync<List<string>>("/api/entity/entities");
    }

    public async Task<SessionResponse?> StartGameAsync(string sessionId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/game/start");
        request.Headers.Add("sessionId", sessionId);
        var response = await _http.SendAsync(request);
        return await response.Content.ReadFromJsonAsync<SessionResponse>(_jsonOptions);
    }

    public async Task<SessionResponse?> MakeGuessAsync(string sessionId, string guessedEntity)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/game/guess");
        request.Headers.Add("sessionId", sessionId);
        request.Content = JsonContent.Create(new { guessedEntity }); 
        var response = await _http.SendAsync(request);
        return await response.Content.ReadFromJsonAsync<SessionResponse>(_jsonOptions);
    }
}