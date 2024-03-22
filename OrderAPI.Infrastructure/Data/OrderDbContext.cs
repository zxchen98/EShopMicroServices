using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderStatus).HasDefaultValue("Processing");
                entity.Property(e => e.OrderDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasMany(c => c.Items)
                      .WithOne(i => i.ShoppingCart)
                      .HasForeignKey(i => i.ShoppingCartId);
            });

        }
    }
}
