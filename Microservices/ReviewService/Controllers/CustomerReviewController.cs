using Microsoft.AspNetCore.Mvc;

namespace ReviewService.Controllers
{
    public class CustomerReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
