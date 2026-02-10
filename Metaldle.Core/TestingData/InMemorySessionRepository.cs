// Metaldle.Core/Testing/InMemorySessionRepository.cs
namespace Metaldle.Core.Testing;

using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Ports;

//fake session repository for testing, implementing the interface methods for a session.

public class InMemorySessionRepository : ISessionRepository
{
    // Dictionary to store sessions: "sessionId:date" -> GameSession
    private readonly Dictionary<string, GameSession> _sessions = new();

    private string GetKey(string sessionId, DateOnly date)
    {
        return $"{sessionId}:{date:yyyy-MM-dd}";
    }

    public Task<GameSession?> GetTodaysSessionAsync(string sessionId, DateOnly date)
    {
        var key = GetKey(sessionId, date);
        _sessions.TryGetValue(key, out var session);
        return Task.FromResult(session);
    }

    public Task SaveSessionAsync(GameSession session)
    {
        var key = GetKey(session.SessionId, session.GameDate);
        _sessions[key] = session;
        return Task.CompletedTask;
    }

    public Task DeleteSessionAsync(string sessionId, DateOnly date)
    {
        var key = GetKey(sessionId, date);
        _sessions.Remove(key);
        return Task.CompletedTask;
    }

    public Task<bool> HasActiveSessionAsync(string sessionId, DateOnly date)
    {
        var key = GetKey(sessionId, date);
        return Task.FromResult(_sessions.ContainsKey(key));
    }
}