using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;
using ProductService.RepositoryContracts;

namespace ProductService.Repositories
{
    public class VariationValueRepository : IVariationValueRepository
    {
        private readonly ProductDbContext _db;
        public VariationValueRepository(ProductDbContext db) { _db = db; }

        public async Task<VariationValue> AddAsync(VariationValue value)
        {
            _db.VariationValues.Add(value);
            await _db.SaveChangesAsync();
            return value;
        }

        public Task<List<VariationValue>> GetByVariationIdAsync(int variationId)
        {
            return _db.VariationValues.AsNoTracking()
                .Where(v => v.VariationId == variationId)
                .OrderBy(v => v.Value)
                .ToListAsync();
        }
    }
}
