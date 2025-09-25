using ProductService.DTOs;

namespace ProductService.ServiceContracts
{
    public interface ICategoryVariationService
    {
        Task<CategoryVariationDto> SaveAsync(CategoryVariationCreateRequest request);
        Task<IReadOnlyList<CategoryVariationDto>> GetAllAsync();
        Task<CategoryVariationDto?> GetByIdAsync(int id);
        Task<IReadOnlyList<CategoryVariationDto>> GetByCategoryIdAsync(int categoryId);
        Task<bool> DeleteAsync(int id);
    }
}
