using System.Text.Json.Serialization;
using Metaldle.Core.Domain.Services;
using Metaldle.Infrastructure;
using Metaldle.Infrastructure.Metalbands;
using Metaldle.Infrastructure.MetalBands.Seeding;
using Metaldle.Infrastructure.Redis;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postgresConnection = builder.Configuration.GetConnectionString("PostgreSQL")!;
var redisConnection = builder.Configuration.GetConnectionString("Redis")!;

builder.Services.AddMetalBandsInfrastructure(postgresConnection);
builder.Services.AddRedisInfrastructure(redisConnection);
builder.Services.AddScoped<FeedbackService>();
builder.Services.AddScoped<GameSessionService>();
builder.Services.AddScoped<GuessService>();
builder.Services.AddScoped<GameEngine>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

if (args.Contains("--seed"))
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    var jsonPath = Path.Combine(AppContext.BaseDirectory, "Seeding", "bands.json");
    await seeder.SeedAsync(jsonPath);
    return;
}

app.Run();