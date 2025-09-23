using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    public class ProductVariationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
