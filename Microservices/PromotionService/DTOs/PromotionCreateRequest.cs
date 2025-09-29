using Microsoft.AspNetCore.Mvc;

namespace PromotionService.DTOs
{
    public class PromotionCreateRequest : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
