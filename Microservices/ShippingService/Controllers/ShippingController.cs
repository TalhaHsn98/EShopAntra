using Microsoft.AspNetCore.Mvc;

namespace ShippingService.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
