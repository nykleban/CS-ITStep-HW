using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Data;
using ShopMVC.Models;
using ShopMVC.ViewModels;
using System.Diagnostics;

namespace ShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? category)
        {
            var categories = await _context.Categories.ToListAsync();
            IQueryable<ProductModel> products = _context.Products;

            if (!string.IsNullOrWhiteSpace(category))
            {

                var queryCategory = categories
                    .FirstOrDefault(c => c.Name.ToLower() == category.ToLower());

                if (queryCategory == null)
                {
                    return RedirectToAction("Index");
                }

                products = products.Where(p => p.CategoryId == queryCategory.Id);
            }


            var viewModel = new HomeVM
            {
                Products = await products.ToListAsync(),
                Categories = categories
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
