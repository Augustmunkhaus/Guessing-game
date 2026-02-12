namespace Metaldle.Core.Domain.ValueObjects;

public class FeedbackResult
{
    // The guessed entity info
    public string GuessedEntityName { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    
    // Attribute feedback (showing guessed values + match status)
    public NumericAttributeFeedback Numeric1 { get; set; } = new();
    public NumericAttributeFeedback Numeric2 { get; set; } = new();
    public StringAttributeFeedback Region { get; set; } = new();
    
    public StringAttributeFeedback Continent { get; set; } = new();
    public StringAttributeFeedback Status { get; set; } = new();
    public ListAttributeFeedback List1 { get; set; } = new();
    public ListAttributeFeedback List2 { get; set; } = new();
    public ListAttributeFeedback List3 { get; set; } = new();
}

// For numeric attributes (debut year, member count, etc.)
public class NumericAttributeFeedback
{
    public int Value { get; set; }                  // The guessed value
    public NumericDirection Direction { get; set; } // Exact, Higher, Lower
}

// For string attributes (country, region, status, etc.)
public class StringAttributeFeedback
{
    public string Value { get; set; } = string.Empty;  // The guessed value
    public MatchString Match { get; set; }               // Exact, None
}

// For list attributes (genres, vocal styles, themes, etc.)
public class ListAttributeFeedback
{
    public List<string> Values { get; set; } = new();      // The guessed values
    public MatchString Match { get; set; }                    // Exact, Partial, None
    public List<string> MatchedItems { get; set; } = new(); // Which items matched with target
}