namespace Metaldle.Core.Domain.ValueObjects;

public class FeedbackResult
{
    public string GuessedEntityName { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    
    public NumericAttributeFeedback Numeric1 { get; set; } = new();
    public NumericAttributeFeedback Numeric2 { get; set; } = new();
    public StringAttributeFeedback Region { get; set; } = new();
    public StringAttributeFeedback Continent { get; set; } = new();
    public StringAttributeFeedback Status { get; set; } = new();
    
    public StringAttributeFeedback Genre { get; set; } = new();
    public ListAttributeFeedback List1 { get; set; } = new();
    public ListAttributeFeedback List2 { get; set; } = new();
    public ListAttributeFeedback List3 { get; set; } = new();
}

public class NumericAttributeFeedback
{
    public int Value { get; set; }                 
    public NumericDirection Direction { get; set; } 
}

public class StringAttributeFeedback
{
    public string Value { get; set; } = string.Empty;  
    public MatchString Match { get; set; }               
}

public class ListAttributeFeedback
{
    public List<string> Values { get; set; } = new();      
    public MatchString Match { get; set; }                   
    public List<string> MatchedItems { get; set; } = new(); 
}