using ProductService.Models;

namespace ProductService.RepositoryContracts
{
    public interface ICategoryVariationRepository
    {
        Task<CategoryVariation> AddAsync(CategoryVariation entity);
        Task<CategoryVariation?> GetByIdAsync(int id);
        Task<List<CategoryVariation>> GetAllAsync();
        Task<List<CategoryVariation>> GetByCategoryIdAsync(int categoryId);
        Task<bool> DeleteAsync(int id);
    }
}
