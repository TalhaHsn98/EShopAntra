using System.ComponentModel.DataAnnotations;
using static ProductService.Models.Productvariationvalue;

namespace ProductService.Models
{
    public class VariationValue
    {
        [Key]
        public int Id { get; set; }
        public int VariationId { get; set; }
        public CategoryVariation Variation { get; set; } = null!;
        [Required, MaxLength(150)]
        public string Value { get; set; } = string.Empty;
        public ICollection<ProductVariationValue> ProductLinks { get; set; } = new List<ProductVariationValue>();
    }
}
