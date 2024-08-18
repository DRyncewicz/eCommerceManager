using Application.Abstractions.Data;
using Application.Abstractions.Events;
using Application.Abstractions.Messaging;
using Modules.Products.Domain.Products;
using Modules.Products.Domain.Products.Repositories;
using SharedKernel;

namespace Modules.Products.Application.Product.Create;

public class CreateProductCommandHandler(IProductRepository productRepository,
                                           IProductHistoryRepository productHistoryRepository,
                                           IUnitOfWork unitOfWork,
                                           IEventBus eventBus) : ICommandHandler<CreateProductCommand, int>
{
    public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Price price = new(request.Amount, request.Currency);

        ProductEntity product = new(price,
                                    request.Name,
                                    request.Description,
                                    request.Weight,
                                    request.ProductSubCategoryId,
                                    request.UserId,
                                    request.Brand);
        if (product is null)
        {
            return Result.Failure<int>(ProductErrors.Failure());
        }

        productRepository.Insert(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        ProductHistoryEntity productHistory = new(product, request.UserId);
        productHistoryRepository.Insert(productHistory);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        ProductEntity.RaiseProductCreated(product);
        await eventBus.PublishAsync(new ProductCreatedIntegrationEvent(Guid.NewGuid(), product.Id), cancellationToken);
        return Result.Success(product.Id);
    }
}