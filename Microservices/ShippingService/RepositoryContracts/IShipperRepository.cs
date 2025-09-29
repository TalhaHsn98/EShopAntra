using ShippingService.Models;

namespace ShippingService.RepositoryContracts
{
    public interface IShipperRepository
    {
        Task<List<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        Task<Shipper> AddAsync(Shipper entity);
        Task<Shipper?> UpdateAsync(Shipper entity);
        Task<bool> DeleteAsync(int id);
        Task<List<Shipper>> GetByRegionNameAsync(string regionName);
    }
}
