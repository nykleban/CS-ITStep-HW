using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoGameDB_relationship.Entities;

namespace VideoGameDB_relationship
{ 
    public class AppDbContext : DbContext
    {
        public DbSet<GameEntity> Games => Set<GameEntity>();
        public DbSet<DeveloperEntity> Developers => Set<DeveloperEntity>();
        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                "Server=localhost;Database=db_videogames;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            b.Entity<DeveloperEntity>(b =>
            {
               b.HasKey(x => x.Id);
               b.Property(x => x.Name).IsRequired().HasMaxLength(120);
               b.Property(x => x.Country).IsRequired().HasMaxLength(80);
            });
            b.Entity<GameEntity>(b =>
            { 
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(160);
                b.Property(x => x.Price).HasColumnType("decimal(10,2)").IsRequired();
                b.Property(x => x.ReleaseYear).IsRequired();
                b.HasOne(x => x.Developer)
                 .WithMany(d => d.Games)
                 .HasForeignKey(x => x.DeveloperId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            b.Entity<CustomerEntity>(b=>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.FullName).IsRequired().HasMaxLength(150);
                b.Property(x => x.Email).IsRequired().HasMaxLength(150);
                b.HasIndex(x => x.Email).IsUnique();
            });
            b.Entity<OrderEntity>(b=>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.OrderDate).IsRequired();
                b.HasOne(x => x.Customer)
                 .WithMany(c => c.Orders)
                 .HasForeignKey(x => x.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
            b.Entity<OrderItemEntity>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Quantity).IsRequired();
                b.HasOne(x => x.Order)
                 .WithMany(o => o.Items)
                 .HasForeignKey(x => x.OrderId)
                 .OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Game)
                .WithMany(g => g.OrderItems)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);
                b.HasIndex(x => new { x.OrderId, x.GameId })
                .IsUnique();

            });
        }
    }

}
