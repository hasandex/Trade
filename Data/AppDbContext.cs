using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Trade.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruits"},
                new Category { Id = 2, Name = "Fish"},
                new Category { Id = 3, Name = "Juice" },
                new Category { Id = 4, Name = "Meat" }
                );
            base.OnModelCreating(builder);
        }
    }
}
