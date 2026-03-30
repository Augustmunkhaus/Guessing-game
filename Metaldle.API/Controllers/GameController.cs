using Metaldle.API.DTO_s;
using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.Services;
using Metaldle.Core.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Metaldle.Core.Ports;
using Metaldle.Core.Domain;

namespace Metaldle.API;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameEngine _gameEngine;
    private readonly IEntityRepository _entityRepository;

    public GameController(GameEngine gameEngine, IEntityRepository entityRepository)
    {
        _gameEngine = gameEngine;
        _entityRepository = entityRepository;
    }

    [HttpPost("start")]
    public async Task<IActionResult> StartGame([FromHeader] string sessionId)
    {
        var session = await _gameEngine.StartOrResumeGameAsync(sessionId);

        var response = new SessionResponse
        {
            SessionId = session.SessionId,
            GameDate = session.GameDate,
            Guesses = session.Guesses,
            Status = session.Status,
            StartedAt = session.StartedAt,
            CompletedAt = session.CompletedAt,
            Hints = session.Hints.Select(h => new HintResponse
            { Label = h.Label, Value = h.Value }).ToList()
        };
        
        response.TargetBand = await GetTargetBandIfGameOver(session);
        
        return Ok(response);
    }

    [HttpPost("guess")]

    public async Task<IActionResult> Guess([FromHeader]string sessionId, [FromBody]GuessRequest request)
    {
        //deconstructing the tuple, to access both session and feedback
        var (session, feedback) = await _gameEngine.SubmitGuessAsync(sessionId, request.GuessedEntity);
        
        var response = new SessionResponse
        {
            Guesses = session.Guesses,
            Status = session.Status,
            Hints = session.Hints.Select(h => new HintResponse
            {
                Label = h.Label,
                Value = h.Value
            }).ToList()
        };
        
        response.TargetBand = await GetTargetBandIfGameOver(session);
        
        return Ok(response);
    }
    
    private async Task<TargetBandResponse?> GetTargetBandIfGameOver(GameSession session)
    {
        if (session.Status != GameStatus.Won && session.Status != GameStatus.Lost)
            return null;
        
        var targetEntity = await _entityRepository.GetByIdAsync(session.TargetEntityId);
        return new TargetBandResponse
        {
            Name = targetEntity.Name,
            Year = targetEntity.NumericAttribute1,
            Members = targetEntity.NumericAttribute2,
            Country = targetEntity.RegionAttribute,
            Continent = targetEntity.ContinentAttribute,
            Status = targetEntity.StatusAttribute,
            Genre =  targetEntity.GenreAttribute,
            Themes = targetEntity.ListAttribute1,
            Vocals = targetEntity.ListAttribute2,
            SubGenres = targetEntity.ListAttribute3,
            ImageUrl = targetEntity.ImageUrl
        };
    }
    
    [HttpPost("newgame")]
    public async Task<IActionResult> NewGame([FromHeader] string sessionId)
    {
        var session = await _gameEngine.StartFreshGameAsync(sessionId);
    
        var response = new SessionResponse
        {
            SessionId = session.SessionId,
            GameDate = session.GameDate,
            Guesses = session.Guesses,
            Status = session.Status,
            StartedAt = session.StartedAt,
            CompletedAt = session.CompletedAt
        };
    
        return Ok(response);
    }
    
}
