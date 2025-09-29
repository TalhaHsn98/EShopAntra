using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{

    public record PromotionResponse(
        int Id,
        string Name,
        string? Description,
        double Discount,
        DateTime StartDate,
        DateTime? EndDate,
        List<PromotionDetailResponse> Details
    );
}
