using Metaldle.Core.Ports;
using Metaldle.infrastructure.Metalbands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Metaldle.Infrastructure.Metalbands;

// Plugs the MetalBands adapter into the DI container

public static class MetalBandsServiceExtensions
{
    public static IServiceCollection AddMetalBandsInfrastructure(
        this IServiceCollection services, 
        string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
            
        //services.AddScoped<IEntityRepository, MetalBandRepository>();
        
        return services;
    }
}