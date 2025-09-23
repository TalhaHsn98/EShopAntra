using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using OrderService.Models;
using OrderService.ServiceContracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _svc;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartService svc, IMapper mapper)
        {
            _svc = svc; _mapper = mapper;
        }

        [HttpGet("GetShoppingCartByCustomerId")]
        public async Task<ActionResult<ShoppingCartResponse>> GetByCustomerId([FromQuery] int customerId)
        {
            var entity = await _svc.GetByCustomerIdAsync(customerId);
            if (entity is null) return Ok(null);
            var dto = _mapper.Map<ShoppingCartResponse>(entity);
            return Ok(dto);
        }

        [HttpPost("SaveShoppingCart")]
        public async Task<ActionResult<int>> Save([FromBody] ShoppingCartCreateRequest request)
            => Ok(await _svc.SaveAsync(request));

        [HttpDelete("DeleteShoppingCart")]
        public async Task<IActionResult> Delete([FromQuery] int cartId)
            => await _svc.DeleteAsync(cartId) ? NoContent() : NotFound();
    }
}
