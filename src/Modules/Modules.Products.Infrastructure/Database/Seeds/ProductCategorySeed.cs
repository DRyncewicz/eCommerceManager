using Microsoft.EntityFrameworkCore;
using Modules.Products.Domain.Categories;

namespace Modules.Products.Infrastructure.Database.Seeds;

public static class ProductCategorySeed
{
    public static void ProductCategoryDataSeed(this ModelBuilder modelBuider)
    {
        modelBuider.Entity<ProductCategoryEntity>().HasData(
            new ProductCategoryEntity()
            {
                Id = 1,
                Name = "Electronics"
            },
            new ProductCategoryEntity()
            {
                Id = 2,
                Name = "Fashion"
            },
            new ProductCategoryEntity()
            {
                Id = 3,
                Name = "House and garden"
            },
            new ProductCategoryEntity()
            {
                Id = 4,
                Name = "Automotive"
            },
            new ProductCategoryEntity()
            {
                Id = 15,
                Name = "Collections and art"
            },
            new ProductCategoryEntity()
            {
                Id = 6,
                Name = "Health and beauty"
            }
        );
    }
}