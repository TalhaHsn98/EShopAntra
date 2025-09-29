using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{

    public record ProductCreateRequest(
        [Required] int CategoryId,
        [Required, MaxLength(250)] string Name,
        string? Description,
        [Range(0, double.MaxValue)] decimal Price,
        [Range(0, int.MaxValue)] int Qty,
        [MaxLength(1000)] string? ProductImage,
        [Required, MaxLength(100)] string SKU,
        List<int>? VariationValueIds
    );
}
