namespace Metaldle.Core.Testing;

//Testing data for core logic

public static class TestData
{
    public static List<FakeMetalBand> GetTestBands()
{
    return new List<FakeMetalBand>
    {
        // Original 5
        new FakeMetalBand
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Metallica",
            NumericAttribute1 = 1981,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "War", "Death", "Rebellion" },
            ListAttribute2 = new List<string> { "Clean", "Aggressive" },
            ListAttribute3 = new List<string> { "Thrash Metal", "Heavy Metal", "Speed Metal", "NWOBHM" }
        },
        new FakeMetalBand
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Iron Maiden",
            NumericAttribute1 = 1975,
            NumericAttribute2 = 6,
            RegionAttribute = "UK",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "History", "War", "Literature" },
            ListAttribute2 = new List<string> { "Operatic", "High-pitched" },
            ListAttribute3 = new List<string> { "Heavy Metal", "NWOBHM", "Progressive Rock" }
        },
        new FakeMetalBand
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Slayer",
            NumericAttribute1 = 1981,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Disbanded",
            ListAttribute1 = new List<string> { "War", "Death", "Religion" },
            ListAttribute2 = new List<string> { "Aggressive", "Screaming" },
            ListAttribute3 = new List<string> { "Thrash Metal", "Speed Metal", "Death Metal", "Punk" }
        },
        new FakeMetalBand
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Name = "Black Sabbath",
            NumericAttribute1 = 1968,
            NumericAttribute2 = 4,
            RegionAttribute = "UK",
            ContinentAttribute = "Europe",
            StatusAttribute = "Disbanded",
            ListAttribute1 = new List<string> { "Occult", "War", "Drugs" },
            ListAttribute2 = new List<string> { "Dark", "Heavy" },
            ListAttribute3 = new List<string> { "Doom Metal", "Heavy Metal", "Blues Rock", "Psychedelic Rock" }
        },
        new FakeMetalBand
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Name = "Judas Priest",
            NumericAttribute1 = 1969,
            NumericAttribute2 = 5,
            RegionAttribute = "UK",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Rebellion", "Freedom", "Power" },
            ListAttribute2 = new List<string> { "High-pitched", "Operatic" },
            ListAttribute3 = new List<string> { "Heavy Metal", "NWOBHM", "Speed Metal", "Blues Rock" }
        },

        // NEW BANDS - 20 more!
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Megadeth",
            NumericAttribute1 = 1983,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "War", "Politics", "Dystopia" },
            ListAttribute2 = new List<string> { "Aggressive", "Technical" },
            ListAttribute3 = new List<string> { "Thrash Metal", "Speed Metal", "Heavy Metal", "NWOBHM" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Pantera",
            NumericAttribute1 = 1981,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Disbanded",
            ListAttribute1 = new List<string> { "Anger", "Power", "Rebellion" },
            ListAttribute2 = new List<string> { "Aggressive", "Powerful" },
            ListAttribute3 = new List<string> { "Groove Metal", "Thrash Metal", "Southern Rock", "Hardcore" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Opeth",
            NumericAttribute1 = 1990,
            NumericAttribute2 = 5,
            RegionAttribute = "Sweden",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Death", "Nature", "Melancholy" },
            ListAttribute2 = new List<string> { "Clean", "Growling", "Melodic" },
            ListAttribute3 = new List<string> { "Progressive Metal", "Death Metal", "Progressive Rock", "Folk" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Motorhead",
            NumericAttribute1 = 1975,
            NumericAttribute2 = 3,
            RegionAttribute = "UK",
            ContinentAttribute = "Europe",
            StatusAttribute = "Disbanded",
            ListAttribute1 = new List<string> { "War", "Rebellion", "Speed" },
            ListAttribute2 = new List<string> { "Raw", "Aggressive" },
            ListAttribute3 = new List<string> { "Heavy Metal", "Speed Metal", "Punk", "Rock and Roll" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Dream Theater",
            NumericAttribute1 = 1985,
            NumericAttribute2 = 5,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Fantasy", "Introspection", "Complexity" },
            ListAttribute2 = new List<string> { "Technical", "Melodic" },
            ListAttribute3 = new List<string> { "Progressive Metal", "Progressive Rock", "Jazz Fusion", "Classical" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Mastodon",
            NumericAttribute1 = 2000,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Nature", "Mythology", "Space" },
            ListAttribute2 = new List<string> { "Harsh", "Clean", "Complex" },
            ListAttribute3 = new List<string> { "Progressive Metal", "Sludge Metal", "Stoner Metal", "Psychedelic" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Sepultura",
            NumericAttribute1 = 1984,
            NumericAttribute2 = 4,
            RegionAttribute = "Brazil",
            ContinentAttribute = "South America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Politics", "War", "Indigenous" },
            ListAttribute2 = new List<string> { "Aggressive", "Tribal" },
            ListAttribute3 = new List<string> { "Thrash Metal", "Death Metal", "Groove Metal", "Hardcore" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Gojira",
            NumericAttribute1 = 1996,
            NumericAttribute2 = 4,
            RegionAttribute = "France",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Environment", "Death", "Spirituality" },
            ListAttribute2 = new List<string> { "Growling", "Technical" },
            ListAttribute3 = new List<string> { "Progressive Metal", "Death Metal", "Groove Metal", "Thrash Metal" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Tool",
            NumericAttribute1 = 1990,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Psychology", "Spirituality", "Philosophy" },
            ListAttribute2 = new List<string> { "Melodic", "Complex" },
            ListAttribute3 = new List<string> { "Progressive Metal", "Alternative Metal", "Art Rock", "Post-Metal" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Anthrax",
            NumericAttribute1 = 1981,
            NumericAttribute2 = 5,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Comics", "War", "Humor" },
            ListAttribute2 = new List<string> { "Aggressive", "Energetic" },
            ListAttribute3 = new List<string> { "Thrash Metal", "Speed Metal", "Heavy Metal", "Hardcore" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Amon Amarth",
            NumericAttribute1 = 1992,
            NumericAttribute2 = 5,
            RegionAttribute = "Sweden",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Vikings", "Mythology", "War" },
            ListAttribute2 = new List<string> { "Growling", "Melodic" },
            ListAttribute3 = new List<string> { "Death Metal", "Melodic Death Metal", "Viking Metal" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Lamb of God",
            NumericAttribute1 = 1994,
            NumericAttribute2 = 5,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Politics", "Violence", "Corruption" },
            ListAttribute2 = new List<string> { "Aggressive", "Harsh" },
            ListAttribute3 = new List<string> { "Groove Metal", "Thrash Metal", "Death Metal", "Hardcore" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Arch Enemy",
            NumericAttribute1 = 1995,
            NumericAttribute2 = 5,
            RegionAttribute = "Sweden",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "War", "Freedom", "Empowerment" },
            ListAttribute2 = new List<string> { "Growling", "Melodic" },
            ListAttribute3 = new List<string> { "Melodic Death Metal", "Death Metal", "Thrash Metal" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "System of a Down",
            NumericAttribute1 = 1994,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Hiatus",
            ListAttribute1 = new List<string> { "Politics", "War", "Social Issues" },
            ListAttribute2 = new List<string> { "Eclectic", "Aggressive", "Melodic" },
            ListAttribute3 = new List<string> { "Alternative Metal", "Nu Metal", "Progressive Metal", "Armenian Folk" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Helloween",
            NumericAttribute1 = 1984,
            NumericAttribute2 = 5,
            RegionAttribute = "Germany",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Fantasy", "Halloween", "Adventure" },
            ListAttribute2 = new List<string> { "High-pitched", "Melodic" },
            ListAttribute3 = new List<string> { "Power Metal", "Speed Metal", "Heavy Metal", "NWOBHM" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Nightwish",
            NumericAttribute1 = 1996,
            NumericAttribute2 = 6,
            RegionAttribute = "Finland",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Fantasy", "Nature", "Mythology" },
            ListAttribute2 = new List<string> { "Operatic", "Symphonic" },
            ListAttribute3 = new List<string> { "Symphonic Metal", "Power Metal", "Gothic Metal", "Folk" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "In Flames",
            NumericAttribute1 = 1990,
            NumericAttribute2 = 5,
            RegionAttribute = "Sweden",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Emotion", "Introspection", "Struggle" },
            ListAttribute2 = new List<string> { "Melodic", "Harsh" },
            ListAttribute3 = new List<string> { "Melodic Death Metal", "Death Metal", "Alternative Metal", "Metalcore" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Emperor",
            NumericAttribute1 = 1991,
            NumericAttribute2 = 4,
            RegionAttribute = "Norway",
            ContinentAttribute = "Europe",
            StatusAttribute = "Disbanded",
            ListAttribute1 = new List<string> { "Darkness", "Occult", "Winter" },
            ListAttribute2 = new List<string> { "Shrieking", "Atmospheric" },
            ListAttribute3 = new List<string> { "Black Metal", "Symphonic Black Metal", "Progressive Metal" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Trivium",
            NumericAttribute1 = 1999,
            NumericAttribute2 = 4,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Mythology", "War", "Philosophy" },
            ListAttribute2 = new List<string> { "Clean", "Screaming", "Technical" },
            ListAttribute3 = new List<string> { "Metalcore", "Thrash Metal", "Melodic Death Metal", "Progressive Metal" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Testament",
            NumericAttribute1 = 1983,
            NumericAttribute2 = 5,
            RegionAttribute = "USA",
            ContinentAttribute = "North America",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Occult", "War", "Apocalypse" },
            ListAttribute2 = new List<string> { "Aggressive", "Technical" },
            ListAttribute3 = new List<string> { "Thrash Metal", "Speed Metal", "Death Metal", "Heavy Metal" }
        },
        new FakeMetalBand
        {
            Id = Guid.NewGuid(),
            Name = "Fakeween",
            NumericAttribute1 = 1984,
            NumericAttribute2 = 5,
            RegionAttribute = "Germany",
            ContinentAttribute = "Europe",
            StatusAttribute = "Active",
            ListAttribute1 = new List<string> { "Fantasy", "Halloween", "Adventure" },
            ListAttribute2 = new List<string> { "High-pitched", "Melodic" },
            ListAttribute3 = new List<string> { "Power Metal", "Speed Metal", "Heavy Metal", "NWOBHM" }
        },
    };
}
}

