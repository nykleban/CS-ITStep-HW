using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GameStoreDB.Entities;
using System.Linq;

namespace GameStoreDB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                "Server=localhost;Database=db_videogames;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //mb.Entity<Game>()
            //    .HasMany(g => g.Genres)
            //    .WithMany(g => g.Games);
            //mb.Entity<Game>()
            //    .HasOne(p => p.Publisher)
            //    .WithMany(g => g.Games);

            // тут я взнав що не обов'язково взагалі ці зв'язки прописувати 
            mb.SeedGameStore();
            base.OnModelCreating(mb);
        }
    }
}
