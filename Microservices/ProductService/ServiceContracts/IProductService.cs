using ProductService.DTOs;

namespace ProductService.ServiceContracts
{
    public interface IProductService
    {
        Task<ProductDto> SaveAsync(ProductCreateRequest request);
        Task<ProductDto?> GetByIdAsync(int id);
        Task<IReadOnlyList<ProductDto>> GetAllAsync();
        Task<IReadOnlyList<ProductDto>> GetByCategoryIdAsync(int categoryId);
        Task<IReadOnlyList<ProductDto>> GetByNameAsync(string name);
        Task<ProductDto?> UpdateAsync(ProductUpdateRequest request);
        Task<bool> InActiveAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
