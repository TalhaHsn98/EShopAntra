namespace ProductService.DTOs
{
    public record ProductVariationDto(int ProductId, List<int> VariationValueIds);

}
