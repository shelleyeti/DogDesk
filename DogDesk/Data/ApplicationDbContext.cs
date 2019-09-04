using System;
using System.Collections.Generic;
using System.Text;
using DogDesk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DogDesk.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<VetRecord> VetRecords { get; set; }
        public DbSet<ServicePet> ServicePets { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<VetRecord>().Property(m => m.Bordetella).IsRequired(false);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Shelley",
                LastName = "Arnold",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "000-shelley-arnold-333-7777777"
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<AnimalType>().HasData(
                new AnimalType()
                {
                    Id = 1,
                    Animal = "Dog"
                },
                new AnimalType()
                {
                    Id = 2,
                    Animal = "Cat"
                }
            );

            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType()
                {
                    Id = 1,
                    ServiceName = "Small Dog Boarding"
                },
                new ServiceType()
                {
                    Id = 2,
                    ServiceName = "Medium Dog Boarding"
                },
                new ServiceType()
                {
                    Id = 3,
                    ServiceName = "Large Dog Boarding"
                },
                new ServiceType()
                {
                    Id = 4,
                    ServiceName = "Cat Boarding"
                },
                new ServiceType()
                {
                    Id = 5,
                    ServiceName = "Day Care"
                },
                new ServiceType()
                {
                    Id = 6,
                    ServiceName = "Small Dog Bath"
                },
                new ServiceType()
                {
                    Id = 7,
                    ServiceName = "Medium Dog Bath"
                },
                new ServiceType()
                {
                    Id = 8,
                    ServiceName = "Large Dog Bath"
                },
                new ServiceType()
                {
                    Id = 9,
                    ServiceName = "Nail Trim"
                }
            );

            modelBuilder.Entity<Pet>().HasData(
                new Pet()
                {
                    Id =1,
                    FirstName = "Cavy",
                    LastName = "Arnold",
                    Gender = "Male",
                    BirthDate = new DateTime(2014, 8, 1),
                    Size = "medium",
                    Color1 = "black",
                    Color2 = "tri-color",
                    AnimalTypeId = 1,
                    OwnerId = 1
                }
            );

            modelBuilder.Entity<VetRecord>().HasData(
                new VetRecord()
                {
                    Id = 1,
                    PetId = 1,
                    VetName = "Mobley",
                    StreetAddress = "4709 Gallatin Pk",
                    City = "Nahsville",
                    ZipCode = 37216,
                    State = "TN",
                    WorkPhone = "615-262-0415",
                    Allergy = "Beef",
                    Altered = true,
                    Rabies = new DateTime(2018, 9, 19),
                    Bordetella = new DateTime(2018, 9, 19)
                }
            );

            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = 1,
                    FirstName = "Shelley",
                    LastName = "Arnold",
                    StreetAddress = "1234 Dog Way",
                    City = "Nahsville",
                    State = "TN",
                    ZipCode = 37206,
                    HomePhone = null,
                    CellPhone = "615-555-5555",
                    WorkPhone = null,
                }
            );

            modelBuilder.Entity<EmergencyContact>().HasData(
                new EmergencyContact()
                {
                    Id = 1,
                    PetId = 1,
                    FirstName = "Janice",
                    LastName = "Arant",
                    HomePhone = null,
                    CellPhone = "615-555-5555",
                    WorkPhone = null,
                }
            );

            modelBuilder.Entity<ServicePet>().HasData(
                new ServicePet()
                {
                    Id = 1,
                    UserId = user.Id,
                    ServiceType = 2,
                    PetId = 1,
                    StartDate = new DateTime(2019, 9, 19),
                    CheckoutDate = new DateTime(2019, 9, 23)
                }
            );

            modelBuilder.Entity<PetOwner>().HasData(
                new PetOwner()
                {
                    Id = 1,
                    PetId = 1,
                    OwnerId = 1
                }
            );
        }
    }
}
