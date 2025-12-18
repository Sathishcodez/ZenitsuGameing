using Microsoft.EntityFrameworkCore;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "RPG", DisplayOrder = 3 }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
