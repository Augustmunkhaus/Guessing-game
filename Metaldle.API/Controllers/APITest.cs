using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Metaldle.Core.Ports;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IEntityRepository _repository;

    public TestController(IEntityRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetCount()
    {
        var count = await _repository.GetCountAsync();
        return Ok(new { count });
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandom()
    {
        var band = await _repository.GetRandomAsync(DateTime.Now.DayOfYear);
        return Ok(new { name = band.Name });
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string q)
    {
        var results = await _repository.SearchByNameAsync(q);
        return Ok(results.Select(b => b.Name));
    }
    [HttpGet("redis-test")]
    public async Task<IActionResult> TestRedis([FromServices] ISessionRepository sessionRepo)
    {
        var sessionId = "test-user-123";
        var today = DateOnly.FromDateTime(DateTime.Now);
    
        // Check if session exists
        var exists = await sessionRepo.HasActiveSessionAsync(sessionId, today);
        if (exists)
        {
            var session = await sessionRepo.GetTodaysSessionAsync(sessionId, today);
            return Ok(new { message = "Session found", session });
        }
    
        // Create a test session
        var newSession = new GameSession
        {
            SessionId = sessionId,
            GameDate = today,
            TargetEntityId = Guid.NewGuid(),
            Guesses = new List<Guess>(),
            Status = GameStatus.InProgress
        };
    
        await sessionRepo.SaveSessionAsync(newSession);
    
        return Ok(new { message = "Session created", newSession });
    }
}