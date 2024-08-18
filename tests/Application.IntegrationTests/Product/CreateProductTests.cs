using Application.IntegrationTests.Abstractions;
using FluentAssertions;
using Modules.Products.Application.Product.Create;
using Modules.Products.Domain.Products;
using SharedKernel;
using Xunit;

namespace Application.IntegrationTests.Product;

public class CreateProductTests : BaseIntegrationTest
{
    public CreateProductTests(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Handle_Should_CreateProduct_WhenCommandIsValid()
    {
        //Arrange
        var command = new CreateProductCommand()
        {
            Currency = Currency.USD,
            Description = Faker.Commerce.ProductDescription(),
            Amount = 100,
            Brand = Faker.Internet.DomainName(),
            Name = Faker.Commerce.ProductName(),
            UserId = Faker.Internet.UserName(),
            ProductSubCategoryId = 1,
            Weight = 50
        };

        //Act
        var result = await Sender.Send<Result<int>>(command);
        ProductEntity? product = await ProductDbContext.Products.FindAsync(result.Value);

        result.Should().NotBeNull();
        result.IsSuccess.Should().Be(true);
        product.Should().NotBeNull();
    }
}