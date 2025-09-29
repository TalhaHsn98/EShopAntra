using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewService.Data;
using ReviewService.Models;
using ReviewService.RepositoryContracts;

namespace ReviewService.Repositories
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        private readonly ReviewDbContext _db;
        public CustomerReviewRepository(ReviewDbContext db) { _db = db; }

        public async Task<List<CustomerReview>> GetAllAsync() =>
            await _db.Customer_Review.AsNoTracking().ToListAsync();

        public async Task<CustomerReview?> GetByIdAsync(int id) =>
            await _db.Customer_Review.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<CustomerReview>> GetByUserAsync(int customerId) =>
            await _db.Customer_Review.AsNoTracking().Where(x => x.Customer_Id == customerId).ToListAsync();

        public async Task<List<CustomerReview>> GetByProductAsync(int productId) =>
            await _db.Customer_Review.AsNoTracking().Where(x => x.Product_Id == productId).ToListAsync();

        public async Task<List<CustomerReview>> GetByYearAsync(int year) =>
            await _db.Customer_Review.AsNoTracking().Where(x => x.Review_Date.Year == year).ToListAsync();

        public async Task<CustomerReview> AddAsync(CustomerReview entity)
        {
            _db.Customer_Review.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(CustomerReview entity)
        {
            _db.Customer_Review.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _db.Customer_Review.FirstOrDefaultAsync(x => x.Id == id);
            if (e != null)
            {
                _db.Customer_Review.Remove(e);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ApproveAsync(int id)
        {
            var e = await _db.Customer_Review.FirstOrDefaultAsync(x => x.Id == id);
            if (e == null) return false;
            e.Status = ReviewStatus.Approved;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectAsync(int id)
        {
            var e = await _db.Customer_Review.FirstOrDefaultAsync(x => x.Id == id);
            if (e == null) return false;
            e.Status = ReviewStatus.Rejected;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
