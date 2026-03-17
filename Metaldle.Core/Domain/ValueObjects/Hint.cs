namespace Metaldle.Core.Domain.ValueObjects;

public class Hint
{
    public string Label { get; set; }
    public string Value { get; set; }
    
    public Hint(string label, string value)
    {
        Label = label;
        Value = value;
    }
}