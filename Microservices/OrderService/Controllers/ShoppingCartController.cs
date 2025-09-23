using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
