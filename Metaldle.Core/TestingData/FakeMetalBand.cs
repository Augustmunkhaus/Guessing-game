namespace Metaldle.Core.Testing;

using Metaldle.Core.Domain.Entities;

//Concrete class of IGuessableEntity for testdata

public class FakeMetalBand : IGuessableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Numeric attributes
    public int NumericAttribute1 { get; set; }  // Formation Year
    public int NumericAttribute2 { get; set; }  // Member Count
    
    // Category attributes
    public string CategoryAttribute { get; set; } = string.Empty;  // Subgenre
    public string RegionAttribute { get; set; } = string.Empty;    // Country
    public string StatusAttribute { get; set; } = string.Empty;    // Active/Disbanded
    
    // List attributes
    public List<string> ListAttribute1 { get; set; } = new();  // Themes
    public List<string> ListAttribute2 { get; set; } = new();  // Vocal Styles
    public List<string> ListAttribute3 { get; set; } = new();  // Notable Albums
}