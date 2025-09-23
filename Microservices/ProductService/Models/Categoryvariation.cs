using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class CategoryVariation
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; } = null!;
        [Required, MaxLength(100)]
        public string VariationName { get; set; } = string.Empty;
        public ICollection<VariationValue> Values { get; set; } = new List<VariationValue>();
    }
}
