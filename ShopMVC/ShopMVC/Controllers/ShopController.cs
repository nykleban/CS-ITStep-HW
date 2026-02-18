using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Data;
using ShopMVC.Models;
using System.Diagnostics;

namespace ShopMVC.Controllers
{
    public class ShopController : Controller
    {
        public readonly AppDbContext context;
        public ShopController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ProductModel> products = context.Products
                .Include(p => p.Category)
                .AsEnumerable();

            return View(products);
        }
        public IActionResult Details(int id)
        {
            ProductModel product = context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
