using Modules.Products.Domain.Products;
using Modules.Products.Domain.Products.Repositories;
using Modules.Products.Infrastructure.Database;

namespace Modules.Products.Infrastructure.Repositories;

public class ProductRepository(ProductDbContext dbContext) : IProductRepository
{
    public void Insert(ProductEntity product)
    {
        dbContext.Products.Add(product);
    }
}