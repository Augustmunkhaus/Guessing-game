using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;

namespace Metaldle.API.DTO_s;
//DTO for removing targetentity, since that cant be shown to the user when playing
public class SessionResponse
{
    public string SessionId { get; set; }
    public DateOnly GameDate { get; set; }
    public List<Guess> Guesses { get; set; }
    public GameStatus Status { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    public TargetBandResponse? TargetBand { get; set; }
    
    public List<HintResponse> Hints { get; set; } = new();
}