using Microsoft.AspNetCore.Mvc;
using ReviewService.DTOs;

namespace ReviewService.ServiceContracts
{
    public interface ICustomerReviewService
    {
        Task<IEnumerable<CustomerReviewResponseDto>> GetAllAsync();
        Task<CustomerReviewResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<CustomerReviewResponseDto>> GetByUserAsync(int userId);
        Task<IEnumerable<CustomerReviewResponseDto>> GetByProductAsync(int productId);
        Task<IEnumerable<CustomerReviewResponseDto>> GetByYearAsync(int year);
        Task<CustomerReviewResponseDto> CreateAsync(CustomerReviewCreateDto dto);
        Task<bool> UpdateAsync(CustomerReviewUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ApproveAsync(int id);
        Task<bool> RejectAsync(int id);
    }
}
