namespace Metaldle.Core.Domain.Services;
using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.Services;
using Metaldle.Core.Domain.ValueObjects;
using Metaldle.Core.Ports;

//Accepts calls from the API and delegates the calls to one of the 3 services, which handles game logic
public class GameEngine
{
    private readonly GameSessionService _sessionService;
    private readonly GuessService _guessService;

    public GameEngine(GameSessionService sessionService, GuessService guessService)
    {
        _sessionService = sessionService;
        _guessService = guessService;
    }

    public async Task<GameSession> StartOrResumeGameAsync(string sessionId)
    {
        return await _sessionService.StartOrResumeAsync(sessionId);
    }
    
    public async Task<(GameSession, FeedbackResult)> SubmitGuessAsync(string sessionId, string guess)
    {
        return await _guessService.ProcessGuessAsync(sessionId, guess);
    }

    public async Task<GameSession?> CheckCurrentSessionAsync(string sessionId)
    {
        return await _sessionService.CheckCurrentSessionAsync(sessionId);
    }
}