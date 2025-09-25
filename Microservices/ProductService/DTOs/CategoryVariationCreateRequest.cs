using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public record CategoryVariationCreateRequest(
    [Required] int CategoryId,
    [Required, MaxLength(100)] string VariationName
);
}
