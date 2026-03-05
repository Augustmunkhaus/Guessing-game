namespace Metaldle.API.DTO_s;

public class TargetBandResponse
{
    public string Name { get; set; } = "";
    public int Year { get; set; }
    public int Members { get; set; }
    public string Country { get; set; } = "";
    public string Continent { get; set; } = "";
    public string Status { get; set; } = "";
    public List<string> Themes { get; set; } = new();
    public List<string> Vocals { get; set; } = new();
    public List<string> Genres { get; set; } = new();
}