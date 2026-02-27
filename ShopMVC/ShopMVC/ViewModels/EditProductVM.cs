using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ShopMVC.ViewModels
{
    public class EditProductVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public IFormFile? Image { get; set; }

        public string? ExistingImage { get; set; }

        public IEnumerable<SelectListItem>? SelectItems { get; set; }
    }
}
