using Microsoft.EntityFrameworkCore;
using ShippingService.Data;
using ShippingService.Models;
using ShippingService.RepositoryContracts;

namespace ShippingService.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly ShippingDbContext _ctx;

        public ShipperRepository(ShippingDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Shipper>> GetAllAsync()
        {
            return await _ctx.Shippers.AsNoTracking().ToListAsync();
        }

        public async Task<Shipper?> GetByIdAsync(int id)
        {
            return await _ctx.Shippers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Shipper> AddAsync(Shipper entity)
        {
            _ctx.Shippers.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<Shipper?> UpdateAsync(Shipper entity)
        {
            var existing = await _ctx.Shippers.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existing == null)
            {
                return null;
            }

            existing.Name = entity.Name;
            existing.EmailId = entity.EmailId;
            existing.Phone = entity.Phone;
            existing.Contact_Person = entity.Contact_Person;

            await _ctx.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _ctx.Shippers.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return false;
            }

            _ctx.Shippers.Remove(existing);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<List<Shipper>> GetByRegionNameAsync(string regionName)
        {
            return await _ctx.ShipperRegions
                .Where(sr => sr.Active && sr.Region != null && sr.Region.Name == regionName)
                .Select(sr => sr.Shipper!)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
