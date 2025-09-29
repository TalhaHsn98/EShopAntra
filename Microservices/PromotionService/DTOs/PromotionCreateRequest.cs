using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{
    public record PromotionCreateRequest(
    string Name,
    string? Description,
    double Discount,
    DateTime StartDate,
    DateTime? EndDate,
    List<PromotionDetailRequest> Details
);
}
