using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{
    public record PromotionUpdateRequest(
     int Id,
     string Name,
     string? Description,
     double Discount,
     DateTime StartDate,
     DateTime? EndDate,
     List<PromotionDetailRequest> Details
 );
}
