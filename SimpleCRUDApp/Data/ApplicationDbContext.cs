using Microsoft.EntityFrameworkCore;
using SimpleCRUDApp.Models;
namespace SimpleCRUDApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, ItemName="Headphones", Price=300.0m},
                new Item { Id = 2, ItemName = "Computer", Price = 500.0m },
                new Item { Id = 3, ItemName = "Smartphone", Price = 250.5m }
                );
        }
    }
}
