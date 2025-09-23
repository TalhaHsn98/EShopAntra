using Microsoft.EntityFrameworkCore;

namespace ProductService.Models
{
    public class Productvariationvalue
    {
        [Index(nameof(ProductId), nameof(VariationValueId), IsUnique = true)]
        public class ProductVariationValue
        {
            public int ProductId { get; set; }
            public Product Product { get; set; } = null!;
            public int VariationValueId { get; set; }
            public VariationValue VariationValue { get; set; } = null!;
        }
    }
}
