using Metaldle.Core.Domain.ValueObjects;

namespace Metaldle.Core.Domain.Entities;

public class Guess
{
    public Guid GuessedEntityId { get; set; }
    
    public string GuessedEntityName { get; set; } = string.Empty;
    
    public DateTime GuessedAt { get; set; }
    
    public FeedbackResult Feedback { get; set; } = new();
}