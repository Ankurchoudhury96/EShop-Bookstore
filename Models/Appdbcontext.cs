using Microsoft.EntityFrameworkCore;

namespace EShop.Models
{
    public class Appdbcontext:DbContext
    {
        public Appdbcontext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Useraddress> Users { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Adminlogin> Adminlogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Cid = 1,
                    CategoryName = "Phones"
                }, new Category
                {
                    Cid=2,
                    CategoryName = "Laptops"
                }
                );
        }
    }
}
