namespace Modules.Products.Domain.Products.Repositories;

public interface IProductHistoryRepository
{
    void Insert(ProductHistoryEntity productHistory);
}