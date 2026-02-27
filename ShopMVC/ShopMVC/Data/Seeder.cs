using Microsoft.EntityFrameworkCore;
using ShopMVC.Models;

namespace ShopMVC.Data
{
    public static class Seeder
    {
        public static void Seed(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.Migrate();

            if (!dbContext.Categories.Any())
            {
                var categories = new List<CategoryModel>
                {
                    new CategoryModel
                    {
                        Name = "Процесори",
                        Icon = "bi bi-cpu",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "AMD Ryzen 5 5600X", Description = "6 ядер, 3.7–4.6 GHz", Price = 5999, Image = null, Rating = 4.7f, Amount = 12 },
                            new() { Name = "Intel Core i5-12400F", Description = "6 ядер, до 4.4 GHz", Price = 7200, Image = null, Rating = 4.2f, Amount = 0 },
                            new() { Name = "AMD Ryzen 7 5800X", Description = "8 ядер, 16 потоків", Price = 10500, Image = null, Rating = 4.6f, Amount = 7 },
                            new() { Name = "Intel Core i7-12700K", Description = "12 ядер", Price = 14999, Image = null, Rating = 4.9f, Amount = 3 },
                            new() { Name = "AMD Ryzen 9 5900X", Description = "12 ядер, 24 потоки", Price = 16500, Image = null, Rating = 4.8f, Amount = 1 }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "Відеокарти",
                        Icon = "bi bi-gpu-card",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "NVIDIA RTX 3060", Description = "12GB GDDR6", Price = 13500, Image = null, Rating = 4.1f, Amount = 5 },
                            new() { Name = "NVIDIA RTX 4070", Description = "12GB GDDR6X", Price = 29999, Image = null, Rating = 4.5f, Amount = 2 },
                            new() { Name = "AMD RX 6600", Description = "8GB", Price = 10500, Image = null, Rating = 3.9f, Amount = 0 },
                            new() { Name = "AMD RX 6700 XT", Description = "12GB", Price = 14999, Image = null, Rating = 4.3f, Amount = 6 },
                            new() { Name = "NVIDIA RTX 4090", Description = "24GB GDDR6X", Price = 89999, Image = null, Rating = 5.0f, Amount = 1 }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "Материнські плати",
                        Icon = "bi bi-motherboard",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "ASUS TUF B550-PLUS", Description = "AM4, ATX", Price = 5200, Image = null, Rating = 4.0f, Amount = 8 },
                            new() { Name = "MSI B660M PRO", Description = "LGA1700", Price = 4700, Image = null, Rating = 3.7f, Amount = 0 },
                            new() { Name = "Gigabyte Z790 AORUS", Description = "DDR5", Price = 12500, Image = null, Rating = 4.4f, Amount = 4 },
                            new() { Name = "ASRock B450M Steel Legend", Description = "mATX", Price = 3900, Image = null, Rating = 3.6f, Amount = 10 },
                            new() { Name = "MSI X570 Gaming Plus", Description = "ATX", Price = 7600, Image = null, Rating = 4.2f, Amount = 2 }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "Оперативна пам'ять",
                        Icon = "bi bi-memory",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "Kingston Fury 16GB", Description = "DDR4 3200MHz", Price = 1800, Image = null, Rating = 4.1f, Amount = 15 },
                            new() { Name = "Corsair Vengeance 32GB", Description = "DDR4 3600MHz", Price = 4200, Image = null, Rating = 4.4f, Amount = 3 },
                            new() { Name = "G.Skill Trident Z 16GB", Description = "RGB", Price = 2500, Image = null, Rating = 3.8f, Amount = 0 },
                            new() { Name = "Kingston Fury Beast 32GB", Description = "DDR5", Price = 6200, Image = null, Rating = 4.6f, Amount = 6 },
                            new() { Name = "Corsair Dominator 64GB", Description = "DDR5", Price = 14500, Image = null, Rating = 4.9f, Amount = 1 }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "SSD накопичувачі",
                        Icon = "bi bi-device-ssd",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "Samsung 970 EVO Plus 1TB", Description = "NVMe", Price = 3600, Image = null, Rating = 4.7f, Amount = 9 },
                            new() { Name = "WD Black SN850 1TB", Description = "PCIe 4.0", Price = 4200, Image = null, Rating = 4.6f, Amount = 0 },
                            new() { Name = "Kingston NV2 1TB", Description = "Gen4", Price = 2500, Image = null, Rating = 3.5f, Amount = 14 },
                            new() { Name = "Crucial MX500 1TB", Description = "SATA", Price = 2800, Image = null, Rating = 4.0f, Amount = 4 },
                            new() { Name = "Samsung 990 PRO 2TB", Description = "NVMe", Price = 8500, Image = null, Rating = 4.8f, Amount = 2 }
                        }
                    }
                };

                dbContext.Categories.AddRange(categories);
                dbContext.SaveChanges();
            }
        }
    }
}