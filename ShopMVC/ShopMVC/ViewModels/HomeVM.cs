using ShopMVC.Models;

namespace ShopMVC.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<ProductModel> Products { get; set; } = [];
        public IEnumerable<CategoryModel> Categories { get; set; } = [];
        public PaginationVM Pagination { get; set; } = new();
        public string? Category { get; set; } = null;
        public string? Sort { get; set; } = null;
    }
}
