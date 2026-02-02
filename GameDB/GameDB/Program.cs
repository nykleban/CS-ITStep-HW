
using GameDB;
using GameDB.Entities;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();

    
        db.Database.EnsureCreated();

        if (!db.Games.Any())
        {
            db.Games.AddRange(
                new GameEntity
                {
                    Title = "The Witcher 3: Wild Hunt",
                    Studio = "CD Projekt",
                    Genre = "RPG",
                    ReleaseDate = new DateTime(2015, 5, 19)
                },
                new GameEntity
                {
                    Title = "Minecraft",
                    Studio = "Mojang Studios",
                    Genre = "Sandbox",
                    ReleaseDate = new DateTime(2011, 11, 18)
                },
                new GameEntity
                {
                    Title = "Cyberpunk 2077",
                    Studio = "CD Projekt",
                    Genre = "Action RPG",
                    ReleaseDate = new DateTime(2020, 12, 10)
                }
            );

            db.SaveChanges();
        }

        var games = db.Games
            .OrderBy(g => g.ReleaseDate)
            .ToList();

        Console.WriteLine("=== Games from DB ===");
        foreach (var g in games)
        {
            Console.WriteLine($"{g.Id}. {g.Title} | {g.Studio} | {g.Genre} | {g.ReleaseDate:yyyy-MM-dd}");
        }
    }
}
