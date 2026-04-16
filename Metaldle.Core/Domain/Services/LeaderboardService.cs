using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;
using Metaldle.Core.Ports;

public class LeaderboardService
{
    private readonly ILeaderboardRepository _leaderboardRepository;
    private readonly ISessionRepository _sessionRepository;

    public LeaderboardService(ILeaderboardRepository leaderboardRepository, ISessionRepository sessionRepository)
    {
        _leaderboardRepository = leaderboardRepository;
        _sessionRepository = sessionRepository;
    }

    public async Task<bool> SubmitEntryAsync(string sessionId, string displayName)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var session = await _sessionRepository.GetTodaysSessionAsync(sessionId, today);

        if (session == null)
        {
            Console.WriteLine("LEADERBOARD: session is null");
            return false;
        }

        if (session.Status != GameStatus.Won && session.Status != GameStatus.Lost)
        {
            Console.WriteLine($"LEADERBOARD: wrong status: {session.Status}");
            return false;
        }

        if (!session.IsDaily)
        {
            Console.WriteLine("LEADERBOARD: not a daily game");
            return false;
        }

        if (await _leaderboardRepository.HasSessionSubmittedAsync(sessionId, today))
        {
            Console.WriteLine("LEADERBOARD: already submitted");
            return false;
        }

        var entry = new LeaderboardEntry
        {
            Id = Guid.NewGuid(),
            DisplayName = displayName,
            GuessCount = session.Guesses.Count,
            Date = today,
            SessionId = sessionId,
            SubmittedAt = DateTime.UtcNow
        };

        await _leaderboardRepository.AddEntryAsync(entry);
        return true;
    }

    public async Task<IEnumerable<LeaderboardEntry>> GetTodaysLeaderboardAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        return await _leaderboardRepository.GetEntriesByDateAsync(today);
    }
}