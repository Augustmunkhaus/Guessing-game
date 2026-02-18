namespace Metaldle.Infrastructure.MetalBands.Seeding;

public class MetalBandSeedDto
{
    public string Name { get; set; } = string.Empty;
    public int NumericAttribute1 { get; set; }
    public int NumericAttribute2 { get; set; }
    public string RegionAttribute { get; set; } = string.Empty;
    public string ContinentAttribute { get; set; } = string.Empty;
    public string StatusAttribute { get; set; } = string.Empty;
    public List<string> ListAttribute1 { get; set; } = new();
    public List<string> ListAttribute2 { get; set; } = new();
    public List<string> ListAttribute3 { get; set; } = new();
}