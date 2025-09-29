using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{
    public record PromotionDetailRequest(int ProductCategoryId, string ProductCategoryName);

}
