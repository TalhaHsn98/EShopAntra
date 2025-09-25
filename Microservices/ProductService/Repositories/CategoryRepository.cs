using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;
using ProductService.RepositoryContracts;

namespace ProductService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _db;
        public CategoryRepository(ProductDbContext db) { _db = db; }

        public async Task<ProductCategory> AddAsync(ProductCategory entity)
        {
            _db.ProductCategories.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task<ProductCategory?> GetByIdAsync(int id) =>
            _db.ProductCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<ProductCategory>> GetAllAsync() =>
            _db.ProductCategories.AsNoTracking().OrderBy(x => x.Name).ToListAsync();

        public Task<List<ProductCategory>> GetByParentIdAsync(int? parentId) =>
            _db.ProductCategories.AsNoTracking()
                .Where(x => x.ParentCategoryId == parentId)
                .OrderBy(x => x.Name)
                .ToListAsync();

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return false;
            _db.ProductCategories.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
