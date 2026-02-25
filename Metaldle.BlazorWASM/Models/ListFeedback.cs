namespace Metaldle.BlazorWASM.Models;

public class ListFeedback
{
    public List<string> Values { get; set; } = new();
    public string Match { get; set; } = "";
    public List<string> MatchedItems { get; set; } = new();
}