using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.DataAcess.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Applicationusers> Applicationusers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "RPG", DisplayOrder = 3 }
            );
            modelBuilder.Entity<Company>().HasData(
                new Company {
                    CompanyId=1,Name="Accenture",
                    Address="BDC7",
                    City ="Banglore",
                    State="Karnataka",
                    PostalCode=560066,
                    PhoneNumber=7776854356 
                },
                new Company
                {
                    CompanyId = 2,
                    Name = "Infosys",
                    Address = "Inf9",
                    City = "Chennai",
                    State = "TamilNadu",
                    PostalCode = 600018,
                    PhoneNumber = 1790564378
                },
                new Company
                {
                    CompanyId = 3,
                    Name = "IBM",
                    Address = "IBM87",
                    City = "Hyderbad",
                    State = "Andhra pradesh",
                    PostalCode = 457865,
                    PhoneNumber = 7776854556
                }
            );




            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Elden Ring",
                    Description = "An open-world action RPG set in the Lands Between.",
                    Creator = "FromSoftware",
                    Price = 59.99,
                    Price50 = 54.99,
                    Price100 = 49.99,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "DOOM Eternal",
                    Description = "Fast-paced first-person shooter with intense combat.",
                    Creator = "id Software",
                    Price = 49.99,
                    Price50 = 44.99,
                    Price100 = 39.99,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "The Legend of Zelda: Breath of the Wild",
                    Description = "An open-world adventure in the kingdom of Hyrule.",
                    Creator = "Nintendo",
                    Price = 69.99,
                    Price50 = 64.99,
                    Price100 = 59.99,
                    CategoryId = 2,
                    ImageUrl = ""
                }
            );
            base.OnModelCreating(modelBuilder);
        }



    }
}
