﻿// <auto-generated />
using System;
using DogDesk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DogDesk.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DogDesk.Models.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Animal");

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
                            ConcurrencyStamp = "5d761841-7a8d-415d-a260-d91b084d4126",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Shelley",
                            LastName = "Arnold",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEF5mOlWD3zKmmSyNB2RmVFq1fcpo13l9xOeddhc7ndKRykfHfKh2WfWD7JTVq27HIw==",
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

                    b.Property<string>("FirstName");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<int>("PetId");

                    b.Property<string>("WorkPhone");

                    b.HasKey("Id");

                    b.ToTable("EmergencyContacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CellPhone = "615-555-5555",
                            FirstName = "Janice",
                            LastName = "Arant",
                            PetId = 1
                        });
                });

            modelBuilder.Entity("DogDesk.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhone");

                    b.Property<string>("City");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<int>("PetId");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("WorkPhone");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CellPhone = "615-555-5555",
                            City = "Nahsville",
                            FirstName = "Shelley",
                            LastName = "Arnold",
                            PetId = 1,
                            State = "TN",
                            StreetAddress = "1234 Dog Way",
                            ZipCode = 37206
                        });
                });

            modelBuilder.Entity("DogDesk.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnimalTypeId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Color1");

                    b.Property<string>("Color2");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalTypeId = 1,
                            BirthDate = new DateTime(2014, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Color1 = "black",
                            Color2 = "tri-color",
                            FirstName = "Cavy",
                            Gender = "Male",
                            LastName = "Arnold",
                            Size = "medium"
                        });
                });

            modelBuilder.Entity("DogDesk.Models.PetOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OwnerId");

                    b.Property<int>("PetId");

                    b.HasKey("Id");

                    b.ToTable("PetOwners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OwnerId = 1,
                            PetId = 1
                        });
                });

            modelBuilder.Entity("DogDesk.Models.ServicePet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CheckoutDate");

                    b.Property<int>("PetId");

                    b.Property<int>("ServiceType");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ServicePets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckoutDate = new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PetId = 1,
                            ServiceType = 2,
                            StartDate = new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "000-shelley-arnold-333-7777777"
                        });
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
                            ServiceName = "Nails"
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

                    b.Property<DateTime>("Rabies");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("VetName");

                    b.Property<string>("WorkPhone");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("VetRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Allergy = "Beef",
                            Altered = true,
                            Bordetella = new DateTime(2018, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Nahsville",
                            PetId = 1,
                            Rabies = new DateTime(2018, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = "TN",
                            StreetAddress = "4709 Gallatin Pk",
                            VetName = "Mobley",
                            WorkPhone = "615-262-0415",
                            ZipCode = 37216
                        });
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

            modelBuilder.Entity("DogDesk.Models.VetRecord", b =>
                {
                    b.HasOne("DogDesk.Models.Pet")
                        .WithMany("VetRecords")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
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
