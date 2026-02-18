using Microsoft.EntityFrameworkCore;
using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Ports;
using Metaldle.infrastructure.Metalbands;

namespace Metaldle.Infrastructure.Metalbands.Repositories;
//Concrete implementation of the IEntityRepository
public class MetalBandRepository : IEntityRepository
{
    private readonly AppDbContext _context;

    public MetalBandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IGuessableEntity?> GetByIdAsync(Guid id)
    {
        var band = await _context.MetalBands.SingleOrDefaultAsync(b => b.Id == id);
        return band;
    }

    public async Task<List<IGuessableEntity>> GetAllAsync()
    {
        var bands = await _context.MetalBands.ToListAsync();
        
        return bands.Cast<IGuessableEntity>().ToList();

    }

    public async Task<List<IGuessableEntity>> SearchByNameAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new List<IGuessableEntity>();
        
        var searchBands = await _context.MetalBands
            .Where(b => b.Name.ToLower().Contains(query.ToLower()))
            .Take(10)
            .ToListAsync();
        
        return searchBands.Cast<IGuessableEntity>().ToList();
    }

    public async Task<IGuessableEntity> GetRandomAsync(int seed)
    {
        var count = await _context.MetalBands.CountAsync();
        if (count == 0)
            throw new InvalidOperationException("no entities in database");
        
        var random = new Random(seed);
        var skipCount = random.Next(0, count);

        var randomBand = await _context.MetalBands
            .OrderBy(b => b.Id) 
            .Skip(skipCount)
            .FirstAsync();
        
        return randomBand;
    }

    public async Task<int> GetCountAsync()
    {
        var bands = await _context.MetalBands.CountAsync();
        
        return bands;
    }
}