namespace ShopMVC.ViewModels
{
    public class CartIndexVM
    {
        public List<CartItemVM> Items { get; set; } = new List<CartItemVM>();
        public decimal Total => Items.Sum(i => i.LineTotal);
    }
}

