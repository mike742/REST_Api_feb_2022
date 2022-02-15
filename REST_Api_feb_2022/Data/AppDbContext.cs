using Microsoft.EntityFrameworkCore;
using REST_Api_feb_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Api_feb_2022.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op) { }

        public DbSet<Product> Products { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderProducts> OrderProducts { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Boiled water", Price = 11.22 }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Name = "Mark's order", Date = DateTime.Now }
                );
            modelBuilder.Entity<OrderProducts>().HasData(
                new OrderProducts { Id = 1, OrderId = 1, ProductId = 1 }
                );
        }
    }
}
