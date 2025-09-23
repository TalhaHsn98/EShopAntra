using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<UserAddress> UserAddresses => Set<UserAddress>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<ShoppingCartItem> ShoppingCartItems => Set<ShoppingCartItem>();
        public DbSet<PaymentType> PaymentTypes => Set<PaymentType>();
        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.OrderDate).HasColumnName("Order_Date");
                e.Property(p => p.CustomerId).HasColumnName("CustomerId");
                e.Property(p => p.CustomerName).HasColumnName("CustomerName");
                e.Property(p => p.PaymentMethodId).HasColumnName("PaymentMethodId");
                e.Property(p => p.PaymentName).HasColumnName("PaymentName");
                e.Property(p => p.ShippingMethod).HasColumnName("ShippingMethod");
                e.Property(p => p.ShippingAddress).HasColumnName("ShippingAddress");
                e.Property(p => p.BillAmount).HasColumnName("BillAmount").HasColumnType("decimal(18,2)");
                e.Property(p => p.OrderStatus).HasColumnName("Order_Status");
                e.HasOne(p => p.PaymentMethod)
                     .WithMany(pm => pm.Orders)
                     .HasForeignKey(p => p.PaymentMethodId)
                     .OnDelete(DeleteBehavior.SetNull);
                e.HasMany(p => p.Details)
                     .WithOne(d => d.Order)
                     .HasForeignKey(d => d.OrderId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            model.Entity<OrderDetail>(e =>
            {
                e.ToTable("Order_Details");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.OrderId).HasColumnName("Order_Id");
                e.Property(p => p.ProductId).HasColumnName("Product_Id");
                e.Property(p => p.ProductName).HasColumnName("Product_name");
                e.Property(p => p.Qty).HasColumnName("Qty");
                e.Property(p => p.Price).HasColumnName("Price").HasColumnType("decimal(18,2)");
                e.Property(p => p.Discount).HasColumnName("Discount").HasColumnType("decimal(18,2)");
            });

            model.Entity<Customer>(e =>
            {
                e.ToTable("Customer");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.FirstName).HasColumnName("FirstName");
                e.Property(p => p.LastName).HasColumnName("LastName");
                e.Property(p => p.Gender).HasColumnName("Gender");
                e.Property(p => p.Phone).HasColumnName("Phone");
                e.Property(p => p.Profile_PIC).HasColumnName("Profile_PIC");
                e.Property(p => p.UserId).HasColumnName("UserId");
                e.HasMany(c => c.UserAddresses)
                    .WithOne(ua => ua.Customer)
                    .HasForeignKey(ua => ua.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasMany(c => c.PaymentMethods)
                    .WithOne(pm => pm.Customer)
                    .HasForeignKey(pm => pm.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasMany(c => c.Carts)
                    .WithOne(sc => sc.Customer)
                    .HasForeignKey(sc => sc.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasMany(c => c.Orders)
                    .WithOne()
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            model.Entity<UserAddress>(e =>
            {
                e.ToTable("User_Address");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.CustomerId).HasColumnName("Customer_Id");
                e.Property(p => p.AddressId).HasColumnName("Address_Id");
                e.Property(p => p.IsDefaultAddress).HasColumnName("IsDefaultAddress");
                e.HasOne(p => p.Address)
                    .WithMany(a => a.UserAddresses)
                    .HasForeignKey(p => p.AddressId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            model.Entity<Address>(e =>
            {
                e.ToTable("Address");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.Street1).HasColumnName("Street1");
                e.Property(p => p.Street2).HasColumnName("Street2");
                e.Property(p => p.City).HasColumnName("City");
                e.Property(p => p.Zipcode).HasColumnName("Zipcode");
                e.Property(p => p.State).HasColumnName("State");
                e.Property(p => p.Country).HasColumnName("Country");
            });

            model.Entity<ShoppingCart>(e =>
            {
                e.ToTable("ShoppingCart");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.CustomerId).HasColumnName("CustomerId");
                e.Property(p => p.CustomerName).HasColumnName("CustomerName");
                e.HasMany(sc => sc.Items)
                    .WithOne(i => i.Cart)
                    .HasForeignKey(i => i.CartId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            model.Entity<ShoppingCartItem>(e =>
            {
                e.ToTable("Shopping_Cart_Item");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.CartId).HasColumnName("Cart_Id");
                e.Property(p => p.ProductId).HasColumnName("ProductId");
                e.Property(p => p.ProductName).HasColumnName("ProductName");
                e.Property(p => p.Qty).HasColumnName("Qty");
                e.Property(p => p.Price).HasColumnName("Price").HasColumnType("decimal(18,2)");
            });

            model.Entity<PaymentType>(e =>
            {
                e.ToTable("Payment_Type");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.Name).HasColumnName("Name");
                e.HasMany(pt => pt.Methods)
                    .WithOne(pm => pm.PaymentType)
                    .HasForeignKey(pm => pm.PaymentTypeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            model.Entity<PaymentMethod>(e =>
            {
                e.ToTable("Payment_Method");
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.PaymentTypeId).HasColumnName("Payment_Type_Id");
                e.Property(p => p.Provider).HasColumnName("Provider");
                e.Property(p => p.AccountNumber).HasColumnName("AccountNumber");
                e.Property(p => p.Expiry).HasColumnName("Expiry");
                e.Property(p => p.IsDefault).HasColumnName("IsDefault");
                e.Property(p => p.CustomerId).HasColumnName("CustomerId");
            });
        }
    }
}
