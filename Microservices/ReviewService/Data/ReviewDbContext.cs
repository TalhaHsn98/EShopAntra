using Microsoft.EntityFrameworkCore;
using ReviewService.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ReviewService.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
            : base(options) { }

        public DbSet<CustomerReview> Customer_Review { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerReview>(e =>
            {
                e.Property(p => p.Customer_Name).HasMaxLength(200).IsRequired();
                e.Property(p => p.Product_Name).HasMaxLength(200).IsRequired();
                e.Property(p => p.Comment).HasMaxLength(2000);
                e.Property(p => p.Rating_value).HasDefaultValue((byte)5);
                e.Property(p => p.Review_Date).HasColumnType("datetime2");
                e.Property(p => p.Order_Date).HasColumnType("datetime2");
                e.Property(p => p.Status).HasConversion<int>().HasDefaultValue(ReviewStatus.Pending);

            });
        }
    }
}
