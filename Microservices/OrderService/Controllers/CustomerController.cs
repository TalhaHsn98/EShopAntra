using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using OrderService.ServiceContracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomerAddressByUserId")]
        public async Task<ActionResult<List<CustomerAddressResponse>>> GetCustomerAddressByUserId([FromQuery] int userId)
        {
            var list = await _customerService.GetCustomerAddressByUserIdAsync(userId);
            return Ok(list);
        }

        [HttpPost("SaveCustomerAddress")]
        public async Task<ActionResult<int>> SaveCustomerAddress([FromBody] CustomerAddressSaveRequest request)
        {
            var id = await _customerService.SaveCustomerAddressAsync(request);
            return Ok(id);
        }
    }
}
