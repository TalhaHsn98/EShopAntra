using Microsoft.AspNetCore.Mvc;
using OrderService.ServiceContracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartService _svc;
        public ShoppingCartItemController(IShoppingCartService svc) { _svc = svc; }

        [HttpDelete("DeleteShoppingCartItemById")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
            => await _svc.DeleteItemAsync(id) ? NoContent() : NotFound();
    }
}
