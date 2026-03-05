using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;

namespace Metaldle.API.DTO_s;

public class GuessResponse
{
    public List<Guess> Guesses { get; set; }
    public GameStatus Status { get; set; }
    
    public TargetBandResponse? TargetBand { get; set; }
}