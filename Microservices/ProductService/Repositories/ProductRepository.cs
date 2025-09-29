using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;
using ProductService.RepositoryContracts;
using static ProductService.Models.Productvariationvalue;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;
        public ProductRepository(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<Product> AddAsync(Product product, IEnumerable<int>? variationValueIds)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            if (variationValueIds is not null)
            {
                foreach (var vid in variationValueIds.Distinct())
                {
                    _db.ProductVariationValues.Add(new ProductVariationValue { ProductId = product.Id, VariationValueId = vid });
                }
                await _db.SaveChangesAsync();
            }
            return await GetByIdAsync(product.Id) ?? product;
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return _db.Products
                .Include(p => p.VariationValues)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _db.Products
                .Include(p => p.VariationValues)
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public Task<List<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return _db.Products
                .Include(p => p.VariationValues)
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public Task<List<Product>> GetByNameAsync(string name)
        {
            var term = name.Trim();
            return _db.Products
                .Include(p => p.VariationValues)
                .AsNoTracking()
                .Where(p => p.Name.Contains(term))
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Product?> UpdateAsync(Product product, IEnumerable<int>? variationValueIds)
        {
            var existing = await _db.Products
                .Include(p => p.VariationValues)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existing is null)
            {
                return null;
            }

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.CategoryId = product.CategoryId;
            existing.Price = product.Price;
            existing.Qty = product.Qty;
            existing.ProductImage = product.ProductImage;
            existing.SKU = product.SKU;
            existing.IsActive = product.IsActive;

            if (variationValueIds is not null)
            {
                var newIds = variationValueIds.Distinct().ToHashSet();
                var currentIds = existing.VariationValues.Select(v => v.VariationValueId).ToHashSet();

                var toAdd = newIds.Except(currentIds);
                var toRemove = currentIds.Except(newIds);

                foreach (var addId in toAdd)
                {
                    _db.ProductVariationValues.Add(new ProductVariationValue { ProductId = existing.Id, VariationValueId = addId });
                }

                if (toRemove.Any())
                {
                    var removeLinks = _db.ProductVariationValues
                        .Where(x => x.ProductId == existing.Id && toRemove.Contains(x.VariationValueId));
                    _db.ProductVariationValues.RemoveRange(removeLinks);
                }
            }

            await _db.SaveChangesAsync();
            return await GetByIdAsync(existing.Id);
        }

        public async Task<bool> SetInactiveAsync(int id)
        {
            var p = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (p is null)
            {
                return false;
            }
            p.IsActive = false;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (p is null)
            {
                return false;
            }
            _db.Products.Remove(p);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
