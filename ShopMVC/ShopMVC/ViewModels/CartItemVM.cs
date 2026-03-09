using ShopMVC.Models;

namespace ShopMVC.ViewModels
{
    public class CartItemVM
    {
        public ProductModel Product { get; set; } = null!;
        public int Count { get; set; }
        public decimal LineTotal => Product.Price * Count;
    }
}
