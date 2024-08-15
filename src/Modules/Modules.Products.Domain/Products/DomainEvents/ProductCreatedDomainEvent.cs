using SharedKernel;

namespace Modules.Products.Domain.Products.DomainEvents;

public sealed record ProductCreatedDomainEvent(int productId) : IDomainEvent;