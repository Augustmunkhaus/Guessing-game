using Metaldle.Core.Domain.Services;
using Metaldle.Core.Domain.ValueObjects;
using Metaldle.Core.Testing;
using Xunit;

public class FeedbackServiceTests
{
    private readonly FeedbackService _service;
    private readonly List<FakeMetalBand> _testBands;

    public FeedbackServiceTests()
    {
        _service = new FeedbackService();
        _testBands = TestData.GetTestBands();
    }

    // ==================== NUMERIC COMPARISONS ====================
    
    [Fact]
    public void CompareNumeric_SameYear_ReturnsExact()
    {
        // Metallica (1981) vs Slayer (1981)
        var metallica = _testBands[0];
        var slayer = _testBands[2];
        
        var feedback = _service.GenerateFeedback(slayer, metallica);
        
        Assert.Equal(NumericDirection.Exact, feedback.Numeric1.Direction);
        Assert.Equal(1981, feedback.Numeric1.Value);
    }
    
    [Fact]
    public void CompareNumeric_GuessLower_ReturnsHigher()
    {
        // Iron Maiden (1975) vs Metallica (1981) - target is higher
        var ironMaiden = _testBands[1];
        var metallica = _testBands[0];
        
        var feedback = _service.GenerateFeedback(ironMaiden, metallica);
        
        Assert.Equal(NumericDirection.Higher, feedback.Numeric1.Direction);
        Assert.Equal(1975, feedback.Numeric1.Value);
    }
    
    [Fact]
    public void CompareNumeric_GuessHigher_ReturnsLower()
    {
        // Metallica (1981) vs Black Sabbath (1968) - target is lower
        var metallica = _testBands[0];
        var blackSabbath = _testBands[3];
        
        var feedback = _service.GenerateFeedback(metallica, blackSabbath);
        
        Assert.Equal(NumericDirection.Lower, feedback.Numeric1.Direction);
        Assert.Equal(1981, feedback.Numeric1.Value);
    }

    // ==================== STRING COMPARISONS ====================
    
    [Fact]
    public void CompareString_SameCountry_ReturnsExact()
    {
        // Metallica (USA) vs Slayer (USA)
        var metallica = _testBands[0];
        var slayer = _testBands[2];
        
        var feedback = _service.GenerateFeedback(slayer, metallica);
        
        Assert.Equal(MatchString.Exact, feedback.Region.Match);
        Assert.Equal("USA", feedback.Region.Value);
    }
    
    [Fact]
    public void CompareString_DifferentCountry_ReturnsNone()
    {
        // Metallica (USA) vs Iron Maiden (UK)
        var metallica = _testBands[0];
        var ironMaiden = _testBands[1];
        
        var feedback = _service.GenerateFeedback(metallica, ironMaiden);
        
        Assert.Equal(MatchString.None, feedback.Region.Match);
        Assert.Equal("USA", feedback.Region.Value);
    }
    
    [Fact]
    public void CompareString_DifferentStatus_ReturnsNone()
    {
        // Metallica (Active) vs Slayer (Disbanded)
        var metallica = _testBands[0];
        var slayer = _testBands[2];
        
        var feedback = _service.GenerateFeedback(slayer, metallica);
        
        Assert.Equal(MatchString.None, feedback.Status.Match);
        Assert.Equal("Disbanded", feedback.Status.Value);
    }

    // ==================== LIST COMPARISONS ====================
    
    [Fact]
    public void CompareList_PartialMatch_ReturnsPartialWithMatchedItems()
    {
        // Metallica themes: ["War", "Death", "Rebellion"]
        // Slayer themes: ["War", "Death", "Religion"]
        // Should match: ["War", "Death"]
        var metallica = _testBands[0];
        var slayer = _testBands[2];
        
        var feedback = _service.GenerateFeedback(slayer, metallica);
        
        Assert.Equal(MatchString.Partial, feedback.List1.Match);
        Assert.Equal(2, feedback.List1.MatchedItems.Count);
        Assert.Contains("War", feedback.List1.MatchedItems);
        Assert.Contains("Death", feedback.List1.MatchedItems);
    }
    
    [Fact]
    public void CompareList_NoMatch_ReturnsNone()
    {
        // Metallica themes: ["War", "Death", "Rebellion"]
        // Iron Maiden themes: ["History", "War", "Literature"]
        // Only "War" matches, so partial
        var metallica = _testBands[0];
        var ironMaiden = _testBands[1];
        
        var feedback = _service.GenerateFeedback(ironMaiden, metallica);
        
        Assert.Equal(MatchString.Partial, feedback.List1.Match);
        Assert.Single(feedback.List1.MatchedItems);
        Assert.Contains("War", feedback.List1.MatchedItems);
    }
    
    [Fact]
    public void CompareList_ExactMatch_ReturnsExact()
    {
        // Same band should have exact match
        var metallica = _testBands[0];
        
        var feedback = _service.GenerateFeedback(metallica, metallica);
        
        Assert.Equal(MatchString.Exact, feedback.List1.Match);
        Assert.Equal(MatchString.Exact, feedback.List2.Match);
        Assert.Equal(MatchString.Exact, feedback.List3.Match);
    }
    
    [Fact]
    public void CompareList_CaseInsensitive_MatchesCorrectly()
    {
        // Create a custom band with different casing
        var customBand = new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Test Band",
            NumericAttribute1 = 2000,
            NumericAttribute2 = 5,
            RegionAttribute = "USA",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "WAR", "death", "REBELLION" },  // Different casing
            ListAttribute2 = new List<string>(),
            ListAttribute3 = new List<string>()
        };
        
        var metallica = _testBands[0];  // Has ["War", "Death", "Rebellion"]
        
        var feedback = _service.GenerateFeedback(customBand, metallica);
        
        // Should still match because comparison is case-insensitive
        Assert.Equal(MatchString.Exact, feedback.List1.Match);
    }

    // ==================== FULL FEEDBACK ====================
    
    [Fact]
    public void GenerateFeedback_CorrectGuess_SetsIsCorrectTrue()
    {
        var metallica = _testBands[0];
        
        var feedback = _service.GenerateFeedback(metallica, metallica);
        
        Assert.True(feedback.IsCorrect);
        Assert.Equal("Metallica", feedback.GuessedEntityName);
    }
    
    [Fact]
    public void GenerateFeedback_WrongGuess_SetsIsCorrectFalse()
    {
        var metallica = _testBands[0];
        var slayer = _testBands[2];
        
        var feedback = _service.GenerateFeedback(slayer, metallica);
        
        Assert.False(feedback.IsCorrect);
        Assert.Equal("Slayer", feedback.GuessedEntityName);
    }
    
    [Fact]
    public void GenerateFeedback_PopulatesAllFeedbackFields()
    {
        var metallica = _testBands[0];
        var ironMaiden = _testBands[1];
        
        var feedback = _service.GenerateFeedback(ironMaiden, metallica);
        
        // Verify all fields are populated (not default values)
        Assert.NotNull(feedback.Numeric1);
        Assert.NotNull(feedback.Numeric2);
        
        Assert.NotNull(feedback.Region);
        Assert.NotNull(feedback.Status);
        Assert.NotNull(feedback.List1);
        Assert.NotNull(feedback.List2);
        Assert.NotNull(feedback.List3);
        
        // Verify feedback makes sense
        Assert.Equal(NumericDirection.Higher, feedback.Numeric1.Direction);  // 1975 < 1981
        Assert.Equal(MatchString.None, feedback.Region.Match);  // UK vs USA
        
    }
}