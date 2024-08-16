using SharedKernel;

namespace Modules.Products.Domain.Products;

public class ProductHistoryEntity : Entity
{
    public Price Price { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Weight { get; set; }

    public int ProductSubCategoryId { get; set; }

    public string UserId { get; set; }

    public string Brand { get; set; }

    public int ProductId { get; set; }

    public string CreatorUserId { get; set; }

    public DateTimeOffset CreateDateTimeUtc { get; set; }

    public virtual ProductEntity Product { get; set; }

    public ProductHistoryEntity(ProductEntity product, string userId)
    {
        Price = product.Price;
        Name = product.Name;
        Description = product.Description;
        Weight = product.Weight;
        ProductSubCategoryId = product.ProductSubCategoryId;
        UserId = product.UserId;
        Brand = product.Brand;
        ProductId = product.Id;
        CreatorUserId = userId;
    }

    public ProductHistoryEntity()
    {
    }
}