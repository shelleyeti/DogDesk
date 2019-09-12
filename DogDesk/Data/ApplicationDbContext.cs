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
        public DbSet<AnimalSize> AnimalSizes { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<AnimalGender> AnimalGenders { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<PetContact> PetContactss { get; set; }
        public DbSet<VetRecord> VetRecords { get; set; }
        public DbSet<ServicePet> ServicePets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<VetRecord>().Property(m => m.Bordetella).IsRequired(false);
            modelBuilder.Entity<PetOwner>().HasOne(po => po.Pet).WithMany(p => p.PetOwners).HasForeignKey(po => po.PetId);
            modelBuilder.Entity<PetOwner>().HasOne(po => po.Owner).WithMany(o => o.PetOwners).HasForeignKey(po => po.OwnerId);

            modelBuilder.Entity<EmergencyContact>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Owner>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pet>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<PetOwner>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<VetRecord>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServicePet>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

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

            modelBuilder.Entity<AnimalSize>().HasData(
                new AnimalSize()
                {
                    Id = 1,
                    Size = "Small"
                },
                new AnimalSize()
                {
                    Id = 2,
                    Size = "Medium"
                },
                new AnimalSize()
                {
                    Id = 3,
                    Size = "Large"
                }
            );

            modelBuilder.Entity<AnimalGender>().HasData(
                new AnimalGender()
                {
                    Id = 1,
                    Gender = "Male"
                },
                new AnimalGender()
                {
                    Id = 2,
                    Gender = "Female"
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
        }
    }
}
