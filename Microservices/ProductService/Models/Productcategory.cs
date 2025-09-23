using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    [Index(nameof(Name), IsUnique = false)]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public ProductCategory? ParentCategory { get; set; }
        public ICollection<ProductCategory> Children { get; set; } = new List<ProductCategory>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<CategoryVariation> Variations { get; set; } = new List<CategoryVariation>();
    }
}
