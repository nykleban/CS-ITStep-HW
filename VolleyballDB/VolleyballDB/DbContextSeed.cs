using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VolleyballDB.Entities;

namespace VolleyballDB
{
    internal static class DbContextSeed
    {
        public static void InitRelations(this ModelBuilder mb)
        {

            mb.Entity<Game>()
                .HasOne(g => g.TeamHome)
                .WithMany(t => t.HomeGames)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Game>()
                .HasOne(g => g.TeamAway)
                .WithMany(t => t.AwayGames)
                .OnDelete(DeleteBehavior.Restrict);

        }
        public static void Seed(this ModelBuilder mb)
        {

            // Teams A-H
            mb.Entity<Team>().HasData(
                new Team { Id = 1, Name = "A" },
                new Team { Id = 2, Name = "B" },
                new Team { Id = 3, Name = "C" },
                new Team { Id = 4, Name = "D" },
                new Team { Id = 5, Name = "E" },
                new Team { Id = 6, Name = "F" },
                new Team { Id = 7, Name = "G" },
                new Team { Id = 8, Name = "H" }
            );

            // 20 Games, each team plays exactly 5 games
            mb.Entity<Game>().HasData(
                // Round 1
                new Game { Id = 1, TeamHomeId = 1, TeamAwayId = 8, Team1Score = 3, Team2Score = 1 }, // A vs H
                new Game { Id = 2, TeamHomeId = 2, TeamAwayId = 7, Team1Score = 2, Team2Score = 3 }, // B vs G
                new Game { Id = 3, TeamHomeId = 3, TeamAwayId = 6, Team1Score = 3, Team2Score = 0 }, // C vs F
                new Game { Id = 4, TeamHomeId = 4, TeamAwayId = 5, Team1Score = 1, Team2Score = 3 }, // D vs E

                // Round 2
                new Game { Id = 5, TeamHomeId = 1, TeamAwayId = 7, Team1Score = 3, Team2Score = 2 }, // A vs G
                new Game { Id = 6, TeamHomeId = 8, TeamAwayId = 6, Team1Score = 0, Team2Score = 3 }, // H vs F
                new Game { Id = 7, TeamHomeId = 2, TeamAwayId = 5, Team1Score = 3, Team2Score = 1 }, // B vs E
                new Game { Id = 8, TeamHomeId = 3, TeamAwayId = 4, Team1Score = 2, Team2Score = 3 }, // C vs D

                // Round 3
                new Game { Id = 9, TeamHomeId = 1, TeamAwayId = 6, Team1Score = 1, Team2Score = 3 }, // A vs F
                new Game { Id = 10, TeamHomeId = 7, TeamAwayId = 5, Team1Score = 3, Team2Score = 0 }, // G vs E
                new Game { Id = 11, TeamHomeId = 8, TeamAwayId = 4, Team1Score = 2, Team2Score = 3 }, // H vs D
                new Game { Id = 12, TeamHomeId = 2, TeamAwayId = 3, Team1Score = 0, Team2Score = 3 }, // B vs C

                // Round 4
                new Game { Id = 13, TeamHomeId = 1, TeamAwayId = 5, Team1Score = 3, Team2Score = 0 }, // A vs E
                new Game { Id = 14, TeamHomeId = 6, TeamAwayId = 4, Team1Score = 3, Team2Score = 1 }, // F vs D
                new Game { Id = 15, TeamHomeId = 7, TeamAwayId = 3, Team1Score = 2, Team2Score = 3 }, // G vs C
                new Game { Id = 16, TeamHomeId = 8, TeamAwayId = 2, Team1Score = 3, Team2Score = 2 }, // H vs B

                // Round 5
                new Game { Id = 17, TeamHomeId = 1, TeamAwayId = 4, Team1Score = 2, Team2Score = 3 }, // A vs D
                new Game { Id = 18, TeamHomeId = 5, TeamAwayId = 3, Team1Score = 3, Team2Score = 1 }, // E vs C
                new Game { Id = 19, TeamHomeId = 6, TeamAwayId = 2, Team1Score = 2, Team2Score = 3 }, // F vs B
                new Game { Id = 20, TeamHomeId = 7, TeamAwayId = 8, Team1Score = 3, Team2Score = 0 }  // G vs H
            );


        }
    }
}
