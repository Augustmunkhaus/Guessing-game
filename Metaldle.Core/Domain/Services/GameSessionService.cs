using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;
using Metaldle.Core.Ports;

namespace Metaldle.Core.Domain.Services;

//Start a new game session or resume ongoing or check/read current session

public class GameSessionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IEntityRepository _entityRepository;

    public GameSessionService(
        ISessionRepository sessionRepository,
        IEntityRepository entityRepository)
    {
        _sessionRepository = sessionRepository;
        _entityRepository = entityRepository;
    }

    private DateOnly GetToday()
    {
        return DateOnly.FromDateTime(DateTime.UtcNow);
    }
    
    public async Task<GameSession> StartOrResumeAsync(string sessionId)
    {

        var today = GetToday();
        
        var existingSession = await _sessionRepository.GetTodaysSessionAsync(sessionId, today);

        if (existingSession != null)
        {
            return existingSession;
        }

        var seed = today.GetHashCode();
        
        var targetEntity = await _entityRepository.GetRandomAsync(seed);

        var newSession = new GameSession
        {
            Id = Guid.NewGuid(),
            SessionId = sessionId,
            TargetEntityId = targetEntity.Id,
            GameDate = today,
            Status = GameStatus.InProgress,
            StartedAt = DateTime.UtcNow,
            Guesses = new List<Guess>()

        };

        await _sessionRepository.SaveSessionAsync(newSession);
        
        return newSession;
        
    }
    
    public async Task<GameSession> StartFreshGameAsync(string sessionId)
    {
        var seed = Guid.NewGuid().GetHashCode();
    
        var targetEntity = await _entityRepository.GetRandomAsync(seed);

        var newSession = new GameSession
        {
            Id = Guid.NewGuid(),
            SessionId = sessionId,
            TargetEntityId = targetEntity.Id,
            GameDate = GetToday(),
            Status = GameStatus.InProgress,
            StartedAt = DateTime.UtcNow,
            Guesses = new List<Guess>()
        };

        await _sessionRepository.SaveSessionAsync(newSession);
    
        return newSession;
    }

    public async Task<GameSession?> CheckCurrentSessionAsync(string sessionId)
    {
        var today = GetToday();
        
       return await _sessionRepository.GetTodaysSessionAsync(sessionId, today);
       
    }
}