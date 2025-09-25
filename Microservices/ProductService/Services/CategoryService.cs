using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.DTOs;
using ProductService.Models;
using ProductService.RepositoryContracts;
using ProductService.ServiceContracts;

namespace ProductService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        private readonly ProductDbContext _db;

        public CategoryService(ICategoryRepository repo, IMapper mapper, ProductDbContext db)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
        }

        public async Task<CategoryDto> SaveAsync(CategoryCreateRequest request)
        {
            var entity = _mapper.Map<ProductCategory>(request);
            entity = await _repo.AddAsync(entity);
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<IReadOnlyList<CategoryDto>> GetAllAsync()
        {
            return await _db.ProductCategories.AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            return e is null ? null : _mapper.Map<CategoryDto>(e);
        }

        public async Task<IReadOnlyList<CategoryDto>> GetByParentIdAsync(int? parentId)
        {
            var list = await _repo.GetByParentIdAsync(parentId);
            return list.Select(_mapper.Map<CategoryDto>).ToList();
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
