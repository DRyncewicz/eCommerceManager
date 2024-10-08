﻿using System.Data;

namespace Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    Task<IDbTransaction> BeginTransactionAsync();
}