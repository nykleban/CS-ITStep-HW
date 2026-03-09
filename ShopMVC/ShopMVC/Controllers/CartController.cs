using Microsoft.AspNetCore.Mvc;
using ShopMVC.Data;
using ShopMVC.Services;
using ShopMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
//using ShopMVC.ViewModels;

namespace ShopMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _db;

        public CartController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var sessionItems = CartService.GetItems(HttpContext.Session);

            var ids = sessionItems.Select(i => i.ProductId).ToList();

            var products = await _db.Products
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();

            var vm = new CartIndexVM
            {
                Items = sessionItems.Select(si =>
                {
                    var product = products.First(p => p.Id == si.ProductId);
                    return new CartItemVM
                    {
                        Product = product,
                        Count = si.Count
                    };
                }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(int productId)
        {
            CartService.AddToCart(HttpContext.Session, productId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Plus(int productId)
        {
            CartService.Increase(HttpContext.Session, productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Minus(int productId)
        {
            CartService.Decrease(HttpContext.Session, productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            CartService.RemoveFromCart(HttpContext.Session, productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Clear()
        {
            CartService.Clear(HttpContext.Session);
            return RedirectToAction(nameof(Index));
        }
    }
}
