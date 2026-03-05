namespace Metaldle.BlazorWASM.Models;

public class SessionResponse
{
    public List<GuessResponse> Guesses { get; set; } = new();
    public string Status { get; set; } = "";
    
    public TargetBandResponse? TargetBand { get; set; }
}