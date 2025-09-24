using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using OrderService.ServiceContracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _svc;
        public PaymentController(IPaymentService svc) { _svc = svc; }

        [HttpGet("GetPaymentByCustomerId")]
        public async Task<ActionResult<List<PaymentMethodResponse>>> GetByCustomerId([FromQuery] int customerId)
        { return Ok(await _svc.GetMethodsByCustomerAsync(customerId)); }

        [HttpPost("SavePayment")]
        public async Task<ActionResult<int>> SavePayment([FromBody] PaymentMethodRequest request)
        {
            return Ok(await _svc.SaveMethodAsync(request));
        }

        [HttpPut("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentMethodRequest request)
        {
            return Ok(await _svc.SaveMethodAsync(request));
        }

        [HttpDelete("DeletePayment")]
        public async Task<IActionResult> DeletePayment([FromQuery] int id)
        {
            return await _svc.DeleteMethodAsync(id) ? NoContent() : NotFound();
        }
    }
}
