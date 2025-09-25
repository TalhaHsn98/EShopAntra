namespace ProductService.DTOs
{
    public record CategoryVariationDto(
    int Id,
    int CategoryId,
    string VariationName
);
}
