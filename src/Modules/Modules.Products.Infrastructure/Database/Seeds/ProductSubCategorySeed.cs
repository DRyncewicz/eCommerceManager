using Microsoft.EntityFrameworkCore;
using Modules.Products.Domain.Categories;

namespace Modules.Products.Infrastructure.Database.Seeds;

public static class ProductSubCategorySeed
{
    public static void ProductSubCategoryDataSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductSubCategoryEntity>().HasData(
            new ProductSubCategoryEntity()
            {
                Id = 1,
                ProductCategoryId = 1,
                Name = "Phones and accessories"
            },
            new ProductSubCategoryEntity()
            {
                Id = 2,
                ProductCategoryId = 1,
                Name = "Laptops and computers"
            },
            new ProductSubCategoryEntity()
            {
                Id = 3,
                ProductCategoryId = 2,
                Name = "Men's clothing"
            },
            new ProductSubCategoryEntity()
            {
                Id = 4,
                ProductCategoryId = 2,
                Name = "Women's clothing"
            },
            new ProductSubCategoryEntity()
            {
                Id = 5,
                ProductCategoryId = 3,
                Name = "Furniture"
            },
            new ProductSubCategoryEntity()
            {
                Id = 6,
                ProductCategoryId = 3,
                Name = "Garden supplies"
            },
            new ProductSubCategoryEntity()
            {
                Id = 7,
                ProductCategoryId = 4,
                Name = "Car parts"
            },
            new ProductSubCategoryEntity()
            {
                Id = 8,
                ProductCategoryId = 4,
                Name = "Automotive accessories"
            },
            new ProductSubCategoryEntity()
            {
                Id = 9,
                ProductCategoryId = 15,
                Name = "Collectible coins"
            },
            new ProductSubCategoryEntity()
            {
                Id = 10,
                ProductCategoryId = 15,
                Name = "Art prints"
            },
            new ProductSubCategoryEntity()
            {
                Id = 11,
                ProductCategoryId = 6,
                Name = "Makeup"
            },
            new ProductSubCategoryEntity()
            {
                Id = 12,
                ProductCategoryId = 6,
                Name = "Skincare"
            }
        );
    }
}