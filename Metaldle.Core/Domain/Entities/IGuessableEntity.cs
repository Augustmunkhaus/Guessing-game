namespace Metaldle.Core.Domain.Entities;

public interface IGuessableEntity
{
    Guid Id { get; }
    string Name { get; }
    
    // Numeric attributes
    int NumericAttribute1 { get; }
    int NumericAttribute2 { get; }
    
    // Category attributes
    string RegionAttribute { get; }
    string ContinentAttribute { get; }
    string StatusAttribute { get; }
    string GenreAttribute { get; }
    
    // List attributes
    List<string> ListAttribute1 { get; }
    List<string> ListAttribute2 { get; }
    List<string> ListAttribute3 { get; }

    // Image
    string? ImageUrl { get; }
}