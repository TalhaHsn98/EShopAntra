using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.ServiceContracts;

namespace ProductService.Controllers
{
    [ApiController]
[Route("api/Catagory")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoryController(ICategoryService service) { _service = service; }

    [HttpPost("SaveCategory")]
    public async Task<ActionResult<CategoryDto>> SaveCategory([FromBody] CategoryCreateRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var dto = await _service.SaveAsync(request);
        return CreatedAtAction(nameof(GetCategoryById), new { id = dto.Id }, dto);
    }

    [HttpGet("GetAllCategory")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategory()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("GetCategoryById")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById([FromQuery] int id)
    {
        var dto = await _service.GetByIdAsync(id);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    [HttpGet("GetCategoryByParentCategoryId")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoryByParentCategoryId([FromQuery] int? parentCategoryId)
    {
        var items = await _service.GetByParentIdAsync(parentCategoryId);
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
