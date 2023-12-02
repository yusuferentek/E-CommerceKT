using E_Commerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data
{
    public class E_CommerceDbContext : DbContext
    {
        public E_CommerceDbContext (DbContextOptions<E_CommerceDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
