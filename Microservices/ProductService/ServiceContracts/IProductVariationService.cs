using ProductService.DTOs;

namespace ProductService.ServiceContracts
{
    public interface IProductVariationService
    {
        Task<ProductVariationDto> SaveAsync(ProductVariationSaveRequest request);
        Task<ProductVariationDto> GetByProductAsync(int productId);
    }
}
