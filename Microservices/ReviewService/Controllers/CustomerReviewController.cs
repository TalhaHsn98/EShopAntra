using Microsoft.AspNetCore.Mvc;
using ReviewService.DTOs;
using ReviewService.ServiceContracts;

namespace ReviewService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerReviewService _service;
        public CustomerReviewController(ICustomerReviewService service) { _service = service; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReviewResponseDto>>> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerReviewResponseDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("user/{userId:int}")]
        public async Task<ActionResult<IEnumerable<CustomerReviewResponseDto>>> GetByUser(int userId)
        {
            var data = await _service.GetByUserAsync(userId);
            return Ok(data);
        }

        [HttpGet("product/{productId:int}")]
        public async Task<ActionResult<IEnumerable<CustomerReviewResponseDto>>> GetByProduct(int productId)
        {
            var data = await _service.GetByProductAsync(productId);
            return Ok(data);
        }

        [HttpGet("year/{year:int}")]
        public async Task<ActionResult<IEnumerable<CustomerReviewResponseDto>>> GetByYear(int year)
        {
            var data = await _service.GetByYearAsync(year);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerReviewResponseDto>> Create([FromBody] CustomerReviewCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.id }, created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerReviewUpdateDto dto)
        {
            var ok = await _service.UpdateAsync(dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("delete-{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpPut("approve/{id:int}")]
        public async Task<IActionResult> Approve(int id)
        {
            var ok = await _service.ApproveAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpPut("reject/{id:int}")]
        public async Task<IActionResult> Reject(int id)
        {
            var ok = await _service.RejectAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
