namespace Metaldle.Core.Domain.Entities;

public class LeaderboardEntry
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = "";
    public int GuessCount { get; set; }
    public DateOnly Date { get; set; }
    public string SessionId { get; set; } = "";
    public DateTime SubmittedAt { get; set; }
}