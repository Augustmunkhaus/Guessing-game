using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.ValueObjects;

namespace Metaldle.Core.Domain.Services;

public class FeedbackService {
    
    public FeedbackResult GenerateFeedback (IGuessableEntity guess,IGuessableEntity target)
    {
        var feedback = new FeedbackResult
        {
            GuessedEntityName = guess.Name,
            IsCorrect = guess.Id == target.Id,

            Numeric1 = CompareNumericAttribute(guess.NumericAttribute1, target.NumericAttribute1),
            Numeric2 = CompareNumericAttribute(guess.NumericAttribute2, target.NumericAttribute2),

            Category = CompareStringAttribute(guess.CategoryAttribute, target.CategoryAttribute),
            Region = CompareStringAttribute(guess.RegionAttribute, target.RegionAttribute),
            Status = CompareStringAttribute(guess.StatusAttribute, target.StatusAttribute),

            List1 = CompareListAttribute(guess.ListAttribute1, target.ListAttribute1),
            List2 = CompareListAttribute(guess.ListAttribute2, target.ListAttribute2),
            List3 = CompareListAttribute(guess.ListAttribute3, target.ListAttribute3)
        };
        return feedback;

    }

    private NumericAttributeFeedback CompareNumericAttribute(int guess, int target)
    {
        NumericDirection direction;
        
        if (target == guess)
        {
            direction = NumericDirection.Exact;
        }

        else if (target > guess)
        {
            direction = NumericDirection.Higher;
        }
        else
        {
            direction = NumericDirection.Lower;
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
        
        MatchString matchString;

        if (matchedItems.Count == target.Count && matchedItems.Count == guess.Count)
        {
            matchString = MatchString.Exact;
        }

        else if  (target.Count == 0)
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