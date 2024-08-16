using Modules.Products.Domain.Products;
using Modules.Products.Domain.Products.Repositories;
using Modules.Products.Infrastructure.Database;

namespace Modules.Products.Infrastructure.Repositories;

public class ProductHistoryRepository(ProductDbContext dbContext) : IProductHistoryRepository
{
    public void Insert(ProductHistoryEntity productHistory)
    {
        dbContext.ProductHistories.Add(productHistory);
    }
}