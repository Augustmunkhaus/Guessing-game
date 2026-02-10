// Metaldle.Core/Testing/InMemoryEntityRepository.cs
namespace Metaldle.Core.Testing;

using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Ports;

//Fake repository to test the fake testdata. creates a list of type IguessableEntity called _entities,
//and loads the testdata into this list. implementations of the interface methods.

public class InMemoryEntityRepository : IEntityRepository
{
    private readonly List<IGuessableEntity> _entities;

    public InMemoryEntityRepository()
    {
        // Load test data and convert to interface type
        _entities = TestData.GetTestBands()
            .Cast<IGuessableEntity>()
            .ToList();
    }

    public Task<IGuessableEntity?> GetByIdAsync(Guid id)
    {
        var entity = _entities.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(entity);
    }

    public Task<List<IGuessableEntity>> GetAllAsync()
    {
        return Task.FromResult(_entities.ToList());
    }

    public Task<List<IGuessableEntity>> SearchByNameAsync(string query)
    {
        var results = _entities
            .Where(e => e.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return Task.FromResult(results);
    }

    public Task<IGuessableEntity> GetRandomAsync(int seed)
    {
        var random = new Random(seed);
        var index = random.Next(_entities.Count);
        return Task.FromResult(_entities[index]);
    }

    public Task<int> GetCountAsync()
    {
        return Task.FromResult(_entities.Count);
    }
}