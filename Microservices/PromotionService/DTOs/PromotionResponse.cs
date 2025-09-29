using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{
    public class PromotionResponse : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
