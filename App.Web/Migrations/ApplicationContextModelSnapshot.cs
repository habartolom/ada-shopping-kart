﻿// <auto-generated />
using System;
using App.Web.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Web.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Web.Models.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Items")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("App.Web.Models.Entities.OrderProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts", (string)null);
                });

            modelBuilder.Entity("App.Web.Models.Entities.PersonEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5eb7d209-020b-477c-9e01-db717874faf6"),
                            Address = "Calle 49 A Sur 87 J 29",
                            Name = "Harold Andrés Bartolo Moscoso",
                            Phone = "3028305818"
                        });
                });

            modelBuilder.Entity("App.Web.Models.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5549ecc8-d045-4ab3-9dee-91a5f9309168"),
                            Name = "PC Mallow TM97 AMD Ryzen 5 4600G Ram 8GB SSD 480GB",
                            Price = 1650000.0,
                            Stock = 1
                        },
                        new
                        {
                            Id = new Guid("d2ee4b30-b75e-413c-9657-26fe88fab079"),
                            Name = "PC Mallow TM92 AMD Ryzen 3 4100 GT 1030 2GB Ram 8GB M.2 256GB *Ob",
                            Price = 1599000.0,
                            Stock = 0
                        },
                        new
                        {
                            Id = new Guid("791418a9-f7bf-49a1-a3ba-0189b4d90c4b"),
                            Name = "PC Gamer Mallow TM96 AMD Ryzen 5 5600G Ram 16GB M.2 512GB",
                            Price = 1999000.0,
                            Stock = 11
                        },
                        new
                        {
                            Id = new Guid("4cc04711-3fef-4701-87fc-3afbb93f0d77"),
                            Name = "PC Gamer Violet TV40 Intel Core i3-13100F GTX 1650 4GB Ram 16GB M",
                            Price = 2899000.0,
                            Stock = 13
                        },
                        new
                        {
                            Id = new Guid("b40a2618-34ff-434f-8536-750386ff7417"),
                            Name = "PC Gamer Tauret Orchid TO70 AMD Ryzen 5 4600G GTX 1660 Ti 6GB Ram",
                            Price = 3499000.0,
                            Stock = 15
                        },
                        new
                        {
                            Id = new Guid("c53892e1-11c5-45af-943a-c5ed141eb8b1"),
                            Name = "PC Gamer Tauret Orchid TO66 Intel Core i5-12400 GTX 1660 6GB Ram",
                            Price = 3799000.0,
                            Stock = 14
                        },
                        new
                        {
                            Id = new Guid("75af7488-cb99-4832-86d3-3f8ad4ac59bd"),
                            Name = "PC Gamer Tauret Amethyst TA73 Intel core 13400F RTX 3060 Ti 8GB R",
                            Price = 3899000.0,
                            Stock = 10
                        },
                        new
                        {
                            Id = new Guid("cce3fadb-ff90-4f77-8a6c-0c6df0dfb460"),
                            Name = "PC Gamer Tauret Amethyst TA70 Alto Rendimiento AMD Ryzen 7 5700X",
                            Price = 5150000.0,
                            Stock = 13
                        },
                        new
                        {
                            Id = new Guid("e666f08f-f2f2-4b21-9f95-68592352b1d1"),
                            Name = "PC Gamer Tauret Orchid TO72 AMD Ryzen 5 5600X RTX 3050 8GB Ram 16",
                            Price = 5799000.0,
                            Stock = 21
                        },
                        new
                        {
                            Id = new Guid("9814abc4-a82e-4ced-a580-374262cac081"),
                            Name = "PC Gamer Tauret Amethyst TA53 AMD Ryzen 7 5800X3D RTX 3060 12GB R",
                            Price = 6599000.0,
                            Stock = 8
                        },
                        new
                        {
                            Id = new Guid("553fe4cc-4135-4d38-8d48-63e2674fefd9"),
                            Name = "PC Gamer Tauret Amethyst TA66 intel Core i5-13400F RTX 3070 8GB R",
                            Price = 6799000.0,
                            Stock = 4
                        },
                        new
                        {
                            Id = new Guid("a9867bb9-8f6a-4669-96aa-297f8f25ddf2"),
                            Name = "PC Gamer Tauret Amethyst TA71 AMD Ryzen 7 5800X3D RTX 4070 12GB R",
                            Price = 7999000.0,
                            Stock = 10
                        },
                        new
                        {
                            Id = new Guid("6d4e1dc4-f1d7-423f-99bb-730628a64d55"),
                            Name = "PC Gamer Tauret Amethyst TA75 AMD Ryzen 5 7600X RTX 4060 Ti 8GB R",
                            Price = 7999000.0,
                            Stock = 5
                        },
                        new
                        {
                            Id = new Guid("af655618-a03a-4517-9070-8b2db89a3a7c"),
                            Name = "PC Gamer Tauret Amethyst TA76 AMD Ryzen 7 7700X RTX 4070 Ti 12GB",
                            Price = 9799000.0,
                            Stock = 5
                        });
                });

            modelBuilder.Entity("App.Web.Models.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec8367a7-e178-41c5-a2a4-882545e026ec"),
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = new Guid("a013c111-a455-4b0f-8adf-e40c04922abb"),
                            Name = "Regular"
                        });
                });

            modelBuilder.Entity("App.Web.Models.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c95ee721-efdd-4e25-b969-45a9f6235e45"),
                            IsActive = true,
                            PasswordHash = "omXELhhijwpUNqzdst2HTtuY8oplkmgyRi7o45Ptrjc=",
                            PasswordSalt = "aL5obEwZGtIprvlpvLA6BQ==",
                            PersonId = new Guid("5eb7d209-020b-477c-9e01-db717874faf6"),
                            RoleId = new Guid("ec8367a7-e178-41c5-a2a4-882545e026ec"),
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("App.Web.Models.Entities.OrderEntity", b =>
                {
                    b.HasOne("App.Web.Models.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Persons");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Web.Models.Entities.OrderProductEntity", b =>
                {
                    b.HasOne("App.Web.Models.Entities.OrderEntity", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProducts_Orders");

                    b.HasOne("App.Web.Models.Entities.ProductEntity", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProducts_Products");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("App.Web.Models.Entities.UserEntity", b =>
                {
                    b.HasOne("App.Web.Models.Entities.PersonEntity", "Person")
                        .WithOne("User")
                        .HasForeignKey("App.Web.Models.Entities.UserEntity", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Web.Models.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("App.Web.Models.Entities.OrderEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("App.Web.Models.Entities.PersonEntity", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("App.Web.Models.Entities.ProductEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("App.Web.Models.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("App.Web.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}