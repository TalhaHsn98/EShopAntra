using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{
    public class PromotionDetailResponse : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
