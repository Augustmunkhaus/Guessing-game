using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;

namespace Metaldle.Core.Domain.Services;

//feedbackService compares a guess with the target entity, and generates feedback with the 3 helper methods,
//using the ValueObjects Enums

public class FeedbackService {
    
    public FeedbackResult GenerateFeedback (IGuessableEntity guess,IGuessableEntity target)
    {
        var feedback = new FeedbackResult
        {
            GuessedEntityName = guess.Name,
            IsCorrect = guess.Id == target.Id,

            Numeric1 = CompareNumericAttribute(guess.NumericAttribute1, target.NumericAttribute1, threshold: 5),
            Numeric2 = CompareNumericAttribute(guess.NumericAttribute2, target.NumericAttribute2, threshold: 1),
            
            Region = CompareStringAttribute(guess.RegionAttribute, target.RegionAttribute),
            Continent = CompareStringAttribute(guess.ContinentAttribute, target.ContinentAttribute),
            Status = CompareStringAttribute(guess.StatusAttribute, target.StatusAttribute),

            List1 = CompareListAttribute(guess.ListAttribute1, target.ListAttribute1),
            List2 = CompareListAttribute(guess.ListAttribute2, target.ListAttribute2),
            List3 = CompareListAttribute(guess.ListAttribute3, target.ListAttribute3)
        };
        return feedback;

    }

    private NumericAttributeFeedback CompareNumericAttribute(int guess, int target, int threshold)
    {
        NumericDirection direction;
        
        var difference = Math.Abs(target - guess);
        
        bool isClose = difference <= threshold;
        
        if (target == guess)
        {
            direction = NumericDirection.Exact;
        }

        else if (target > guess)
        {
            direction = isClose?  NumericDirection.HigherClose : NumericDirection.Higher;
        }
        else
        {
            direction = isClose? NumericDirection.LowerClose : NumericDirection.Lower;
        }

        return new NumericAttributeFeedback
        {
           Value = guess, Direction = direction
        };
    }

    private StringAttributeFeedback CompareStringAttribute(string guess, string target)
    {
        MatchString matchString;

        if (target == guess)
        {
            matchString = MatchString.Exact;
        }

        else
        {
            matchString = MatchString.None;
        }


        return new StringAttributeFeedback
        {
            Value = guess, Match = matchString
        };
    }
    
    private ListAttributeFeedback CompareListAttribute(List<string> guess, List<string> target)
    {
        var matchedItems = guess
            .Where(g => target.Any(t => string.Equals(g, t, StringComparison.OrdinalIgnoreCase)))
            .ToList();
        
        Console.WriteLine($"DEBUG - Guess: [{string.Join(", ", guess)}]");
        Console.WriteLine($"DEBUG - Target: [{string.Join(", ", target)}]");
        Console.WriteLine($"DEBUG - Matched: [{string.Join(", ", matchedItems)}] (Count: {matchedItems.Count})");
        
        MatchString matchString;

        if (matchedItems.Count == target.Count && matchedItems.Count == guess.Count)
        {
            matchString = MatchString.Exact;
        }

        else if (matchedItems.Count == 0)
        {
            matchString = MatchString.None;
        }

        else
        {
            matchString = MatchString.Partial;
        }


        return new ListAttributeFeedback
        {
            Values = guess,
            Match = matchString,
            MatchedItems =  matchedItems
        };
    }
    
}