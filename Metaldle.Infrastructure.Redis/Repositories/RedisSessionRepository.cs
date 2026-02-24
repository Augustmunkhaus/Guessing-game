using System.Text.Json;
using StackExchange.Redis;
using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Ports;

namespace Metaldle.Infrastructure.Redis.Repositories;

//Implementation of the redis interface, saving and getting sessions. sessions stored for 24 hours.

public class RedisSessionRepository : ISessionRepository
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _db;

    public RedisSessionRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _db = redis.GetDatabase();
    }

    private string GetSessionKey(string sessionId, DateOnly date)
    {
        return $"session:{sessionId}:{date:yyyy-MM-dd}";
    }

    public async Task<GameSession?> GetTodaysSessionAsync(string sessionId, DateOnly date)
    {
        var key = GetSessionKey(sessionId, date);
        
        var json = await _db.StringGetAsync(key);
        
        if (json.IsNullOrEmpty)
        {
            return null;
        }
        return JsonSerializer.Deserialize<GameSession>(json!);
    }

    public async Task SaveSessionAsync(GameSession session)
    {
        var key = GetSessionKey(session.SessionId, session.GameDate);
        
        var json = JsonSerializer.Serialize(session);
        
        await _db.StringSetAsync(key, json, TimeSpan.FromHours(24));
        
    }

    public async Task DeleteSessionAsync(string sessionId, DateOnly date)
    {
        var key = GetSessionKey(sessionId, date);
        
        await _db.KeyDeleteAsync(key);
        
    }

    public async Task<bool> HasActiveSessionAsync(string sessionId, DateOnly date)
    {
        var key = GetSessionKey(sessionId, date);
        
        if(await _db.KeyExistsAsync(key))
        {
            return true;
        }

        return false;
    }
}