using SharedKernel;

namespace Modules.Products.Domain.Products;

public class ProductHistoryEntity : Entity
{
    public Price Price { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Weight { get; set; }

    public int ProductSubCategoryId { get; set; }

    public string UserId { get; set; }

    public string Brand { get; set; }

    public int ProductId { get; set; }

    public string CreatorUserId { get; set; }

    public DateTimeOffset CreateDateTimeUtc { get; set; }

    public virtual ProductEntity Product { get; set; }
}