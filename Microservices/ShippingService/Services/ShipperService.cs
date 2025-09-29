using AutoMapper;
using ShippingService.DTOs;
using ShippingService.Models;
using ShippingService.RepositoryContracts;
using ShippingService.ServiceContracts;

namespace ShippingService.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _repo;
        private readonly IMapper _mapper;

        public ShipperService(IShipperRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ShipperResponseModel>>(data);
        }

        public async Task<ShipperResponseModel?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<ShipperResponseModel>(entity);
        }

        public async Task<ShipperResponseModel> CreateAsync(ShipperRequestModel model)
        {
            var entity = _mapper.Map<Shipper>(model);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<ShipperResponseModel>(created);
        }

        public async Task<ShipperResponseModel?> UpdateAsync(ShipperRequestModel model)
        {
            var entity = _mapper.Map<Shipper>(model);
            var updated = await _repo.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return _mapper.Map<ShipperResponseModel>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetByRegionAsync(string region)
        {
            var data = await _repo.GetByRegionNameAsync(region);
            return _mapper.Map<IEnumerable<ShipperResponseModel>>(data);
        }
    }
}
