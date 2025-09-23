namespace PromotionService.DTOs
{
    public record PromotionUpdateDto(
     int Id,
     string Name,
     string? Description,
     decimal Discount,
     DateTime StartDate,
     DateTime? EndDate,
     List<PromotionDetailCreateDto> Details
 );
}
