using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ShopMVC.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(CategoryId))]
        public int? CategoryId { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
