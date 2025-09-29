using ProductService.Models;

namespace ProductService.RepositoryContracts
{
    public interface IVariationValueRepository
    {
        Task<VariationValue> AddAsync(VariationValue value);
        Task<List<VariationValue>> GetByVariationIdAsync(int variationId);
    }
}
