using ProductService.DTOs;

namespace ProductService.ServiceContracts
{
    public interface IVariationValueService
    {
        Task<VariationValueDto> SaveAsync(VariationValueCreateRequest request);
        Task<IReadOnlyList<VariationValueDto>> GetByVariationIdAsync(int variationId);
    }
}
