using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.ServiceContracts;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetListProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetListProducts()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductById([FromQuery] int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto is null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost("Save")]
        public async Task<ActionResult<ProductDto>> Save([FromBody] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var dto = await _service.SaveAsync(request);
            return CreatedAtAction(nameof(GetProductById), new { id = dto.Id }, dto);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var dto = await _service.UpdateAsync(request);
            if (dto is null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPut("InActive")]
        public async Task<IActionResult> InActive([FromQuery] int id)
        {
            var ok = await _service.InActiveAsync(id);
            if (!ok)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("GetProductByCategoryId")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByCategoryId([FromQuery] int categoryId)
        {
            var items = await _service.GetByCategoryIdAsync(categoryId);
            return Ok(items);
        }

        [HttpGet("GetProductByName")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByName([FromQuery] string name)
        {
            var items = await _service.GetByNameAsync(name);
            return Ok(items);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
