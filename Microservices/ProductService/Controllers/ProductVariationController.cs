using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.ServiceContracts;

namespace ProductService.Controllers
{

    [ApiController]
    [Route("api/ProductVariation")]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationService _service;
        public ProductVariationController(IProductVariationService service) { _service = service; }

        [HttpPost("Save")]
        public async Task<ActionResult<ProductVariationDto>> Save([FromBody] ProductVariationSaveRequest request)
        {
            var dto = await _service.SaveAsync(request);
            return Ok(dto);
        }

        [HttpGet("GetProductVariation")]
        public async Task<ActionResult<ProductVariationDto>> GetProductVariation([FromQuery] int productId)
        {
            var dto = await _service.GetByProductAsync(productId);
            return Ok(dto);
        }
    }

}
