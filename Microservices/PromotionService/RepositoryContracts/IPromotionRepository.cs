using Microsoft.AspNetCore.Mvc;

namespace PromotionService.RepositoryContracts
{
    public class IPromotionRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
