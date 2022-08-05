﻿// <auto-generated />
using System;
using DataAccess.Concretes.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220803201612_car_price_hasprecision")]
    partial class car_price_hasprecision
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Concretes.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concretes.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concretes.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concretes.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Entities.Concretes.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("ColourId")
                        .HasColumnType("int");

                    b.Property<bool?>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GearTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColourId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("GearTypeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Entities.Concretes.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("Entities.Concretes.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ColourName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Colours");
                });

            modelBuilder.Entity("Entities.Concretes.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("Entities.Concretes.GearType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Gear")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("GearTypes");
                });

            modelBuilder.Entity("Entities.Concretes.RentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OriginAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReturnAddress")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("RentDetails");
                });

            modelBuilder.Entity("Entities.Concretes.Customer", b =>
                {
                    b.HasBaseType("Core.Entities.Concretes.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Employee", b =>
                {
                    b.HasBaseType("Core.Entities.Concretes.User");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Car", b =>
                {
                    b.HasOne("Entities.Concretes.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concretes.Colour", "Colour")
                        .WithMany("Cars")
                        .HasForeignKey("ColourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concretes.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concretes.GearType", "GearType")
                        .WithMany("Cars")
                        .HasForeignKey("GearTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Colour");

                    b.Navigation("FuelType");

                    b.Navigation("GearType");
                });

            modelBuilder.Entity("Entities.Concretes.CarImage", b =>
                {
                    b.HasOne("Entities.Concretes.Car", "Car")
                        .WithMany("CarImages")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Entities.Concretes.RentDetail", b =>
                {
                    b.HasOne("Entities.Concretes.Car", "Car")
                        .WithMany("RentDetails")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concretes.Customer", "Customer")
                        .WithMany("RentDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.Concretes.Customer", b =>
                {
                    b.HasOne("Core.Entities.Concretes.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concretes.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concretes.Employee", b =>
                {
                    b.HasOne("Core.Entities.Concretes.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concretes.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concretes.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.Concretes.Car", b =>
                {
                    b.Navigation("CarImages");

                    b.Navigation("RentDetails");
                });

            modelBuilder.Entity("Entities.Concretes.Colour", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.Concretes.FuelType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.Concretes.GearType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.Concretes.Customer", b =>
                {
                    b.Navigation("RentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}