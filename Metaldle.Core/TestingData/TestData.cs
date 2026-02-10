namespace Metaldle.Core.Testing;

//Testing data for core logic

public static class TestData
{
    public static List<FakeMetalBand> GetTestBands()
    {
        return new List<FakeMetalBand>
        {
            new FakeMetalBand
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Metallica",
                NumericAttribute1 = 1981,  // Formation year
                NumericAttribute2 = 4,     // Members
                CategoryAttribute = "Thrash Metal",
                RegionAttribute = "USA",
                StatusAttribute = "Active",
                ListAttribute1 = new List<string> { "War", "Death", "Rebellion" },
                ListAttribute2 = new List<string> { "Clean", "Aggressive" },
                ListAttribute3 = new List<string> { "Master of Puppets", "Ride the Lightning", "Black Album" }
            },
            new FakeMetalBand
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Iron Maiden",
                NumericAttribute1 = 1975,
                NumericAttribute2 = 6,
                CategoryAttribute = "Heavy Metal",
                RegionAttribute = "UK",
                StatusAttribute = "Active",
                ListAttribute1 = new List<string> { "History", "War", "Literature" },
                ListAttribute2 = new List<string> { "Operatic", "High-pitched" },
                ListAttribute3 = new List<string> { "The Number of the Beast", "Powerslave", "Seventh Son" }
            },
            new FakeMetalBand
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Slayer",
                NumericAttribute1 = 1981,
                NumericAttribute2 = 4,
                CategoryAttribute = "Thrash Metal",
                RegionAttribute = "USA",
                StatusAttribute = "Disbanded",
                ListAttribute1 = new List<string> { "War", "Death", "Religion" },
                ListAttribute2 = new List<string> { "Aggressive", "Screaming" },
                ListAttribute3 = new List<string> { "Reign in Blood", "South of Heaven", "Seasons in the Abyss" }
            },
            new FakeMetalBand
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "Black Sabbath",
                NumericAttribute1 = 1968,
                NumericAttribute2 = 4,
                CategoryAttribute = "Doom Metal",
                RegionAttribute = "UK",
                StatusAttribute = "Disbanded",
                ListAttribute1 = new List<string> { "Occult", "War", "Drugs" },
                ListAttribute2 = new List<string> { "Dark", "Heavy" },
                ListAttribute3 = new List<string> { "Paranoid", "Master of Reality", "Black Sabbath" }
            },
            new FakeMetalBand
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Name = "Judas Priest",
                NumericAttribute1 = 1969,
                NumericAttribute2 = 5,
                CategoryAttribute = "Heavy Metal",
                RegionAttribute = "UK",
                StatusAttribute = "Active",
                ListAttribute1 = new List<string> { "Rebellion", "Freedom", "Power" },
                ListAttribute2 = new List<string> { "High-pitched", "Operatic" },
                ListAttribute3 = new List<string> { "British Steel", "Screaming for Vengeance", "Painkiller" }
            }
        };
    }
}