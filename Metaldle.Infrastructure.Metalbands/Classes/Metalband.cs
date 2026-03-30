namespace Metaldle.Infrastructure.Metalbands;

using Metaldle.Core.Domain.Entities;

//Concrete class of IGuessableEntity

public class Metalband : IGuessableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Numeric attributes
    public int NumericAttribute1 { get; set; }  
    public int NumericAttribute2 { get; set; } 
    
    // Category attributes
    public string RegionAttribute { get; set; } = string.Empty;   
    
    public string ContinentAttribute { get; set; } = string.Empty;
    public string StatusAttribute { get; set; } = string.Empty;
    public string GenreAttribute { get; set; } = string.Empty;

    // List attributes
    public List<string> ListAttribute1 { get; set; } = new();
    public List<string> ListAttribute2 { get; set; } = new();
    public List<string> ListAttribute3 { get; set; } = new();

    // Image
    public string? ImageUrl { get; set; }
}