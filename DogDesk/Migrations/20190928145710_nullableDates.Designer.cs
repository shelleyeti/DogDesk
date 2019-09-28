﻿// <auto-generated />
using System;
using DogDesk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DogDesk.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190928145710_nullableDates")]
    partial class nullableDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DogDesk.Models.AnimalGender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AnimalGenders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Gender = "Female"
                        });
                });

            modelBuilder.Entity("DogDesk.Models.AnimalSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Size")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AnimalSizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Size = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Size = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Size = "Large"
                        });
                });

            modelBuilder.Entity("DogDesk.Models.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Animal")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Animal = "Dog"
                        },
                        new
                        {
                            Id = 2,
                            Animal = "Cat"
                        });
                });

            modelBuilder.Entity("DogDesk.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "000-shelley-arnold-333-7777777",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "273ef2eb-6e06-4e15-b98a-d71559b45b02",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Shelley",
                            LastName = "Arnold",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHMKRkkiBcP8o1v0UjeEFJZW4jsQRCKItK6GokWFVmvpJzaWd4eA3IfhSfYL33Ajsw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("DogDesk.Models.EmergencyContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhone");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("PetId");

                    b.Property<string>("WorkPhone");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("DogDesk.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhone");

                    b.Property<string>("City");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("WorkPhone");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("DogDesk.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AmountFood");

                    b.Property<int>("AnimalTypeId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Breed");

                    b.Property<string>("Color1")
                        .IsRequired();

                    b.Property<string>("Color2");

                    b.Property<int>("GenderId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PetImage");

                    b.Property<string>("PetNote");

                    b.Property<int>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTypeId");

                    b.HasIndex("GenderId");

                    b.HasIndex("SizeId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("DogDesk.Models.PetContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmergencyContactId");

                    b.Property<int>("PetId");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyContactId");

                    b.HasIndex("PetId");

                    b.ToTable("PetContactss");
                });

            modelBuilder.Entity("DogDesk.Models.PetOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OwnerId");

                    b.Property<int>("PetId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetId");

                    b.ToTable("PetOwners");
                });

            modelBuilder.Entity("DogDesk.Models.ServicePet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CheckinTime");

                    b.Property<DateTime>("CheckoutDate");

                    b.Property<DateTime?>("CheckoutTime");

                    b.Property<int>("PetId");

                    b.Property<string>("ServiceNote");

                    b.Property<int>("ServiceType");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("ServiceType");

                    b.ToTable("ServicePets");
                });

            modelBuilder.Entity("DogDesk.Models.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ServiceName");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ServiceName = "Small Dog Boarding"
                        },
                        new
                        {
                            Id = 2,
                            ServiceName = "Medium Dog Boarding"
                        },
                        new
                        {
                            Id = 3,
                            ServiceName = "Large Dog Boarding"
                        },
                        new
                        {
                            Id = 4,
                            ServiceName = "Cat Boarding"
                        },
                        new
                        {
                            Id = 5,
                            ServiceName = "Day Care"
                        },
                        new
                        {
                            Id = 6,
                            ServiceName = "Small Dog Bath"
                        },
                        new
                        {
                            Id = 7,
                            ServiceName = "Medium Dog Bath"
                        },
                        new
                        {
                            Id = 8,
                            ServiceName = "Large Dog Bath"
                        },
                        new
                        {
                            Id = 9,
                            ServiceName = "Nail Trim"
                        });
                });

            modelBuilder.Entity("DogDesk.Models.VetRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Allergy");

                    b.Property<bool>("Altered");

                    b.Property<DateTime?>("Bordetella");

                    b.Property<string>("City");

                    b.Property<int>("PetId");

                    b.Property<int?>("PetOwnerId");

                    b.Property<DateTime?>("Rabies")
                        .IsRequired();

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("VetName");

                    b.Property<string>("WorkPhone");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("PetOwnerId");

                    b.ToTable("VetRecords");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DogDesk.Models.EmergencyContact", b =>
                {
                    b.HasOne("DogDesk.Models.Pet")
                        .WithMany("EmergencyContacts")
                        .HasForeignKey("PetId");
                });

            modelBuilder.Entity("DogDesk.Models.Pet", b =>
                {
                    b.HasOne("DogDesk.Models.AnimalType", "TypeOfAnimal")
                        .WithMany()
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DogDesk.Models.AnimalGender", "GenderOfAnimal")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DogDesk.Models.AnimalSize", "SizeOfAnimal")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DogDesk.Models.PetContact", b =>
                {
                    b.HasOne("DogDesk.Models.EmergencyContact", "EmergencyContact")
                        .WithMany()
                        .HasForeignKey("EmergencyContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DogDesk.Models.Pet", "Pet")
                        .WithMany("PetContacts")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DogDesk.Models.PetOwner", b =>
                {
                    b.HasOne("DogDesk.Models.Owner", "Owner")
                        .WithMany("PetOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DogDesk.Models.Pet", "Pet")
                        .WithMany("PetOwners")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DogDesk.Models.ServicePet", b =>
                {
                    b.HasOne("DogDesk.Models.Pet", "IdOfPet")
                        .WithMany("ServicePets")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DogDesk.Models.ServiceType", "NameOfService")
                        .WithMany()
                        .HasForeignKey("ServiceType")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DogDesk.Models.VetRecord", b =>
                {
                    b.HasOne("DogDesk.Models.Pet", "Pet")
                        .WithMany("VetRecords")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DogDesk.Models.PetOwner", "PetOwner")
                        .WithMany()
                        .HasForeignKey("PetOwnerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DogDesk.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DogDesk.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DogDesk.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DogDesk.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
