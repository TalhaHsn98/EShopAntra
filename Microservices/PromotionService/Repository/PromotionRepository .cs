using Microsoft.EntityFrameworkCore;
using PromotionService.Data;
using PromotionService.Models;
using PromotionService.RepositoryContracts;

public class PromotionRepository : IPromotionRepository
{
    private readonly PromotionDbContext context;

    public PromotionRepository(PromotionDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Promotion>> GetAllAsync()
    {
        var list = await context.Promotions
            .Include(p => p.PromotionDetails)
            .AsNoTracking()
            .ToListAsync();
        return list;
    }

    public async Task<Promotion?> GetByIdAsync(int id)
    {
        var entity = await context.Promotions
            .Include(p => p.PromotionDetails)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        return entity;
    }

    public async Task<Promotion> AddAsync(Promotion promotion)
    {
        await context.Promotions.AddAsync(promotion);
        await context.SaveChangesAsync();
        return promotion;
    }

    public async Task<bool> UpdateAsync(Promotion promotion)
    {
        var existing = await context.Promotions
            .Include(p => p.PromotionDetails)
            .FirstOrDefaultAsync(p => p.Id == promotion.Id);

        if (existing == null) return false;

        existing.Name = promotion.Name;
        existing.Description = promotion.Description;
        existing.Discount = promotion.Discount;
        existing.StartDate = promotion.StartDate;
        existing.EndDate = promotion.EndDate;

        context.PromotionDetails.RemoveRange(existing.PromotionDetails);
        existing.PromotionDetails = promotion.PromotionDetails;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await context.Promotions.FindAsync(id);
        if (existing == null) return false;
        context.Promotions.Remove(existing);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Promotion>> GetActiveAsync(DateTime nowUtc)
    {
        var list = await context.Promotions
            .Include(p => p.PromotionDetails)
            .Where(p => p.StartDate <= nowUtc && (p.EndDate == null || p.EndDate >= nowUtc))
            .AsNoTracking()
            .ToListAsync();
        return list;
    }

    public async Task<List<Promotion>> GetByProductNameAsync(string name)
    {
        var list = await context.Promotions
            .Include(p => p.PromotionDetails)
            .Where(p => p.PromotionDetails.Any(d => d.ProductCategoryName.Contains(name)))
            .AsNoTracking()
            .ToListAsync();
        return list;
    }
}