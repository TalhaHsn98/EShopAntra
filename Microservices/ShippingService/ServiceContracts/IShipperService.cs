using ShippingService.DTOs;

namespace ShippingService.ServiceContracts
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperResponseModel>> GetAllAsync();
        Task<ShipperResponseModel?> GetByIdAsync(int id);
        Task<ShipperResponseModel> CreateAsync(ShipperRequestModel model);
        Task<ShipperResponseModel?> UpdateAsync(ShipperRequestModel model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ShipperResponseModel>> GetByRegionAsync(string region);
    }
}
