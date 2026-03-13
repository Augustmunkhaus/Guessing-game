namespace Metaldle.BlazorWASM.Models;

public class FeedbackResponse
{
    public bool IsCorrect { get; set; }
    public NumericFeedback Numeric1 { get; set; } = new();
    public NumericFeedback Numeric2 { get; set; } = new();
    public CategoryFeedback Region { get; set; } = new();
    public CategoryFeedback Continent { get; set; } = new();
    public CategoryFeedback Status { get; set; } = new();
    public CategoryFeedback Genre { get; set; } = new();
    public ListFeedback List1 { get; set; } = new();
    public ListFeedback List2 { get; set; } = new();
    public ListFeedback List3 { get; set; } = new();
}