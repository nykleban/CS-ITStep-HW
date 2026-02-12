using GameStoreDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreDB
{
    public static class Seed
        {
            public static ModelBuilder SeedGameStore(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Publisher>().HasData(
                    new Publisher { Id = 1, Name = "Valve", Country = "USA", Email = "info@valve.com", Age = 0 },
                    new Publisher { Id = 2, Name = "CD Projekt", Country = "Poland", Email = "contact@cdprojekt.com", Age = 0 },
                    new Publisher { Id = 3, Name = "Ubisoft", Country = "France", Email = "support@ubisoft.com", Age = 0 }
                );

                modelBuilder.Entity<Genre>().HasData(
                    new Genre { Id = 1, Name = "Action" },
                    new Genre { Id = 2, Name = "RPG" },
                    new Genre { Id = 3, Name = "Shooter" },
                    new Genre { Id = 4, Name = "Adventure" }
                );

                // ВАЖЛИВО: ReleaseDate — тільки статичні значення
                modelBuilder.Entity<Game>().HasData(
                    new Game { Id = 1, Name = "Half-Life", Rating = 9.8, PublisherId = 1, ReleaseDate = new DateTime(1998, 11, 19, 0, 0, 0, DateTimeKind.Utc) },
                    new Game { Id = 2, Name = "Half-Life 2", Rating = 9.9, PublisherId = 1, ReleaseDate = new DateTime(2004, 11, 16, 0, 0, 0, DateTimeKind.Utc) },
                    new Game { Id = 3, Name = "Portal", Rating = 9.5, PublisherId = 1, ReleaseDate = new DateTime(2007, 10, 10, 0, 0, 0, DateTimeKind.Utc) },
                    new Game { Id = 4, Name = "Portal 2", Rating = 9.7, PublisherId = 1, ReleaseDate = new DateTime(2011, 04, 19, 0, 0, 0, DateTimeKind.Utc) },

                    new Game { Id = 5, Name = "The Witcher", Rating = 9.0, PublisherId = 2, ReleaseDate = new DateTime(2007, 10, 26, 0, 0, 0, DateTimeKind.Utc) },
                    new Game { Id = 6, Name = "The Witcher 2", Rating = 9.2, PublisherId = 2, ReleaseDate = new DateTime(2011, 05, 17, 0, 0, 0, DateTimeKind.Utc) },
                    new Game { Id = 7, Name = "The Witcher 3", Rating = 9.9, PublisherId = 2, ReleaseDate = new DateTime(2015, 05, 19, 0, 0, 0, DateTimeKind.Utc) },

                    new Game { Id = 8, Name = "Assassin's Creed", Rating = 8.8, PublisherId = 3, ReleaseDate = new DateTime(2007, 11, 13, 0, 0, 0, DateTimeKind.Utc) },
                    new Game { Id = 9, Name = "Far Cry 3", Rating = 9.1, PublisherId = 3, ReleaseDate = new DateTime(2012, 11, 29, 0, 0, 0, DateTimeKind.Utc) },
                    new Game { Id = 10, Name = "Watch Dogs", Rating = 8.2, PublisherId = 3, ReleaseDate = new DateTime(2014, 05, 27, 0, 0, 0, DateTimeKind.Utc) }
                );

                modelBuilder.Entity<Game>()
                    .HasMany(g => g.Genres)
                    .WithMany(g => g.Games)
                    .UsingEntity(j => j.HasData(
                        new { GamesId = 1, GenresId = 3 },
                        new { GamesId = 2, GenresId = 3 },
                        new { GamesId = 3, GenresId = 4 },
                        new { GamesId = 4, GenresId = 4 },
                        new { GamesId = 5, GenresId = 2 },
                        new { GamesId = 6, GenresId = 2 },
                        new { GamesId = 7, GenresId = 2 },
                        new { GamesId = 8, GenresId = 1 },
                        new { GamesId = 9, GenresId = 1 },
                        new { GamesId = 10, GenresId = 1 }
                    ));

                return modelBuilder;
            }
        }
    

}
