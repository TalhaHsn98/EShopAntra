using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.RepositoryContracts;
using static ProductService.Models.Productvariationvalue;

namespace ProductService.Repositories
{
    public class ProductVariationRepository : IProductVariationRepository
    {
        private readonly ProductDbContext _db;
        public ProductVariationRepository(ProductDbContext db) { _db = db; }

        public async Task<List<int>> GetIdsByProductAsync(int productId)
        {
            return await _db.ProductVariationValues
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .Select(x => x.VariationValueId)
                .ToListAsync();
        }

        public async Task SaveAsync(int productId, IEnumerable<int> variationValueIds)
        {
            var newIds = variationValueIds.Distinct().ToHashSet();
            var currentIds = await _db.ProductVariationValues
                .Where(x => x.ProductId == productId)
                .Select(x => x.VariationValueId)
                .ToListAsync();
            var currentSet = currentIds.ToHashSet();

            var toAdd = newIds.Except(currentSet);
            var toRemove = currentSet.Except(newIds);

            foreach (var id in toAdd)
                _db.ProductVariationValues.Add(new ProductVariationValue { ProductId = productId, VariationValueId = id });

            if (toRemove.Any())
            {
                var links = _db.ProductVariationValues
                    .Where(x => x.ProductId == productId && toRemove.Contains(x.VariationValueId));
                _db.ProductVariationValues.RemoveRange(links);
            }

            await _db.SaveChangesAsync();
        }
    }
}
