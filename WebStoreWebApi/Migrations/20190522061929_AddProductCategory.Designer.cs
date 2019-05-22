﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebStoreWebApi.Models;

namespace WebStoreWebApi.Migrations
{
    [DbContext(typeof(WebStoreDbContext))]
    [Migration("20190522061929_AddProductCategory")]
    partial class AddProductCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebStoreWebApi.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("IconImage");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<Guid>("ParentCategoryId");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateOn");

                    b.Property<string>("CurrencyTypee");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("OrderNum");

                    b.Property<string>("Status");

                    b.Property<int>("TotalAmount");

                    b.Property<Guid?>("UserAddressId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<int>("ProductCode");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUri");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<Guid>("ProductId");

                    b.Property<string>("Size");

                    b.Property<string>("Type");

                    b.Property<string>("label");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAssets");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<Guid>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("CategoryName_D");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<Guid>("ProductId");

                    b.Property<string>("ProductName_D");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("EffectiveFrom");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("Price");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cellphone");

                    b.Property<string>("Email");

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("LoginId");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdressLine1");

                    b.Property<string>("AdressLine2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.Property<Guid>("UserId");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.UserPaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillingAddress");

                    b.Property<DateTime>("CreateOn");

                    b.Property<DateTime>("Expiry");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPaymentMethods");
                });

            modelBuilder.Entity("WebStoreWebApi.Models.Order", b =>
                {
                    b.HasOne("WebStoreWebApi.Models.UserAddress", "UserAddress")
                        .WithMany("Orders")
                        .HasForeignKey("UserAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebStoreWebApi.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductAsset", b =>
                {
                    b.HasOne("WebStoreWebApi.Models.Product", "Product")
                        .WithMany("ProductAssets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductAttribute", b =>
                {
                    b.HasOne("WebStoreWebApi.Models.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductCategory", b =>
                {
                    b.HasOne("WebStoreWebApi.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebStoreWebApi.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebStoreWebApi.Models.ProductPrice", b =>
                {
                    b.HasOne("WebStoreWebApi.Models.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebStoreWebApi.Models.UserAddress", b =>
                {
                    b.HasOne("WebStoreWebApi.Models.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebStoreWebApi.Models.UserPaymentMethod", b =>
                {
                    b.HasOne("WebStoreWebApi.Models.User", "User")
                        .WithMany("UserPaymentMethods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
