using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebStoreWebApi.Models
{
    public class WebStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<StoreUser> StoreUsers { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductAsset> ProductAssets { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public DbSet<ProductPrice> ProductPrices { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Order Table FK
            modelBuilder.Entity<Order>()
                .HasOne(o => o.StoreUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.UserAddress)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductCategory Table FK
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            // OrderLine Table FK
            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Product)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.ProductId);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Order)
                .WithMany(o => o.OrderLines)
                .HasForeignKey(ol => ol.OrderId);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added || entity.State == EntityState.Modified)
                {
                    if (entity.Entity is BaseEntity baseEntity)
                    {
                        baseEntity.LastUpdated = DateTime.Now;
                    }
                    else if (entity.Entity is BaseEntityWithCreateOn baseEntityWithCreateOn)
                    {
                        if (entity.State == EntityState.Added)
                        {
                            baseEntityWithCreateOn.CreateOn = DateTime.Now;
                        }

                        baseEntityWithCreateOn.LastUpdated = DateTime.Now;
                    }
                }
            }
        }
    }
}
