# Guessing game

A Wordle-style daily guessing game for different categories, currently making it for metal bands. 

## Status

This project is currently in development.

## What It Does

Guess the mystery metal band in X number of tries. Each guess gives you feedback on:
- Formation Year (Higher/Lower/Correct)
- Country (Match/No Match)  
- Genre (Match/Close/No Match)
- Active Status (Match/No Match)

Like Wordle, everyone gets the same band each day.

## Tech Stack

- Backend: .NET 8, ASP.NET Core Web API
- Frontend: Blazor WebAssembly
- Database: PostgreSQL (bands data)
- Cache: Redis (game sessions)
- Architecture: Hexagonal
