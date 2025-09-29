using AutoMapper;
using ProductService.DTOs;
using ProductService.Models;
using ProductService.RepositoryContracts;
using ProductService.ServiceContracts;

namespace ProductService.Services
{
    public class VariationValueService : IVariationValueService
    {
        private readonly IVariationValueRepository _repo;
        private readonly IMapper _mapper;
        public VariationValueService(IVariationValueRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<VariationValueDto> SaveAsync(VariationValueCreateRequest request)
        {
            var e = _mapper.Map<VariationValue>(request);
            e = await _repo.AddAsync(e);
            return _mapper.Map<VariationValueDto>(e);
        }

        public async Task<IReadOnlyList<VariationValueDto>> GetByVariationIdAsync(int variationId)
        {
            var list = await _repo.GetByVariationIdAsync(variationId);
            return list.Select(_mapper.Map<VariationValueDto>).ToList();
        }
    }
}
