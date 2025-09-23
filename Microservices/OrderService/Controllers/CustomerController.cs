using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
