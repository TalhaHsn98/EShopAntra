using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewService.DTOs;
using ReviewService.Models;
using ReviewService.RepositoryContracts;
using ReviewService.ServiceContracts;

namespace ReviewService.Services
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly ICustomerReviewRepository _repo;
        private readonly IMapper _mapper;
        public CustomerReviewService(ICustomerReviewRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerReviewResponseDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerReviewResponseDto>>(list);
        }

        public async Task<CustomerReviewResponseDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            return e == null ? null : _mapper.Map<CustomerReviewResponseDto>(e);
        }

        public async Task<IEnumerable<CustomerReviewResponseDto>> GetByUserAsync(int userId)
        {
            var list = await _repo.GetByUserAsync(userId);
            return _mapper.Map<IEnumerable<CustomerReviewResponseDto>>(list);
        }

        public async Task<IEnumerable<CustomerReviewResponseDto>> GetByProductAsync(int productId)
        {
            var list = await _repo.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<CustomerReviewResponseDto>>(list);
        }

        public async Task<IEnumerable<CustomerReviewResponseDto>> GetByYearAsync(int year)
        {
            var list = await _repo.GetByYearAsync(year);
            return _mapper.Map<IEnumerable<CustomerReviewResponseDto>>(list);
        }

        public async Task<CustomerReviewResponseDto> CreateAsync(CustomerReviewCreateDto dto)
        {
            var entity = _mapper.Map<CustomerReview>(dto);
            if (entity.Review_Date == default) entity.Review_Date = DateTime.UtcNow;
            var saved = await _repo.AddAsync(entity);
            return _mapper.Map<CustomerReviewResponseDto>(saved);
        }

        public async Task<bool> UpdateAsync(CustomerReviewUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(dto.id);
            if (existing == null) return false;
            if (dto.ratingValue.HasValue) existing.Rating_value = dto.ratingValue.Value;
            if (dto.comment != null) existing.Comment = dto.comment;
            if (dto.reviewDate.HasValue) existing.Review_Date = dto.reviewDate.Value;
            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }

        public Task<bool> ApproveAsync(int id) => _repo.ApproveAsync(id);
        public Task<bool> RejectAsync(int id) => _repo.RejectAsync(id);
    }
}
