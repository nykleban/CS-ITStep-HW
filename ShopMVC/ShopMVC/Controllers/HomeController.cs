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

        // Home/Index

        public async Task<IActionResult> Index( [FromQuery] string? category, [FromQuery] int page = 1,
            [FromQuery] int pageSize = 24, [FromQuery] string? sort = null)
        {

            var categories = await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();

            IQueryable<ProductModel> products = _context.Products;

            if (!string.IsNullOrWhiteSpace(category))
            {
                var queryCategory = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Name.ToLower() == category.ToLower());

                if (queryCategory == null)
                    return RedirectToAction(nameof(Index));

                products = products.Where(p => p.CategoryId == queryCategory.Id);
            }

            // sort
            products = sort switch
            {
                "price_asc" => products.OrderBy(p => p.Price),
                "price_desc" => products.OrderByDescending(p => p.Price),
                "name_asc" => products.OrderBy(p => p.Name),
                "name_desc" => products.OrderByDescending(p => p.Name),
                "rating_desc" => products.OrderByDescending(p => p.Rating),
                _ => products.OrderBy(p => p.Id)
            };

            // pagination
            if (pageSize < 1) pageSize = 24;
            var totalCount = await products.CountAsync();
            var pageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (pageCount < 1) pageCount = 1;

            if (page < 1) page = 1;
            if (page > pageCount) page = pageCount;

            var items = await products
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();

            var vm = new HomeVM
            {
                Products = items,
                Categories = categories,
                Category = category,
                Sort = sort,
                Pagination = new PaginationVM
                {
                    Page = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    PageCount = pageCount
                }
            };

            return View(vm);
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
