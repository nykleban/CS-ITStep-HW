using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using VolleyballDB.Models;

namespace VolleyballDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var db = new AppDbContext();
            //Облік результатів ігор




            //Вивести турнірну таблицю команд
            var teams = db.Teams
                .Include(t => t.HomeGames)
                .Include(t => t.AwayGames)
                .Select(x => new TableResult
                {
                    Team = x,
                    TotalPoints = x.HomeGames.Sum(g => g.Team1Score) + x.AwayGames.Sum(g => g.Team2Score),
                    GamesPlayed = x.HomeGames.Count + x.AwayGames.Count
                }).OrderByDescending(x => x.TotalPoints).ToList();

            Console.WriteLine("Турнірна таблиця:");
            teams.ForEach(Console.WriteLine);
        }
    }
}
