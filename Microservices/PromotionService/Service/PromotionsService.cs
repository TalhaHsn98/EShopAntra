using AutoMapper;
using PromotionService.DTOs;
using PromotionService.Models;
using PromotionService.RepositoryContracts;
using PromotionService.ServiceContracts;

namespace PromotionService.Service
{
    public class PromotionsService : IPromotionService
    {
        private readonly IPromotionRepository repository;
        private readonly IMapper mapper;

        public PromotionsService(IPromotionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PromotionResponse>> GetAllAsync()
        {
            var list = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<PromotionResponse>>(list);
        }

        public async Task<PromotionResponse?> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity == null) return null;
            return mapper.Map<PromotionResponse>(entity);
        }

        public async Task<int> CreateAsync(PromotionCreateRequest request)
        {
            var entity = mapper.Map<Promotion>(request);
            var created = await repository.AddAsync(entity);
            return created.Id;
        }

        public async Task<bool> UpdateAsync(PromotionUpdateRequest request)
        {
            var entity = mapper.Map<Promotion>(request);
            var updated = await repository.UpdateAsync(entity);
            return updated;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ok = await repository.DeleteAsync(id);
            return ok;
        }

        public async Task<IEnumerable<PromotionResponse>> GetActiveAsync()
        {
            var list = await repository.GetActiveAsync(DateTime.UtcNow);
            return mapper.Map<IEnumerable<PromotionResponse>>(list);
        }

        public async Task<IEnumerable<PromotionResponse>> GetByProductNameAsync(string name)
        {
            var list = await repository.GetByProductNameAsync(name);
            return mapper.Map<IEnumerable<PromotionResponse>>(list);
        }
    }
}
