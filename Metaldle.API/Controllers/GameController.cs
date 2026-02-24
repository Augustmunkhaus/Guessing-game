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

    public GameController(GameEngine gameEngine)
    {
        _gameEngine = gameEngine;
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
            CompletedAt = session.CompletedAt
        };

        return Ok(response);
    }

    [HttpPost("guess")]

    public async Task<IActionResult> Guess([FromHeader]string sessionId, [FromBody]GuessRequest request)
    {
        //deconstructing the tuple, to access both session and feedback
        var (session, feedback) = await _gameEngine.SubmitGuessAsync(sessionId, request.GuessedEntity);
        
        var response = new GuessResponse
        {
            Guesses = session.Guesses,
            Status = session.Status
        };
        
        return Ok(response);
    }
}
