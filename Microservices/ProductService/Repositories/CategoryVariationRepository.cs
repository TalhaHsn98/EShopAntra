using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;
using ProductService.RepositoryContracts;

namespace ProductService.Repositories
{

    public class CategoryVariationRepository : ICategoryVariationRepository
    {
        private readonly ProductDbContext _db;
        public CategoryVariationRepository(ProductDbContext db) { _db = db; }

        public async Task<CategoryVariation> AddAsync(CategoryVariation entity)
        {
            _db.CategoryVariations.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task<CategoryVariation?> GetByIdAsync(int id) =>
            _db.CategoryVariations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<CategoryVariation>> GetAllAsync() =>
            _db.CategoryVariations.AsNoTracking().OrderBy(x => x.VariationName).ToListAsync();

        public Task<List<CategoryVariation>> GetByCategoryIdAsync(int categoryId) =>
            _db.CategoryVariations.AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .OrderBy(x => x.VariationName)
                .ToListAsync();

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.CategoryVariations.FirstOrDefaultAsync(x => x.Id == id);
            if (e is null) return false;
            _db.CategoryVariations.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
