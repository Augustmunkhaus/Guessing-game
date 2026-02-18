using System.Text.Json;
using Metaldle.infrastructure.Metalbands;
using Metaldle.Infrastructure.Metalbands;
using Microsoft.EntityFrameworkCore;

//Data seeding operator to insert the bands.json data into PostgreSQL

namespace Metaldle.Infrastructure.MetalBands.Seeding;

public class DatabaseSeeder
{
    private readonly AppDbContext _context;

    public DatabaseSeeder(AppDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync(string jsonFilePath)
    {
        if (await _context.MetalBands.AnyAsync())
        {
            Console.WriteLine("Database already contains data, skipping seed.");
            return;
        }

        var json = await File.ReadAllTextAsync(jsonFilePath);
        var bandDtos = JsonSerializer.Deserialize<List<MetalBandSeedDto>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (bandDtos == null || bandDtos.Count == 0)
        {
            Console.WriteLine("No bands found in JSON file.");
            return;
        }

        var bands = bandDtos.Select(dto => new Metalband
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            NumericAttribute1 = dto.NumericAttribute1,
            NumericAttribute2 = dto.NumericAttribute2,
            RegionAttribute = dto.RegionAttribute,
            ContinentAttribute = dto.ContinentAttribute,
            StatusAttribute = dto.StatusAttribute,
            ListAttribute1 = dto.ListAttribute1,
            ListAttribute2 = dto.ListAttribute2,
            ListAttribute3 = dto.ListAttribute3
        }).ToList();

        await _context.MetalBands.AddRangeAsync(bands);
        await _context.SaveChangesAsync();

        Console.WriteLine($"Successfully seeded {bands.Count} bands.");
    }
}