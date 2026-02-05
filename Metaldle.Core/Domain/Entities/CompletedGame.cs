namespace Metaldle.Core.Domain.Entities;

public class CompletedGame
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid TargetEntityId { get; set; }
    
    public DateOnly GameDate { get; set; }
    
    public bool Won { get; set; }
    
    public int GuessCount { get; set; }
    
    public DateTime CompletedAt { get; set; }
}