using ProductService.Models;

namespace ProductService.RepositoryContracts
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product, IEnumerable<int>? variationValueIds);
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetByCategoryIdAsync(int categoryId);
        Task<List<Product>> GetByNameAsync(string name);
        Task<Product?> UpdateAsync(Product product, IEnumerable<int>? variationValueIds);
        Task<bool> SetInactiveAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
