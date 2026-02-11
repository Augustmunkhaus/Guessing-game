// Metaldle.Core/Domain/Services/GuessService.cs

using System.Threading.Tasks.Dataflow;
using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;
using Metaldle.Core.Ports;

namespace Metaldle.Core.Domain.Services;
using System; 
using System.Linq;
public class GuessService
{
    private readonly IEntityRepository _entityRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly FeedbackService _feedbackService;
    private const int MaxGuesses = 6;

    public GuessService(
        IEntityRepository entityRepository,
        ISessionRepository sessionRepository,
        FeedbackService feedbackService)
    {
        _entityRepository = entityRepository;
        _sessionRepository = sessionRepository;
        _feedbackService = feedbackService;
    }
    
    private DateOnly GetToday()
    {
        return DateOnly.FromDateTime(DateTime.UtcNow);
    }

    public async Task<(GameSession session, FeedbackResult feedback)> ProcessGuessAsync(string sessionId, string guessedEntityName)
    {
        //step 1 - get session
        var today = GetToday();
        var todaysSession = await _sessionRepository.GetTodaysSessionAsync(sessionId, today);

        if (todaysSession == null)
        {
            throw new InvalidOperationException("No active game session found. Please start a new game.");
        }
        //step 2 - validate game status
        if (todaysSession.Status != GameStatus.InProgress)
        {
            throw new InvalidOperationException($"game is {todaysSession.Status}. start a new game");
        } 
        //step 3 - get the guessed entity
        var entities = await _entityRepository.GetAllAsync();
        
        var guessedEntity = entities.FirstOrDefault(e => 
            string.Equals(e.Name, guessedEntityName, StringComparison.OrdinalIgnoreCase));

        if (guessedEntity == null)
        {
            throw new InvalidOperationException($"entity {guessedEntityName} not found");
        }
        
        //step 4 - get the target entity
        var targetEntity = await _entityRepository.GetByIdAsync(todaysSession.TargetEntityId);
        
        if (targetEntity == null)
        {
            throw new InvalidOperationException("Target entity not found.");
        }
        
        //step 5 - generate feedback
        var feedback = _feedbackService.GenerateFeedback(guessedEntity, targetEntity);
        
        //step 6 - create guess object and add to session

        var guessObject = new Guess
        {
            GuessedEntityId = guessedEntity.Id,
            GuessedEntityName = guessedEntity.Name,
            GuessedAt = DateTime.UtcNow,
            Feedback = feedback,

        };
        
        todaysSession.Guesses.Add(guessObject);
        
        //step 7 - update game status

        if (feedback.IsCorrect)
        {
            todaysSession.Status = GameStatus.Won;
            todaysSession.CompletedAt = DateTime.UtcNow;
        }
        else if (todaysSession.Guesses.Count >= 6)
        {
            todaysSession.Status = GameStatus.Lost;
            todaysSession.CompletedAt = DateTime.UtcNow;
        }
        
        //step 8 - save session

        await _sessionRepository.SaveSessionAsync(todaysSession);
        
        //step 9 - return result
        
        return (todaysSession, feedback);
        
    }
}