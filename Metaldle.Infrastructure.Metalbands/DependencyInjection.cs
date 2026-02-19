using Metaldle.Core.Ports;
using Metaldle.infrastructure.Metalbands;
using Metaldle.Infrastructure.Metalbands.Repositories;
using Metaldle.Infrastructure.MetalBands.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Metaldle.Infrastructure;

// Plugs the MetalBands adapter into the DI container

public static class MetalBandsServiceExtensions
{
    public static IServiceCollection AddMetalBandsInfrastructure(
        this IServiceCollection services, 
        string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
            
        services.AddScoped<IEntityRepository, MetalBandRepository>();
        services.AddScoped<DatabaseSeeder>();
        return services;
    }
}