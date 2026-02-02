using Microsoft.EntityFrameworkCore;
using VideoGameDB_relationship;

using var db = new AppDbContext();

Seeder.Seed(db);
Console.OutputEncoding = System.Text.Encoding.UTF8;


Console.WriteLine("\n1) Всі ігри з розробниками:");
var gamesWithDevs = db.Games
    .Include(g => g.Developer)
    .Select(g => new { g.Id, g.Title, g.Price, g.ReleaseYear, Developer = g.Developer.Name })
    .ToList();

foreach (var g in gamesWithDevs)
    Console.WriteLine($"{g.Id}. {g.Title} ({g.ReleaseYear}) | {g.Price:C} | {g.Developer}");


Console.WriteLine("\n2) Замовлення з клієнтами та іграми:");
var ordersFull = db.Orders
    .Include(o => o.Customer)
    .Include(o => o.Items)
    .ThenInclude(i => i.Game)
    .OrderBy(o => o.Id)
    .ToList();

foreach (var o in ordersFull)
{
    Console.WriteLine($"Order #{o.Id} | {o.OrderDate:yyyy-MM-dd} | Customer: {o.Customer.FullName}");
    foreach (var it in o.Items)
        Console.WriteLine($"   - {it.Game.Title} x{it.Quantity} ({it.Game.Price:C})");
}


Console.WriteLine("\n3) Сума кожного замовлення:");
var orderTotals = db.Orders
    .Select(o => new {
        o.Id,
        Customer = o.Customer.FullName,
        o.OrderDate,
        Total = o.Items.Sum(i => i.Quantity * i.Game.Price)
    })
    .OrderBy(x => x.Id)
    .ToList();

foreach (var x in orderTotals)
    Console.WriteLine($"Order #{x.Id} | {x.Customer} | {x.OrderDate:yyyy-MM-dd} | Total: {x.Total:C}");


Console.WriteLine("\n4) Топ 3 найдорожчі ігри:");
var top3 = db.Games
    .OrderByDescending(g => g.Price)
    .Take(3)
    .Select(g => new { g.Title, g.Price })
    .ToList();

foreach (var t in top3)
    Console.WriteLine($"{t.Title} — {t.Price:C}");


Console.WriteLine("\n5) Клієнти з більш ніж 1 замовленням:");
var customersManyOrders = db.Customers
    .Where(c => c.Orders.Count > 1)
    .Select(c => new { c.FullName, OrdersCount = c.Orders.Count })
    .ToList();

foreach (var c in customersManyOrders)
    Console.WriteLine($"{c.FullName} — {c.OrdersCount} orders");


Console.WriteLine("\n6) Загальний дохід магазину:");
var Total = db.Orders
    .Select(o => o.Items.Sum(i => i.Quantity * i.Game.Price))
    .Sum();

Console.WriteLine($" Total: {Total:C}");
