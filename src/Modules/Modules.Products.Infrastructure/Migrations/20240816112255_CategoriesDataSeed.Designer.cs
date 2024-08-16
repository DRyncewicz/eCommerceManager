﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modules.Products.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Modules.Products.Infrastructure.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20240816112255_CategoriesDataSeed")]
    partial class CategoriesDataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("pcm")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on_utc");

                    b.Property<string>("Error")
                        .HasColumnType("text")
                        .HasColumnName("error");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("processed_on_utc");

                    b.HasKey("Id")
                        .HasName("pk_outbox_messages");

                    b.ToTable("outbox_messages", "pcm");
                });

            modelBuilder.Entity("Modules.Products.Domain.Categories.ProductCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_product_categories");

                    b.ToTable("product_categories", "pcm");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fashion"
                        },
                        new
                        {
                            Id = 3,
                            Name = "House and garden"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Automotive"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Collections and art"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Health and beauty"
                        });
                });

            modelBuilder.Entity("Modules.Products.Domain.Categories.ProductSubCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("product_category_id");

                    b.HasKey("Id")
                        .HasName("pk_product_sub_categories");

                    b.HasIndex("ProductCategoryId")
                        .HasDatabaseName("ix_product_sub_categories_product_category_id");

                    b.ToTable("product_sub_categories", "pcm");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Phones and accessories",
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Laptops and computers",
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Men's clothing",
                            ProductCategoryId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Women's clothing",
                            ProductCategoryId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Furniture",
                            ProductCategoryId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Garden supplies",
                            ProductCategoryId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Car parts",
                            ProductCategoryId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Automotive accessories",
                            ProductCategoryId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Collectible coins",
                            ProductCategoryId = 15
                        },
                        new
                        {
                            Id = 10,
                            Name = "Art prints",
                            ProductCategoryId = 15
                        },
                        new
                        {
                            Id = 11,
                            Name = "Makeup",
                            ProductCategoryId = 6
                        },
                        new
                        {
                            Id = 12,
                            Name = "Skincare",
                            ProductCategoryId = 6
                        });
                });

            modelBuilder.Entity("Modules.Products.Domain.Products.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("brand");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("name");

                    b.Property<int>("ProductSubCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("product_sub_category_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("character varying(450)")
                        .HasColumnName("user_id");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("ProductSubCategoryId")
                        .HasDatabaseName("ix_products_product_sub_category_id");

                    b.ToTable("products", "pcm");
                });

            modelBuilder.Entity("Modules.Products.Domain.Products.ProductHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("brand");

                    b.Property<DateTimeOffset>("CreateDateTimeUtc")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(7)
                        .HasColumnType("timestamp(7) with time zone")
                        .HasColumnName("create_date_time_utc")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

                    b.Property<string>("CreatorUserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("character varying(450)")
                        .HasColumnName("creator_user_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("name");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int>("ProductSubCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("product_sub_category_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("character varying(450)")
                        .HasColumnName("user_id");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_product_histories");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_product_histories_product_id");

                    b.ToTable("product_histories", "pcm");
                });

            modelBuilder.Entity("Modules.Products.Domain.Categories.ProductSubCategoryEntity", b =>
                {
                    b.HasOne("Modules.Products.Domain.Categories.ProductCategoryEntity", "ProductCategory")
                        .WithMany("ProductSubCategories")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProductSubCategory_ProductCategory_ProductSubCategoryId");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Modules.Products.Domain.Products.ProductEntity", b =>
                {
                    b.HasOne("Modules.Products.Domain.Categories.ProductSubCategoryEntity", "ProductSubCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductSubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProductSubCategory_Product_ProductSubCategoryId");

                    b.OwnsOne("Modules.Products.Domain.Products.Price", "Price", b1 =>
                        {
                            b1.Property<int>("ProductEntityId")
                                .HasColumnType("integer")
                                .HasColumnName("id");

                            b1.Property<double>("Amount")
                                .HasColumnType("double precision")
                                .HasColumnName("PriceAmount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PriceCurrency");

                            b1.HasKey("ProductEntityId");

                            b1.ToTable("products", "pcm");

                            b1.WithOwner()
                                .HasForeignKey("ProductEntityId")
                                .HasConstraintName("fk_products_products_id");
                        });

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("ProductSubCategory");
                });

            modelBuilder.Entity("Modules.Products.Domain.Products.ProductHistoryEntity", b =>
                {
                    b.HasOne("Modules.Products.Domain.Products.ProductEntity", "Product")
                        .WithMany("ProductHistories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_ProductHistory_ProductId");

                    b.OwnsOne("Modules.Products.Domain.Products.Price", "Price", b1 =>
                        {
                            b1.Property<int>("ProductHistoryEntityId")
                                .HasColumnType("integer")
                                .HasColumnName("id");

                            b1.Property<double>("Amount")
                                .HasColumnType("double precision")
                                .HasColumnName("PriceAmount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PriceCurrency");

                            b1.HasKey("ProductHistoryEntityId");

                            b1.ToTable("product_histories", "pcm");

                            b1.WithOwner()
                                .HasForeignKey("ProductHistoryEntityId")
                                .HasConstraintName("fk_product_histories_product_histories_id");
                        });

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Modules.Products.Domain.Categories.ProductCategoryEntity", b =>
                {
                    b.Navigation("ProductSubCategories");
                });

            modelBuilder.Entity("Modules.Products.Domain.Categories.ProductSubCategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Modules.Products.Domain.Products.ProductEntity", b =>
                {
                    b.Navigation("ProductHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
