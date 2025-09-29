using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{
    public record PromotionDetailResponse(
    int Id,
    int ProductCategoryId,
    string ProductCategoryName
);
}
