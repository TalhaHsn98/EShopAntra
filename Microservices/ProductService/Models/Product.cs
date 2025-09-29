using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ProductService.Models.Productvariationvalue;

namespace ProductService.Models
{
    [Index(nameof(SKU), IsUnique = true)]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Qty { get; set; }
        [MaxLength(1000)]
        public string? ProductImage { get; set; }
        [Required, MaxLength(100)]
        public string SKU { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<ProductVariationValue> VariationValues { get; set; } = new List<ProductVariationValue>();
    }
}
