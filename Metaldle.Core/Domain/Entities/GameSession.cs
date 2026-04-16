using Metaldle.Core.Domain.ValueObjects;

namespace Metaldle.Core.Domain.Entities;

public class GameSession
{
    public Guid Id { get; set; }
    public string SessionId { get; set; } = string.Empty;  
    public Guid TargetEntityId { get; set; }
    public DateOnly GameDate { get; set; }
    public List<Guess> Guesses { get; set; } = new();
    public GameStatus Status { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public List<Hint> Hints { get; set; } = new();
    public bool IsDaily { get; set; }
}