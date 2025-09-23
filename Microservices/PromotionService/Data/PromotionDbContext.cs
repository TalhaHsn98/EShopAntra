using Microsoft.EntityFrameworkCore;
using PromotionService.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PromotionService.Data
{

    public class PromotionDbContext : DbContext
    {
        public PromotionDbContext(DbContextOptions<PromotionDbContext> options)
            : base(options) { }

        public DbSet<Promotion> Promotions => Set<Promotion>();
        public DbSet<PromotionDetail> PromotionDetails => Set<PromotionDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Promotion
            modelBuilder.Entity<Promotion>(b =>
            {
                b.ToTable("Promotions");
                b.Property(p => p.Name).HasMaxLength(128).IsRequired();
                b.Property(p => p.Description).HasMaxLength(1024);
                b.Property(p => p.Discount).HasColumnType("decimal(5,2)");
                b.Property(p => p.StartDate).IsRequired();

                // 1 → many
                b.HasMany(p => p.PromotionDetails)
                 .WithOne(d => d.Promotion!)
                 .HasForeignKey(d => d.PromotionId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PromotionDetail>(b =>
            {
                b.ToTable("PromotionDetails");
                b.Property(d => d.ProductCategoryName).HasMaxLength(128).IsRequired();

                b.HasIndex(d => new { d.PromotionId, d.ProductCategoryId })
                 .IsUnique();
            });
        }
    }
}
