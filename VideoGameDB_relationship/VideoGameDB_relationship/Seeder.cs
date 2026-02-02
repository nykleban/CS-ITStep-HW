using System;
using System.Collections.Generic;
using System.Text;
using VideoGameDB_relationship.Entities;

namespace VideoGameDB_relationship
{
    public class Seeder
    {
        // згенеровано з ГПТ
        public static void Seed(AppDbContext db)
        {
            if (db.Developers.Any() || db.Games.Any() || db.Customers.Any() || db.Orders.Any() || db.OrderItems.Any())
                return;

            var devs = new List<DeveloperEntity>
            {
                new() { Name = "CD Projekt", Country = "Poland" },
                new() { Name = "Valve", Country = "USA" },
                new() { Name = "Rockstar Games", Country = "USA" },
                new() { Name = "Mojang", Country = "Sweden" },
                new() { Name = "FromSoftware", Country = "Japan" }
            };
            db.Developers.AddRange(devs);
            db.SaveChanges();

            var games = new List<GameEntity>
            {
                new() { Title="The Witcher 3", Price=29.99m, ReleaseYear=2015, DeveloperId=devs[0].Id },
                new() { Title="Cyberpunk 2077", Price=39.99m, ReleaseYear=2020, DeveloperId=devs[0].Id },
                new() { Title="Half-Life 2", Price=9.99m, ReleaseYear=2004, DeveloperId=devs[1].Id },
                new() { Title="Portal 2", Price=19.99m, ReleaseYear=2011, DeveloperId=devs[1].Id },
                new() { Title="GTA V", Price=49.99m, ReleaseYear=2013, DeveloperId=devs[2].Id },
                new() { Title="Red Dead Redemption 2", Price=59.99m, ReleaseYear=2018, DeveloperId=devs[2].Id },
                new() { Title="Minecraft", Price=26.95m, ReleaseYear=2011, DeveloperId=devs[3].Id },
                new() { Title="Elden Ring", Price=59.99m, ReleaseYear=2022, DeveloperId=devs[4].Id },
                new() { Title="Dark Souls III", Price=49.99m, ReleaseYear=2016, DeveloperId=devs[4].Id },
                new() { Title="Sekiro", Price=49.99m, ReleaseYear=2019, DeveloperId=devs[4].Id },
            };
            db.Games.AddRange(games);
            db.SaveChanges();

            var customers = new List<CustomerEntity>
            {
                new() { FullName="Ivan Petrenko", Email="ivan.petrenko@gmail.com" },
                new() { FullName="Olena Kovalenko", Email="olena.kovalenko@gmail.com" },
                new() { FullName="Andrii Shevchenko", Email="andrii.shevchenko@gmail.com" },
                new() { FullName="Maria Bondar", Email="maria.bondar@gmail.com" },
                new() { FullName="Dmytro Melnyk", Email="dmytro.melnyk@gmail.com" },
                new() { FullName="Sofiia Romanenko", Email="sofiia.romanenko@gmail.com" },
                new() { FullName="Taras Hnatiuk", Email="taras.hnatiuk@gmail.com" },
                new() { FullName="Iryna Lysenko", Email="iryna.lysenko@gmail.com" },
            };
            db.Customers.AddRange(customers);
            db.SaveChanges();

            // 10 замовлень (дехто має 2+)
            var baseDate = DateTime.Today.AddDays(-20);
            var orders = new List<OrderEntity>
            {
                new() { CustomerId=customers[0].Id, OrderDate=baseDate.AddDays(1) },
                new() { CustomerId=customers[1].Id, OrderDate=baseDate.AddDays(2) },
                new() { CustomerId=customers[2].Id, OrderDate=baseDate.AddDays(3) },
                new() { CustomerId=customers[3].Id, OrderDate=baseDate.AddDays(4) },
                new() { CustomerId=customers[4].Id, OrderDate=baseDate.AddDays(5) },
                new() { CustomerId=customers[0].Id, OrderDate=baseDate.AddDays(6) }, 
                new() { CustomerId=customers[1].Id, OrderDate=baseDate.AddDays(7) }, 
                new() { CustomerId=customers[5].Id, OrderDate=baseDate.AddDays(8) },
                new() { CustomerId=customers[6].Id, OrderDate=baseDate.AddDays(9) },
                new() { CustomerId=customers[7].Id, OrderDate=baseDate.AddDays(10) },
            };
            db.Orders.AddRange(orders);
            db.SaveChanges();

            // 20 позицій (по 2 на кожне замовлення)

            var items = new List<OrderItemEntity>
            {
                // order 1
                new() { OrderId=orders[0].Id, GameId=games[0].Id, Quantity=1 },
                new() { OrderId=orders[0].Id, GameId=games[2].Id, Quantity=2 },

                // order 2
                new() { OrderId=orders[1].Id, GameId=games[6].Id, Quantity=1 },
                new() { OrderId=orders[1].Id, GameId=games[3].Id, Quantity=1 },

                // order 3
                new() { OrderId=orders[2].Id, GameId=games[4].Id, Quantity=1 },
                new() { OrderId=orders[2].Id, GameId=games[1].Id, Quantity=1 },

                // order 4
                new() { OrderId=orders[3].Id, GameId=games[7].Id, Quantity=1 },
                new() { OrderId=orders[3].Id, GameId=games[8].Id, Quantity=1 },

                // order 5
                new() { OrderId=orders[4].Id, GameId=games[5].Id, Quantity=1 },
                new() { OrderId=orders[4].Id, GameId=games[6].Id, Quantity=3 },

                // order 6
                new() { OrderId=orders[5].Id, GameId=games[0].Id, Quantity=1 },
                new() { OrderId=orders[5].Id, GameId=games[9].Id, Quantity=1 },

                // order 7
                new() { OrderId=orders[6].Id, GameId=games[4].Id, Quantity=1 },
                new() { OrderId=orders[6].Id, GameId=games[3].Id, Quantity=1 },

                // order 8
                new() { OrderId=orders[7].Id, GameId=games[2].Id, Quantity=1 },
                new() { OrderId=orders[7].Id, GameId=games[6].Id, Quantity=1 },

                // order 9
                new() { OrderId=orders[8].Id, GameId=games[7].Id, Quantity=1 },
                new() { OrderId=orders[8].Id, GameId=games[5].Id, Quantity=1 },

                // order 10
                new() { OrderId=orders[9].Id, GameId=games[1].Id, Quantity=2 },
                new() { OrderId=orders[9].Id, GameId=games[8].Id, Quantity=1 },
            };

            db.OrderItems.AddRange(items);
            db.SaveChanges();
        }
    }
}
