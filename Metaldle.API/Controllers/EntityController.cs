using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Metaldle.Core.Ports;

[ApiController]
[Route("api/[controller]")]
public class EntityController : ControllerBase
{
    private readonly IEntityRepository _repository;

    public EntityController(IEntityRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("entities")]
    public async Task<IActionResult> Get()
    {
        var response = await _repository.GetAllAsync();
        //getting all entities but only returning the name, since thats all the frontend needs from this method
        return Ok(response.Select(b => b.Name));
    }
}