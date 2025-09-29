using Microsoft.AspNetCore.Mvc;

namespace PromotionService.Mapping
{
    public class PromotionsMappingProfile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
