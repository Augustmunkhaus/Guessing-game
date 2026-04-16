using Metaldle.Core.Domain.Entities;
using Metaldle.Infrastructure.Metalbands;
using Microsoft.EntityFrameworkCore;

namespace Metaldle.infrastructure.Metalbands;
//tells EF what classes exists, together with the configuration file, EF can translate 
//C# Linq language into working SQL
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Metalband> MetalBands => Set<Metalband>();

    public DbSet<LeaderboardEntry> LeaderboardEntries => Set<LeaderboardEntry>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}