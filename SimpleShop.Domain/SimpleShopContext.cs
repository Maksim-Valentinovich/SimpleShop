using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain
{
    public class SimpleShopContext : DbContext
    {


        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ProductOrder> Subscriptions { get; set; }

        public DbSet<Order> Orders { get; set; }

        public SimpleShopContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasKey(x => new { x.ProductId, x.CategoryId });


            modelBuilder.Entity<ProductOrder>().HasKey(x => new { x.ProductId, x.OrderId });

        }

    }
}
