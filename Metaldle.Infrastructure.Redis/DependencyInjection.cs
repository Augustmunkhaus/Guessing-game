using Metaldle.Core.Ports;
using Metaldle.Infrastructure.Redis.Repositories;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Metaldle.Infrastructure.Redis;

// Plugs the Redis adapter into the DI container

public static class RedisServiceExtensions
{
    public static IServiceCollection AddRedisInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(connectionString));
        
        services.AddScoped<ISessionRepository, RedisSessionRepository>();
        
        return services;
    }
}