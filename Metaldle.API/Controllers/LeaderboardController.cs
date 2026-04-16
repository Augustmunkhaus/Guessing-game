using Metaldle.API.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace Metaldle.API;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly LeaderboardService _leaderboardService;

    public LeaderboardController(LeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitEntry([FromBody] EntryRequest request)
    {
        var success = await _leaderboardService.SubmitEntryAsync(request.SessionId, request.DisplayName);

        if (!success)
            return BadRequest("Unable to submit entry.");

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetTodaysLeaderboard()
    {
        var entries = await _leaderboardService.GetTodaysLeaderboardAsync();
        return Ok(entries);
    }
}