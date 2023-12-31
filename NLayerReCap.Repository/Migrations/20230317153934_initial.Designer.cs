﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayerReCap.Repository;

#nullable disable

namespace NLayerReCap.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230317153934_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NLayerReCap.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Defterler"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Silgiler"
                        });
                });

            modelBuilder.Entity("NLayerReCap.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 3, 17, 18, 39, 34, 13, DateTimeKind.Local).AddTicks(3179),
                            Name = "Kalem 1",
                            Price = 25m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 3, 17, 18, 39, 34, 13, DateTimeKind.Local).AddTicks(3189),
                            Name = "Defter 1",
                            Price = 540m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 3, 17, 18, 39, 34, 13, DateTimeKind.Local).AddTicks(3192),
                            Name = "Defter 2",
                            Price = 50m,
                            Stock = 350
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 3, 17, 18, 39, 34, 13, DateTimeKind.Local).AddTicks(3193),
                            Name = "Silgi 1",
                            Price = 250m,
                            Stock = 350
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 3, 17, 18, 39, 34, 13, DateTimeKind.Local).AddTicks(3195),
                            Name = "Kalem 2",
                            Price = 150m,
                            Stock = 380
                        });
                });

            modelBuilder.Entity("NLayerReCap.Core.Models.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Green",
                            Height = 20,
                            ProductId = 1,
                            Width = 40
                        },
                        new
                        {
                            Id = 2,
                            Color = "Yellow",
                            Height = 25,
                            ProductId = 4,
                            Width = 80
                        });
                });

            modelBuilder.Entity("NLayerReCap.Core.Models.Product", b =>
                {
                    b.HasOne("NLayerReCap.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NLayerReCap.Core.Models.ProductFeature", b =>
                {
                    b.HasOne("NLayerReCap.Core.Models.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NLayerReCap.Core.Models.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NLayerReCap.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NLayerReCap.Core.Models.Product", b =>
                {
                    b.Navigation("ProductFeature");
                });
#pragma warning restore 612, 618
        }
    }
}
