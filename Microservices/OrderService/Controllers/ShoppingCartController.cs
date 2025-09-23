using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.ServiceContracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _svc;
        public ShoppingCartController(IShoppingCartService svc) { _svc = svc; }

        [HttpGet("GetShoppingCartByCustomerId")]
        public async Task<ActionResult<ShoppingCart?>> GetByCustomerId([FromQuery] int customerId)
            => Ok(await _svc.GetByCustomerIdAsync(customerId));

        [HttpPost("SaveShoppingCart")]
        public async Task<ActionResult<int>> Save([FromBody] ShoppingCart cart)
            => Ok(await _svc.SaveAsync(cart));

        [HttpDelete("DeleteShoppingCart")]
        public async Task<IActionResult> Delete([FromQuery] int cartId)
            => await _svc.DeleteAsync(cartId) ? NoContent() : NotFound();
    }
}
