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

    public class CategoryVariationService : ICategoryVariationService
    {
        private readonly ICategoryVariationRepository _repo;
        private readonly IMapper _mapper;
        private readonly ProductDbContext _db;

        public CategoryVariationService(ICategoryVariationRepository repo, IMapper mapper, ProductDbContext db)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
        }

        public async Task<CategoryVariationDto> SaveAsync(CategoryVariationCreateRequest request)
        {
            var entity = _mapper.Map<CategoryVariation>(request);
            entity = await _repo.AddAsync(entity);
            return _mapper.Map<CategoryVariationDto>(entity);
        }

        public async Task<IReadOnlyList<CategoryVariationDto>> GetAllAsync()
        {
            return await _db.CategoryVariations.AsNoTracking()
                .OrderBy(x => x.VariationName)
                .ProjectTo<CategoryVariationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CategoryVariationDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            return e is null ? null : _mapper.Map<CategoryVariationDto>(e);
        }

        public async Task<IReadOnlyList<CategoryVariationDto>> GetByCategoryIdAsync(int categoryId)
        {
            var list = await _repo.GetByCategoryIdAsync(categoryId);
            return list.Select(_mapper.Map<CategoryVariationDto>).ToList();
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
