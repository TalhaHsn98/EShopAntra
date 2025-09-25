using ProductService.DTOs;

namespace ProductService.ServiceContracts
{

    public interface ICategoryService
    {
        Task<CategoryDto> SaveAsync(CategoryCreateRequest request);
        Task<IReadOnlyList<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<IReadOnlyList<CategoryDto>> GetByParentIdAsync(int? parentId);
        Task<bool> DeleteAsync(int id);
    }
}
