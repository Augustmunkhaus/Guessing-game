namespace Metaldle.BlazorWASM.Models;

public class TargetBandResponse
{
    public string Name { get; set; } = "";
    public int Year { get; set; }
    public int Members { get; set; }
    public string Country { get; set; } = "";
    public string Continent { get; set; } = "";
    public string Status { get; set; } = "";
    public string Genre { get; set; } = "";
    public List<string> Themes { get; set; } = new();
    public List<string> Vocals { get; set; } = new();
    public List<string> SubGenres { get; set; } = new();
    public string? ImageUrl { get; set; }
}