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
}