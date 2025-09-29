using AutoMapper;
using ProductService.DTOs;
using ProductService.Models;
using ProductService.RepositoryContracts;
using ProductService.ServiceContracts;

namespace ProductService.Services
{
    public class ProductsService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> SaveAsync(ProductCreateRequest request)
        {
            var entity = _mapper.Map<Product>(request);
            var saved = await _repository.AddAsync(entity, request.VariationValueIds);
            var dto = _mapper.Map<ProductDto>(saved);
            dto = dto with { VariationValueIds = saved.VariationValues.Select(v => v.VariationValueId).ToList() };
            return dto;
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e is null)
            {
                return null;
            }
            var dto = _mapper.Map<ProductDto>(e);
            dto = dto with { VariationValueIds = e.VariationValues.Select(v => v.VariationValueId).ToList() };
            return dto;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(e =>
            {
                var d = _mapper.Map<ProductDto>(e);
                d = d with { VariationValueIds = e.VariationValues.Select(v => v.VariationValueId).ToList() };
                return d;
            }).ToList();
        }

        public async Task<IReadOnlyList<ProductDto>> GetByCategoryIdAsync(int categoryId)
        {
            var list = await _repository.GetByCategoryIdAsync(categoryId);
            return list.Select(e =>
            {
                var d = _mapper.Map<ProductDto>(e);
                d = d with { VariationValueIds = e.VariationValues.Select(v => v.VariationValueId).ToList() };
                return d;
            }).ToList();
        }

        public async Task<IReadOnlyList<ProductDto>> GetByNameAsync(string name)
        {
            var list = await _repository.GetByNameAsync(name);
            return list.Select(e =>
            {
                var d = _mapper.Map<ProductDto>(e);
                d = d with { VariationValueIds = e.VariationValues.Select(v => v.VariationValueId).ToList() };
                return d;
            }).ToList();
        }

        public async Task<ProductDto?> UpdateAsync(ProductUpdateRequest request)
        {
            var entity = _mapper.Map<Product>(request);
            var saved = await _repository.UpdateAsync(entity, request.VariationValueIds);
            if (saved is null)
            {
                return null;
            }
            var dto = _mapper.Map<ProductDto>(saved);
            dto = dto with { VariationValueIds = saved.VariationValues.Select(v => v.VariationValueId).ToList() };
            return dto;
        }

        public Task<bool> InActiveAsync(int id)
        {
            return _repository.SetInactiveAsync(id);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
