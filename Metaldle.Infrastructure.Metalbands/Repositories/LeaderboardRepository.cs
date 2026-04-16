using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Ports;
using Metaldle.infrastructure.Metalbands;
using Microsoft.EntityFrameworkCore;

namespace Metaldle.Infrastructure.Metalbands.Repositories;

public class LeaderboardRepository : ILeaderboardRepository
{
    private readonly AppDbContext _context;

    public LeaderboardRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddEntryAsync(LeaderboardEntry entry)
    {
        _context.LeaderboardEntries.Add(entry);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> HasSessionSubmittedAsync(string sessionId, DateOnly date)
    {
        return await _context.LeaderboardEntries
            .AnyAsync(e => e.SessionId == sessionId && e.Date == date);
    }

    public async Task<IEnumerable<LeaderboardEntry>> GetEntriesByDateAsync(DateOnly date)
    {
        return await _context.LeaderboardEntries
            .Where(e => e.Date == date)
            .OrderBy(e => e.GuessCount)
            .ToListAsync();
    }
    
}