using ProductService.Models;

namespace ProductService.RepositoryContracts
{

    public interface ICategoryRepository
    {
        Task<ProductCategory> AddAsync(ProductCategory entity);
        Task<ProductCategory?> GetByIdAsync(int id);
        Task<List<ProductCategory>> GetAllAsync();
        Task<List<ProductCategory>> GetByParentIdAsync(int? parentId);
        Task<bool> DeleteAsync(int id);
    }
}
