using ProductService.DTOs;
using ProductService.RepositoryContracts;
using ProductService.ServiceContracts;

namespace ProductService.Services
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly IProductVariationRepository _repo;
        public ProductVariationService(IProductVariationRepository repo) { _repo = repo; }

        public async Task<ProductVariationDto> SaveAsync(ProductVariationSaveRequest request)
        {
            await _repo.SaveAsync(request.ProductId, request.VariationValueIds ?? new List<int>());
            var ids = await _repo.GetIdsByProductAsync(request.ProductId);
            return new ProductVariationDto(request.ProductId, ids);
        }

        public async Task<ProductVariationDto> GetByProductAsync(int productId)
        {
            var ids = await _repo.GetIdsByProductAsync(productId);
            return new ProductVariationDto(productId, ids);
        }
    }
}
