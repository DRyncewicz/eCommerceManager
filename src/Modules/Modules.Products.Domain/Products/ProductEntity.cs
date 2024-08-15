using Modules.Products.Domain.Categories;
using Modules.Products.Domain.Products.DomainEvents;
using SharedKernel;

namespace Modules.Products.Domain.Products;

public class ProductEntity : Entity
{
    public Price Price { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Weight { get; set; }

    public int ProductSubCategoryId { get; set; }

    public string UserId { get; set; }

    public string Brand { get; set; }

    public virtual ProductSubCategoryEntity ProductSubCategory { get; set; }

    public virtual ICollection<ProductHistoryEntity> ProductHistories { get; set; }

    public ProductEntity(Price price,
                         string name,
                         string description,
                         double weight,
                         int productSubCategoryId,
                         string userId,
                         string brand)
    {
        Price = price;
        Name = name;
        Description = description;
        Weight = weight;
        ProductSubCategoryId = productSubCategoryId;
        UserId = userId;
        Brand = brand;
    }

    public ProductEntity()
    {
    }

    public static void RaiseProductCreated(ProductEntity product)
    {
        product.Raise(new ProductCreatedDomainEvent(product.Id));
    }
}