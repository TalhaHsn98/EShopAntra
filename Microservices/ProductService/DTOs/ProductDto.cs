namespace ProductService.DTOs
{
    public record ProductDto(
    int Id,
    string Name,
    string? Description,
    int CategoryId,
    decimal Price,
    int Qty,
    string? ProductImage,
    string SKU,
    bool IsActive,
    List<int> VariationValueIds
);
}
