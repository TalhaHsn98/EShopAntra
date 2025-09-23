using Microsoft.AspNetCore.Mvc;

namespace PromotionService.Controllers
{
    public class PromotionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
