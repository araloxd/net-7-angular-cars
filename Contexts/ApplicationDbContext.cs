using Microsoft.EntityFrameworkCore;
using net_7_angular_cars.Models;

namespace net_7_angular_cars.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles
        {
            get;
            set;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "Memory");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
              .HasMany(u => u.Vehicles)
              .WithOne(v => v.User)
              .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Vehicle>()
              .HasOne(v => v.Category)
              .WithMany()
              .HasForeignKey(v => v.CategoryId);

            modelBuilder.Entity<Vehicle>()
              .HasOne(v => v.Manufacturer)
              .WithMany()
              .HasForeignKey(v => v.ManufacturerId);

            modelBuilder.Entity<Category>()
              .Property(c => c.Icon)
              .HasMaxLength(255);

            modelBuilder.Entity<Manufacturer>()
               .Property(m => m.Id)
               .UseIdentityColumn();

            modelBuilder.Entity<Manufacturer>().HasData(
              new Manufacturer
              {
                  Id = 1,
                  Name = "Mazda"
              },
              new Manufacturer
              {
                  Id = 2,
                  Name = "Mercedes"
              },
              new Manufacturer
              {
                  Id = 3,
                  Name = "Honda"
              },
              new Manufacturer
              {
                  Id = 4,
                  Name = "Ferrari"
              },
              new Manufacturer
              {
                  Id = 5,
                  Name = "Toyota"
              }
            );

            modelBuilder.Entity<Category>().HasData(
              new Category
              {
                  Id = 1,
                  Name = "Light",
                  MinWeight = 1,
                  MaxWeight = 500,
                  Icon = "https://m.media-amazon.com/images/I/71q9uT0joGL._UC256,256_CACC,256,256_.jpg"
              },
              new Category
              {
                  Id = 2,
                  Name = "Medium",
                  MinWeight = 501,
                  MaxWeight = 2500,
                  Icon = "https://images.nettiauto.com/live/2022/07/06/073bb2be616d6719-medium.jpg"
              },
              new Category
              {
                  Id = 3,
                  Name = "Heavy",
                  MinWeight = 2501,
                  MaxWeight = 5000,
                  Icon = "https://public.blenderkit.com/thumbnails/assets/80dfbcccf6a34085961de20a93f8050c/files/thumbnail_e8106d31-6d78-440f-9ea3-5436d7e0ac91.jpg.256x256_q85_crop-%2C.jpg"
              }
            );

            modelBuilder.Entity<Vehicle>().HasData(
              new Vehicle
              {
                  Id = 1,
                  OwnerName = "John Smith",
                  YearOfManufacture = 2019,
                  Weight = 400,
                  ManufacturerId = 1,
                  CategoryId = 1,
              },
              new Vehicle
              {
                  Id = 2,
                  OwnerName = "Jane Turei",
                  Weight = 900,
                  YearOfManufacture = 2015,
                  ManufacturerId = 2,
                  CategoryId = 2,
              }
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}