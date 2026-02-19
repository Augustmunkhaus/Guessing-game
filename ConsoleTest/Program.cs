using Metaldle.Core.Domain.Entities;
using Metaldle.Core.Domain.Services;
using Metaldle.Core.Domain.ValueObjects;
using Metaldle.Core.Ports;
using Metaldle.Core.Testing;
using Metaldle.Infrastructure;
using Metaldle.infrastructure.Metalbands;
using Metaldle.Infrastructure.Metalbands.Repositories;
using Metaldle.Infrastructure.Redis;
using Metaldle.Infrastructure.Redis.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

//Current testing grounds for new features that gets added, gets replaced by proper frontend later

Console.WriteLine(" Welcome to Metaldle - Console Edition ");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var services = new ServiceCollection();

var postgresConnection = configuration.GetConnectionString("PostgreSQL")!;
var redisConnection = configuration.GetConnectionString("Redis")!;

services.AddMetalBandsInfrastructure(postgresConnection);
services.AddRedisInfrastructure(redisConnection);
services.AddScoped<GameSessionService>();
services.AddScoped<GuessService>();
services.AddScoped<FeedbackService>();
services.AddScoped<GameEngine>();

var serviceProvider = services.BuildServiceProvider();

var entityRepo = serviceProvider.GetRequiredService<IEntityRepository>();
var sessionRepo = serviceProvider.GetRequiredService<ISessionRepository>();
var gameEngine = serviceProvider.GetRequiredService<GameEngine>();

// Generate a session ID (simulating a user)
//string sessionId = "console-player-" + Guid.NewGuid().ToString()[..8];
string sessionId = "console-player-aa3e5f69";
Console.WriteLine($"Your session ID: {sessionId}\n");

// Start or resume the game
var session = await gameEngine.StartOrResumeGameAsync(sessionId);

Console.WriteLine($"📅 Today's mystery band: ???");
Console.WriteLine($"🎯 You have 6 guesses. Good luck!\n");

//keeps game running until won/lost
while (session.Status == GameStatus.InProgress && session.Guesses.Count < 6)
{
    Console.Write($"\n[Guess {session.Guesses.Count + 1}/6] Enter band name: ");
    string? guess = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(guess))
    {
        Console.WriteLine("❌ Please enter a band name!");
        continue;
    }
    
    try
    {
        // Process the guess
        var (updatedSession, feedback) = await gameEngine.SubmitGuessAsync(sessionId, guess);
        session = updatedSession;
        
        // Display feedback
        DisplayFeedback(feedback);
        
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}

Console.WriteLine("\n" + new string('=', 50));

if (session.Status == GameStatus.Won)
{
    Console.WriteLine("YOU WON! 🎉");
    Console.WriteLine($"You guessed it in {session.Guesses.Count} tries!");
}
else
{
    Console.WriteLine("GAME OVER!");
    var correctAnswer = await entityRepo.GetByIdAsync(session.TargetEntityId);
    
    Console.WriteLine($"The answer was: {correctAnswer.Name}"); 
}

void DisplayFeedback(FeedbackResult feedback)
{
    Console.WriteLine($"\n  🎸 Band: {feedback.GuessedEntityName}");
    
    if (feedback.IsCorrect)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ✅ CORRECT! YOU WIN!");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("  ❌ Not quite...\n");
    }
    
    Console.Write("  📅 Formation Year: ");
    Console.ForegroundColor = GetColorForDirection(feedback.Numeric1.Direction);
    Console.Write($"{feedback.Numeric1.Value} ");
    Console.Write(GetArrowForDirection(feedback.Numeric1.Direction));
    Console.ResetColor();
    Console.WriteLine();
   
    Console.Write("  👥 Members: ");
    Console.ForegroundColor = GetColorForDirection(feedback.Numeric2.Direction);
    Console.Write($"{feedback.Numeric2.Value} ");
    Console.Write(GetArrowForDirection(feedback.Numeric2.Direction));
    Console.ResetColor();
    Console.WriteLine();
    
    Console.Write("Country: ");
    DisplayStringAttribute(feedback.Region.Value, feedback.Region.Match);
    
    Console.Write("Continent: ");
    DisplayStringAttribute(feedback.Continent.Value, feedback.Continent.Match);
    
    Console.Write("Status: ");
    DisplayStringAttribute(feedback.Status.Value, feedback.Status.Match);
    
    Console.WriteLine();
    
    Console.Write("Themes: ");
    DisplayListAttribute(feedback.List1);
    
    Console.Write("Vocal Style: ");
    DisplayListAttribute(feedback.List2);
    
    Console.Write("genres: "); 
    DisplayListAttribute(feedback.List3);
}

void DisplayStringAttribute(string value, MatchString match)
{
    Console.ForegroundColor = match == MatchString.Exact ? ConsoleColor.Green : ConsoleColor.Red;
    Console.Write(value);
    Console.ResetColor();
    Console.Write($" ({match})");
    Console.WriteLine();
}

void DisplayListAttribute(ListAttributeFeedback listFeedback)
{
    Console.ForegroundColor = listFeedback.Match == MatchString.Exact ? ConsoleColor.Green :
                              listFeedback.Match == MatchString.Partial ? ConsoleColor.Yellow :
                              ConsoleColor.Red;
    
    Console.Write($"[{string.Join(", ", listFeedback.Values)}]");
    Console.ResetColor();
    
    Console.Write($" ({listFeedback.Match})");
    
    if (listFeedback.Match == MatchString.Partial && listFeedback.MatchedItems.Count > 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($" ✓ Matched: [{string.Join(", ", listFeedback.MatchedItems)}]");
        Console.ResetColor();
    }
    
    Console.WriteLine();
}

ConsoleColor GetColorForDirection(NumericDirection direction)
{
    return direction == NumericDirection.Exact ? ConsoleColor.Green : 
           direction == NumericDirection.Higher ? ConsoleColor.Yellow : 
           ConsoleColor.Cyan;
}

string GetArrowForDirection(NumericDirection direction)
{
    return direction switch
    {
        NumericDirection.Exact => "✅",
        NumericDirection.Higher => "⬆️ ",
        NumericDirection.Lower => "⬇️ ",
        _ => ""
    };
}