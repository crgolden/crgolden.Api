﻿// <auto-generated />
using System;
using System.CodeDom.Compiler;
using Cef.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cef.API.Data.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20190105132022_ProductCartOrderPayment")]
    [GeneratedCode("Entity Framework Core", "1")]
    partial class ProductCartOrderPayment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cef.API.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Updated");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Cef.API.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Cef.API.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FileName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("Uri");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Cef.API.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ShippingAddress");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Updated");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Cef.API.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AuthorizationCode");

                    b.Property<string>("ChargeId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Currency")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("OrderId");

                    b.Property<string>("TokenId")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Cef.API.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDownload");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("QuantityPerUnit")
                        .IsRequired();

                    b.Property<int>("ReorderLevel");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock");

                    b.Property<int>("UnitsOnOrder");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Cef.API.Relationships.CartProduct", b =>
                {
                    b.Property<Guid>("Model1Id");

                    b.Property<Guid>("Model2Id");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDownload");

                    b.Property<string>("Model1Name")
                        .IsRequired();

                    b.Property<string>("Model2Name")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Model1Id", "Model2Id");

                    b.HasIndex("Model2Id");

                    b.ToTable("CartProducts");
                });

            modelBuilder.Entity("Cef.API.Relationships.OrderProduct", b =>
                {
                    b.Property<Guid>("Model1Id");

                    b.Property<Guid>("Model2Id");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDownload");

                    b.Property<string>("Model1Name")
                        .IsRequired();

                    b.Property<string>("Model2Name")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Model1Id", "Model2Id");

                    b.HasIndex("Model2Id");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Cef.API.Relationships.ProductCategory", b =>
                {
                    b.Property<Guid>("Model1Id");

                    b.Property<Guid>("Model2Id");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Model1Name")
                        .IsRequired();

                    b.Property<string>("Model2Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Model1Id", "Model2Id");

                    b.HasIndex("Model2Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Cef.API.Relationships.ProductFile", b =>
                {
                    b.Property<Guid>("Model1Id");

                    b.Property<Guid>("Model2Id");

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Model1Name")
                        .IsRequired();

                    b.Property<string>("Model2Name")
                        .IsRequired();

                    b.Property<bool>("Primary");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("Uri");

                    b.HasKey("Model1Id", "Model2Id");

                    b.HasIndex("Model2Id");

                    b.ToTable("ProductFiles");
                });

            modelBuilder.Entity("Cef.API.Models.Payment", b =>
                {
                    b.HasOne("Cef.API.Models.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cef.API.Relationships.CartProduct", b =>
                {
                    b.HasOne("Cef.API.Models.Cart", "Model1")
                        .WithMany("CartProducts")
                        .HasForeignKey("Model1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cef.API.Models.Product", "Model2")
                        .WithMany("CartProducts")
                        .HasForeignKey("Model2Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cef.API.Relationships.OrderProduct", b =>
                {
                    b.HasOne("Cef.API.Models.Order", "Model1")
                        .WithMany("OrderProducts")
                        .HasForeignKey("Model1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cef.API.Models.Product", "Model2")
                        .WithMany("OrderProducts")
                        .HasForeignKey("Model2Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cef.API.Relationships.ProductCategory", b =>
                {
                    b.HasOne("Cef.API.Models.Product", "Model1")
                        .WithMany("ProductCategories")
                        .HasForeignKey("Model1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cef.API.Models.Category", "Model2")
                        .WithMany("ProductCategories")
                        .HasForeignKey("Model2Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cef.API.Relationships.ProductFile", b =>
                {
                    b.HasOne("Cef.API.Models.Product", "Model1")
                        .WithMany("ProductFiles")
                        .HasForeignKey("Model1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cef.API.Models.File", "Model2")
                        .WithMany("ProductFiles")
                        .HasForeignKey("Model2Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
