using Application.Abstractions.Events;

namespace Modules.Products.Application.Product.Create;

public record ProductCreatedIntegrationEvent(Guid Id, int ProductId) : IIntegrationEvent;