namespace PromotionService.DTOs
{
    public record PromotionCreateDto(
     string Name,
     string? Description,
     decimal Discount,
     DateTime StartDate,
     DateTime? EndDate,
     List<PromotionDetailCreateDto> Details
 );
}
