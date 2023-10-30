using CarRental.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Data
{
    //ApplicationDbContext, which serves as the database context class for your application.
    //IdentityDbContext is a class provided by ASP.NET Identity, and it's used to interact with the database for
    //user authentication and authorization purposes.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //it represents a collection of ApplicationUser entities. ApplicationUser is typically the
        //model class for user data in your application.
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Car> Cars { get; set; } 
        
        public DbSet<Agreement> Agreements { get; set; }

        public DbSet<Model> Models { get; set; }    
        public DbSet<Maker> Makers { get; set; } 

        public DbSet<AgreementHistory> AgreementHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var userID1 = Guid.NewGuid().ToString();
            var userID2 = Guid.NewGuid().ToString();

            //Password Hasher The PasswordHasher class is used to hash passwords in ASP.NET Core Identity.
            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser {
                    Id = userID1,
                    FullName = "Admin",
                    Email = "administrator@testing.com",
                    NormalizedEmail = "administrator@testing.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "admin")
                },
                new ApplicationUser {
                    Id = userID2,
                    FullName = "User",
                    Email = "customer@testing.com",
                    NormalizedEmail = "customer@testing.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "customer")
                }
            ) ;

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id="1" , Name="Admin", NormalizedName = "ADMIN".ToUpper() },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER".ToUpper() }
            );

            modelBuilder.Entity< IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId=userID1 , RoleId= "1"},
                new IdentityUserRole<string> { UserId =userID2, RoleId = "2" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model
                {
                    Id = 1,
                    ModelName = "LXI"
                },
                new Model
                {
                    Id = 2,
                    ModelName = "VXI"
                },
                new Model
                {
                    Id = 3,
                    ModelName = "ZXI"
                }
            );
            modelBuilder.Entity<Maker>().HasData(
                new Maker
                {
                    Id = 1,
                    MakerName = "Maruti"
                },
                new Maker
                {
                    Id = 2,
                    MakerName = "Tata"
                },
                new Maker
                {
                    Id = 3,
                    MakerName = "Hyundai"
                },
                new Maker
                {
                    Id = 4,
                    MakerName = "BMW"
                },
                new Maker
                {
                    Id=5,
                    MakerName="Mahindra"
                }
            );
            
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = Guid.NewGuid().ToString(), 
                    Name = "Nexon", 
                    MakerId = 2, 
                    ModelId=2, 
                    RentalPrice=400,
                    CarImage= "https://images.91wheels.com/assets/b_images/main/models/profile/profile1694686142.jpg?w=265&q=60"
                },
                 new Car
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "BMW X3",
                     MakerId = 4,
                     ModelId = 3,
                     RentalPrice = 500,
                     CarImage = "https://images.91wheels.com//assets/b_images/main/models/profile/profile1663160816.jpg?width=480&q=60?w=750&q=60"
                 },
                 new Car
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "Thar",
                     MakerId = 5,
                     ModelId = 1,
                     RentalPrice = 500,
                     CarImage = "https://images.91wheels.com//assets/b_images/main/models/profile/profile1689761890.jpg?width=480&q=60?w=750&q=60"
                 }
                 
            );

        }
    }
}
