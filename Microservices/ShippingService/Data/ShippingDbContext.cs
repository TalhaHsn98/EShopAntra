using Microsoft.EntityFrameworkCore;
using ShippingService.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShippingService.Data
{
    public class ShippingDbContext : DbContext
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options) : base(options) { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShipperRegion> ShipperRegions { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipperRegion>()
                .HasKey(sr => new { sr.RegionId, sr.ShipperId });

            modelBuilder.Entity<ShipperRegion>()
                .HasOne(sr => sr.Region)
                .WithMany(r => r.ShipperRegions)
                .HasForeignKey(sr => sr.RegionId);

            modelBuilder.Entity<ShipperRegion>()
                .HasOne(sr => sr.Shipper)
                .WithMany(s => s.ShipperRegions)
                .HasForeignKey(sr => sr.ShipperId);

            modelBuilder.Entity<ShippingDetail>()
                .HasOne(sd => sd.Shipper)
                .WithMany(s => s.ShippingDetails)
                .HasForeignKey(sd => sd.Shipper_Id);
        }
    }
}
