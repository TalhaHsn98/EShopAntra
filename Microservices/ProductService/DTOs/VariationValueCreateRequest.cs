using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public record VariationValueCreateRequest(
    [Required] int VariationId,
    [Required, MaxLength(150)] string Value
);
}
