using System.Text.Json.Serialization;
using Metaldle.Core.Domain.Services;
using Metaldle.Infrastructure;
using Metaldle.infrastructure.Metalbands;
using Metaldle.Infrastructure.Metalbands;
using Metaldle.Infrastructure.MetalBands.Seeding;
using Metaldle.Infrastructure.Redis;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddScoped<DatabaseSeeder>();
builder.Services.AddScoped<LeaderboardService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
        policy.WithOrigins(
                "http://localhost:5027",
                "http://localhost:80",
                "http://localhost")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("BlazorClient");

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
    
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    var jsonPath = Path.Combine(AppContext.BaseDirectory, "Seeding", "bands.json");
    await seeder.SeedAsync(jsonPath);
}

app.Run();