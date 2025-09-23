using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    public class CategoryVariationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
