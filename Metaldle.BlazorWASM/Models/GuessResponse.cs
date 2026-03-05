namespace Metaldle.BlazorWASM.Models;

public class GuessResponse
{
    public string GuessedEntityName { get; set; } = "";
    public FeedbackResponse Feedback { get; set; } = new();

    public TargetBandResponse? TargetBand { get; set; }
}