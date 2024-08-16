using Modules.Products.Domain.Products;
using SharedKernel;

namespace Modules.Products.Domain.Categories;

public class ProductSubCategoryEntity : Entity
{
    public string Name { get; set; }

    public int ProductCategoryId { get; set; }

    public virtual ProductCategoryEntity ProductCategory { get; set; }

    public virtual ICollection<ProductEntity> Products { get; set; }
}