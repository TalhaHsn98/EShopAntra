using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using OrderService.ServiceContracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _svc;
        private readonly IMapper _mapper;

        public OrderController(IOrderService svc, IMapper mapper)
        {
            _svc = svc; _mapper = mapper;
        }

        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<List<OrderResponse>>> GetAll()
        {
            var list = await _svc.GetAllAsync();
            var dto = list.Select(_mapper.Map<OrderResponse>).ToList();
            return Ok(dto);
        }

        [HttpGet("GetOrdersByCustomerId")]
        public async Task<ActionResult<List<OrderResponse>>> GetByCustomerId([FromQuery] int customerId)
        {
            var list = await _svc.GetByCustomerAsync(customerId);
            var dto = list.Select(_mapper.Map<OrderResponse>).ToList();
            return Ok(dto);
        }

        [HttpGet("GetOrderById")]
        public async Task<ActionResult<OrderResponse>> GetById([FromQuery] int id)
        {
            var entity = await _svc.GetByIdAsync(id);
            if (entity is null) return NotFound();
            var dto = _mapper.Map<OrderResponse>(entity);
            return Ok(dto);
        }

        [HttpGet("CheckOrderStatus")]
        public async Task<ActionResult<string?>> CheckStatus([FromQuery] int orderId)
            => Ok(await _svc.CheckStatusAsync(orderId));

        [HttpPost("SaveOrder")]
        public async Task<ActionResult<int>> Create([FromBody] OrderCreateRequest request)
            => Ok(await _svc.CreateAsync(request));

        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> Update([FromBody] OrderUpdateRequest request)
            => await _svc.UpdateAsync(request) ? NoContent() : NotFound();

        [HttpPut("OrderCompleted")]
        public async Task<IActionResult> Complete([FromQuery] int orderId)
            => await _svc.MarkCompletedAsync(orderId) ? NoContent() : NotFound();

        [HttpPut("CancelOrder")]
        public async Task<IActionResult> Cancel([FromQuery] int orderId)
            => await _svc.CancelAsync(orderId) ? NoContent() : NotFound();
    }
}
