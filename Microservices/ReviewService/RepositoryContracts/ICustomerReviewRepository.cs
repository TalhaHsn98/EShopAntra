using Microsoft.AspNetCore.Mvc;
using ReviewService.Models;

namespace ReviewService.RepositoryContracts
{
    public interface ICustomerReviewRepository
    {
        Task<List<CustomerReview>> GetAllAsync();
        Task<CustomerReview?> GetByIdAsync(int id);
        Task<List<CustomerReview>> GetByUserAsync(int customerId);
        Task<List<CustomerReview>> GetByProductAsync(int productId);
        Task<List<CustomerReview>> GetByYearAsync(int year);
        Task<CustomerReview> AddAsync(CustomerReview entity);
        Task UpdateAsync(CustomerReview entity);
        Task DeleteAsync(int id);
        Task<bool> ApproveAsync(int id);
        Task<bool> RejectAsync(int id);
    }
}
