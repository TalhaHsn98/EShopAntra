using Microsoft.AspNetCore.Mvc;
using PromotionService.DTOs;
using PromotionService.ServiceContracts;

namespace PromotionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService service;

        public PromotionController(IPromotionService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionResponse>>> GetAll()
        {
            var items = await service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PromotionResponse>> GetById(int id)
        {
            var item = await service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PromotionCreateRequest request)
        {
            var id = await service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PromotionUpdateRequest request)
        {
            var ok = await service.UpdateAsync(request);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("delete-{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpGet("promotionByProductName")]
        public async Task<ActionResult<IEnumerable<PromotionResponse>>> GetByProductName([FromQuery] string name)
        {
            var items = await service.GetByProductNameAsync(name);
            return Ok(items);
        }

        [HttpGet("activePromotions")]
        public async Task<ActionResult<IEnumerable<PromotionResponse>>> GetActive()
        {
            var items = await service.GetActiveAsync();
            return Ok(items);
        }
    }
}
