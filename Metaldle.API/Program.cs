using Metaldle.Infrastructure.Metalbands;
using Metaldle.Infrastructure.MetalBands.Seeding;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQL")!;
builder.Services.AddMetalBandsInfrastructure(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map Controllers
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