using Microsoft.AspNetCore.Mvc;

namespace ShippingService.Controllers
{
    public class ShippingDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
