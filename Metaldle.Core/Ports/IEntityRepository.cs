namespace Metaldle.Core.Ports;

using Metaldle.Core.Domain.Entities;

public interface IEntityRepository
{
    // Get a specific entity by ID
    Task<IGuessableEntity?> GetByIdAsync(Guid id);
    
    // Get all entities (for autocomplete/search)
    Task<List<IGuessableEntity>> GetAllAsync();
    
    // Search entities by name (for autocomplete)
    Task<List<IGuessableEntity>> SearchByNameAsync(string query);
    
    // Get a random entity (for daily target selection)
    Task<IGuessableEntity> GetRandomAsync(int seed);
    
    // Get total count (for statistics)
    Task<int> GetCountAsync();
}