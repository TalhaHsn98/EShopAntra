using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.ServiceContracts;

namespace ProductService.Controllers
{

    [ApiController]
    [Route("api/VariationValue")]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueService _service;
        public VariationValueController(IVariationValueService service) { _service = service; }

        [HttpPost("Save")]
        public async Task<ActionResult<VariationValueDto>> Save([FromBody] VariationValueCreateRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var dto = await _service.SaveAsync(request);
            return CreatedAtAction(nameof(GetVariationId), new { variationId = dto.VariationId }, dto);
        }

        [HttpGet("GetVariationId")]
        public async Task<ActionResult<IEnumerable<VariationValueDto>>> GetVariationId([FromQuery] int variationId)
        {
            var items = await _service.GetByVariationIdAsync(variationId);
            return Ok(items);
        }
    }
}
