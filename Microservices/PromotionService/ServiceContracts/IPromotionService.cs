using PromotionService.DTOs;

namespace PromotionService.ServiceContracts
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionResponse>> GetAllAsync();
        Task<PromotionResponse?> GetByIdAsync(int id);
        Task<int> CreateAsync(PromotionCreateRequest request);
        Task<bool> UpdateAsync(PromotionUpdateRequest request);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PromotionResponse>> GetActiveAsync();
        Task<IEnumerable<PromotionResponse>> GetByProductNameAsync(string name);
    }
}
