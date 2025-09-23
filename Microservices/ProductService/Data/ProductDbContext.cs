namespace ProductService.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductService.Models;
    using static ProductService.Models.Productvariationvalue;

    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<CategoryVariation> CategoryVariations => Set<CategoryVariation>();
        public DbSet<VariationValue> VariationValues => Set<VariationValue>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductVariationValue> ProductVariationValues => Set<ProductVariationValue>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.ParentCategory)
                .WithMany(pc => pc.Children)
                .HasForeignKey(pc => pc.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CategoryVariation>()
                .HasOne(cv => cv.Category)
                .WithMany(c => c.Variations)
                .HasForeignKey(cv => cv.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VariationValue>()
                .HasOne(vv => vv.Variation)
                .WithMany(v => v.Values)
                .HasForeignKey(vv => vv.VariationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductVariationValue>()
                .HasKey(pvv => new { pvv.ProductId, pvv.VariationValueId });

            modelBuilder.Entity<ProductVariationValue>()
                .HasOne(pvv => pvv.Product)
                .WithMany(p => p.VariationValues)
                .HasForeignKey(pvv => pvv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductVariationValue>()
                .HasOne(pvv => pvv.VariationValue)
                .WithMany(vv => vv.ProductLinks)
                .HasForeignKey(pvv => pvv.VariationValueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique();
        }
    }

}
