using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.ServiceContracts;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/CatagoryVariation")]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationService _service;
        public CategoryVariationController(ICategoryVariationService service) { _service = service; }

        [HttpPost("Save")]
        public async Task<ActionResult<CategoryVariationDto>> Save([FromBody] CategoryVariationCreateRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var dto = await _service.SaveAsync(request);
            return CreatedAtAction(nameof(GetCategoryVariationById), new { id = dto.Id }, dto);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryVariationDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("GetCategoryVariationById")]
        public async Task<ActionResult<CategoryVariationDto>> GetCategoryVariationById([FromQuery] int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto is null) return NotFound();
            return Ok(dto);
        }

        [HttpGet("GetCategoryVariationByCategoryId")]
        public async Task<ActionResult<IEnumerable<CategoryVariationDto>>> GetCategoryVariationByCategoryId([FromQuery] int categoryId)
        {
            var items = await _service.GetByCategoryIdAsync(categoryId);
            return Ok(items);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
