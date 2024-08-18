using Application.Abstractions.Data;
using Application.Abstractions.Events;
using FluentAssertions;
using Modules.Products.Application.Product.Create;
using Modules.Products.Domain.Products;
using Modules.Products.Domain.Products.Repositories;
using Moq;
using Xunit;

namespace Application.UnitTests.Product.CreateProduct;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IProductHistoryRepository> _productHistoryRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IEventBus> _eventBusMock;
    private readonly CreateProductCommandHandler _handler;

    public CreateProductCommandHandlerTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _productHistoryRepositoryMock = new Mock<IProductHistoryRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _eventBusMock = new Mock<IEventBus>();

        _handler = new CreateProductCommandHandler(
            _productRepositoryMock.Object,
            _productHistoryRepositoryMock.Object,
            _unitOfWorkMock.Object,
            _eventBusMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldPublishProductCreatedEvent_WhenProductIsCreatedSuccessfully()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            Amount = 100,
            Currency = Currency.PLN,
            Name = "Product Name",
            Description = "Product Description",
            Weight = 25,
            ProductSubCategoryId = 1,
            UserId = Guid.NewGuid().ToString(),
            Brand = "Brand Name"
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();

        _eventBusMock.Verify(eb => eb.PublishAsync(It.IsAny<ProductCreatedIntegrationEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}