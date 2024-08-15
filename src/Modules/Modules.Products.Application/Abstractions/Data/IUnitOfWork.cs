using System.Data;

namespace Modules.Products.Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    Task<IDbTransaction> BeginTransactionAsync();
}