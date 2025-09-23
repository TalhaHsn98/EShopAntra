using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    public class ShoppingCartItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
