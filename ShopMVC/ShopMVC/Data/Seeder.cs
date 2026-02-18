using Microsoft.EntityFrameworkCore;
using ShopMVC.Models;
using System.Runtime.CompilerServices;

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
                        Products = new List<ProductModel>
                        {
                            new() { Name = "AMD Ryzen 5 5600X", Description = "6 ядер, 3.7–4.6 GHz", Price = 5999, Image = "https://upload.wikimedia.org/wikipedia/commons/1/16/AMD_Ryzen_5_2600_%2839851733273%29.jpg" },
                            new() { Name = "Intel Core i5-12400F", Description = "6 ядер, до 4.4 GHz", Price = 7200, Image = "https://upload.wikimedia.org/wikipedia/commons/1/14/Intel_CPU_Core_i7_6700K_Skylake_top.jpg" },
                            new() { Name = "AMD Ryzen 7 5800X", Description = "8 ядер, 16 потоків", Price = 10500, Image = "https://upload.wikimedia.org/wikipedia/commons/1/16/AMD_Ryzen_5_2600_%2839851733273%29.jpg" },
                            new() { Name = "Intel Core i7-12700K", Description = "12 ядер", Price = 14999, Image = "https://upload.wikimedia.org/wikipedia/commons/1/14/Intel_CPU_Core_i7_6700K_Skylake_top.jpg" },
                            new() { Name = "AMD Ryzen 9 5900X", Description = "12 ядер, 24 потоки", Price = 16500, Image = "https://upload.wikimedia.org/wikipedia/commons/1/16/AMD_Ryzen_5_2600_%2839851733273%29.jpg" }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "Відеокарти",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "NVIDIA RTX 3060", Description = "12GB GDDR6", Price = 13500, Image = "https://upload.wikimedia.org/wikipedia/commons/d/df/RTX_3090_Founders_Edition%21.jpg" },
                            new() { Name = "NVIDIA RTX 4070", Description = "12GB GDDR6X", Price = 29999, Image = "https://upload.wikimedia.org/wikipedia/commons/d/df/RTX_3090_Founders_Edition%21.jpg" },
                            new() { Name = "AMD RX 6600", Description = "8GB", Price = 10500, Image = "https://upload.wikimedia.org/wikipedia/commons/d/df/RTX_3090_Founders_Edition%21.jpg" },
                            new() { Name = "AMD RX 6700 XT", Description = "12GB", Price = 14999, Image = "https://upload.wikimedia.org/wikipedia/commons/d/df/RTX_3090_Founders_Edition%21.jpg" },
                            new() { Name = "NVIDIA RTX 4090", Description = "24GB GDDR6X", Price = 89999, Image = "https://upload.wikimedia.org/wikipedia/commons/d/df/RTX_3090_Founders_Edition%21.jpg" }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "Материнські плати",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "ASUS TUF B550-PLUS", Description = "AM4, ATX", Price = 5200, Image = "https://upload.wikimedia.org/wikipedia/commons/3/31/ATX_Formate.jpg" },
                            new() { Name = "MSI B660M PRO", Description = "LGA1700", Price = 4700, Image = "https://upload.wikimedia.org/wikipedia/commons/3/31/ATX_Formate.jpg" },
                            new() { Name = "Gigabyte Z790 AORUS", Description = "DDR5", Price = 12500, Image = "https://upload.wikimedia.org/wikipedia/commons/3/31/ATX_Formate.jpg" },
                            new() { Name = "ASRock B450M Steel Legend", Description = "mATX", Price = 3900, Image = "https://upload.wikimedia.org/wikipedia/commons/3/31/ATX_Formate.jpg" },
                            new() { Name = "MSI X570 Gaming Plus", Description = "ATX", Price = 7600, Image = "https://upload.wikimedia.org/wikipedia/commons/3/31/ATX_Formate.jpg" }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "Оперативна пам'ять",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "Kingston Fury 16GB", Description = "DDR4 3200MHz", Price = 1800, Image = "https://upload.wikimedia.org/wikipedia/commons/6/6c/RAM_Module_%28SDRAM-DDR4%29.jpg" },
                            new() { Name = "Corsair Vengeance 32GB", Description = "DDR4 3600MHz", Price = 4200, Image = "https://upload.wikimedia.org/wikipedia/commons/6/6c/RAM_Module_%28SDRAM-DDR4%29.jpg" },
                            new() { Name = "G.Skill Trident Z 16GB", Description = "RGB", Price = 2500, Image = "https://upload.wikimedia.org/wikipedia/commons/6/6c/RAM_Module_%28SDRAM-DDR4%29.jpg" },
                            new() { Name = "Kingston Fury Beast 32GB", Description = "DDR5", Price = 6200, Image = "https://upload.wikimedia.org/wikipedia/commons/6/6c/RAM_Module_%28SDRAM-DDR4%29.jpg" },
                            new() { Name = "Corsair Dominator 64GB", Description = "DDR5", Price = 14500, Image = "https://upload.wikimedia.org/wikipedia/commons/6/6c/RAM_Module_%28SDRAM-DDR4%29.jpg" }
                        }
                    },

                    new CategoryModel
                    {
                        Name = "SSD накопичувачі",
                        Products = new List<ProductModel>
                        {
                            new() { Name = "Samsung 970 EVO Plus 1TB", Description = "NVMe", Price = 3600, Image = "https://upload.wikimedia.org/wikipedia/commons/e/ed/1TB_2280_NVME_SSD.jpg" },
                            new() { Name = "WD Black SN850 1TB", Description = "PCIe 4.0", Price = 4200, Image = "https://upload.wikimedia.org/wikipedia/commons/e/ed/1TB_2280_NVME_SSD.jpg" },
                            new() { Name = "Kingston NV2 1TB", Description = "Gen4", Price = 2500, Image = "https://upload.wikimedia.org/wikipedia/commons/e/ed/1TB_2280_NVME_SSD.jpg" },
                            new() { Name = "Crucial MX500 1TB", Description = "SATA", Price = 2800, Image = "https://upload.wikimedia.org/wikipedia/commons/e/ed/1TB_2280_NVME_SSD.jpg" },
                            new() { Name = "Samsung 990 PRO 2TB", Description = "NVMe", Price = 8500, Image = "https://upload.wikimedia.org/wikipedia/commons/e/ed/1TB_2280_NVME_SSD.jpg" }
                        }
                    }
                };

                dbContext.Categories.AddRange(categories);
                dbContext.SaveChanges();
            }
        }
    }
}
