using SharedKernel;

namespace Modules.Products.Domain.Categories;

public class ProductCategoryEntity : Entity
{
    public string Name { get; set; }

    public virtual ICollection<ProductSubCategoryEntity> ProductSubCategories { get; set; }
}