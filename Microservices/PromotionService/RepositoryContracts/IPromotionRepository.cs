using Microsoft.AspNetCore.Mvc;
using PromotionService.Models;

namespace PromotionService.RepositoryContracts
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> GetAllAsync();
        Task<Promotion?> GetByIdAsync(int id);
        Task<Promotion> AddAsync(Promotion promotion);
        Task<bool> UpdateAsync(Promotion promotion);
        Task<bool> DeleteAsync(int id);
        Task<List<Promotion>> GetActiveAsync(DateTime nowUtc);
        Task<List<Promotion>> GetByProductNameAsync(string name);
    }
}
