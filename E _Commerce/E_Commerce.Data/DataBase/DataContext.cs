using E__Commerce.Models;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E__Commerce.DataBase
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions options) : base (options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet <Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
