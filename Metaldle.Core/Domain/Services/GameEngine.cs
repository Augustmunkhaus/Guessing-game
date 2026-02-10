using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;
using Metaldle.Core.Ports;

//Accepts calls from the API and delegates the calls to one of the 3 services, which handles game logic
/*
namespace Metaldle.Core.Domain.Services;

public class GameEngine
{
    private readonly GameSessionService _sessionService;
    private readonly GuessService _guessService;
    
    public GameEngine(
        IEntityRepository entityRepository, 
        ISessionRepository sessionRepository)
    {
        _sessionService = new GameSessionService(sessionRepository, entityRepository);
        _guessService = new GuessService(entityRepository, sessionRepository);
    }
    
    public Task<GameSession> StartOrResumeGameAsync(string sessionId)
        => _sessionService.StartOrResumeAsync(sessionId);
    
    public Task<(GameSession, FeedbackResult)> SubmitGuessAsync(string sessionId, string guess)
        => _guessService.ProcessGuessAsync(sessionId, guess);
        
    public Task<GameSession?> GetCurrentSessionAsync(string sessionId)
        => _sessionService.GetCurrentSessionAsync(sessionId);
}
*/