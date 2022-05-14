using Microsoft.EntityFrameworkCore;
using Order.Entity.Model;

namespace Order.DataAccess
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Seed();
        }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<OrderDetailEntity> OrderDetails { get; set; }
    }
}
