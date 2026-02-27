using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Data;

using ShopMVC.Models;
using ShopMVC.ViewModels;
using System.Diagnostics;

namespace ShopMVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment _environment;

        public ShopController(AppDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            _environment = environment;
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
        // get
        public async Task<IActionResult> Create()
        {
            var categories = await context.Categories.ToListAsync();

            var viewModel = new CreateProductVM
            {
                SelectItems = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };


            return View(viewModel);
        }

        // post
        // [FromForm] - multipart/form-data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateProductVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = await context.Categories.ToListAsync();
                viewModel.SelectItems = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
                return View(viewModel);
            }

            var model = new ProductModel
            {
                CategoryId = viewModel.CategoryId <= 0 ? null : viewModel.CategoryId,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                CreateDate = viewModel.CreateDate
            };

            if (viewModel.Image != null)
            {
                model.Image = await SaveImageAsync(viewModel.Image);
            }

            await context.Products.AddAsync(model);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return RedirectToAction("Index");

            if (!string.IsNullOrWhiteSpace(product.Image))
            {
                var root = _environment.WebRootPath;
                var filePath = Path.Combine(root, "images", "products", product.Image);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        private async Task<string?> SaveImageAsync(IFormFile file)
        {
            try
            {
                var types = file.ContentType.Split("/");
                if (types.Length != 2 || types[0] != "image")
                {
                    return null;
                }

                string root = _environment.WebRootPath;
                string imagesPath = Path.Combine(root, "images", "products");
                string fileExtension = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtension;
                string filePath = Path.Combine(imagesPath, fileName);

                using var fileStream = System.IO.File.Create(filePath);
                using var imageStream = file.OpenReadStream();
                await imageStream.CopyToAsync(fileStream);

                return fileName;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();

            var categories = await context.Categories.ToListAsync();

            var vm = new EditProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ExistingImage = product.Image,
                SelectItems = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = (product.CategoryId == c.Id)
                })
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] EditProductVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = await context.Categories.ToListAsync();
                viewModel.SelectItems = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = (viewModel.CategoryId == c.Id)
                });

                return View(viewModel);
            }

            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (product == null) return NotFound();

            product.Name = viewModel.Name;
            product.Description = viewModel.Description;
            product.Price = viewModel.Price;
            product.CategoryId = (viewModel.CategoryId.HasValue && viewModel.CategoryId > 0)
                ? viewModel.CategoryId
                : null;

            if (viewModel.Image != null && viewModel.Image.Length > 0)
            {
                if (!string.IsNullOrWhiteSpace(product.Image))
                {
                    var oldFileName = Path.GetFileName(product.Image);
                    var oldPath = Path.Combine(_environment.WebRootPath, "images", "products", oldFileName);
                    if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                }

                product.Image = await SaveImageAsync(viewModel.Image);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
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
