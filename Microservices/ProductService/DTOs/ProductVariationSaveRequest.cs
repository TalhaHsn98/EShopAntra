namespace ProductService.DTOs
{
    public record ProductVariationSaveRequest(int ProductId, List<int> VariationValueIds);

}
