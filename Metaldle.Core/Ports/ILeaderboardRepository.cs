using Metaldle.Core.Domain.Entities;

namespace Metaldle.Core.Ports;

public interface ILeaderboardRepository
{
    Task AddEntryAsync(LeaderboardEntry entry);
    Task<bool> HasSessionSubmittedAsync(string sessionId, DateOnly date);
    Task<IEnumerable<LeaderboardEntry>> GetEntriesByDateAsync(DateOnly date);
}