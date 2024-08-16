using Application.Abstractions.Messaging;
using Modules.Products.Domain.Products;

namespace Modules.Products.Application.Product.Create;

public class CreateProductCommand : ICommand<int>, ITransactionalCommand
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double Amount { get; set; }

    public Currency Currency { get; set; }

    public double Weight { get; set; }

    public int ProductSubCategoryId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;
}